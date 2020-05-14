using System;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein.Logic
{
    public class Wagon
    {
        public List<Animal> animals { get; private set; } = new List<Animal>();
        public int maxSize { get; private set; } = 10;

        // get a count for the total storage amount that is used
        public int usedSpace { get; private set; } = 0;

        public Wagon(int size = 0)
        {
            if(size > 0)
            {
                maxSize = size;
            }
        }

        public void AddAnimal(List<Animal> animalList)
        {
            if (animalList == null)
                throw new ArgumentNullException();

            foreach (Animal animal in animalList)
            {
                if (animals.Count == 0)
                {
                    AddToWagon(animal);
                }
                else
                {
                    bool meatEaterAssigned = CheckForMeatEater();
                    bool fits = CheckIfFits(animal.size);
                    if (!meatEaterAssigned && fits)
                    {
                        if (animal.food == FoodType.Meat)
                        {
                            BodySize size = GetSmalestAnimalSize();
                            if (animal.size >= size) continue;
                        }

                        AddToWagon(animal);
                    }
                    else
                    {
                        int meatEaterSize = 0;
                        if (meatEaterAssigned)
                        {
                            meatEaterSize = (int)GetMeatEaterSize();
                        }

                        if (fits && animal.food == FoodType.Plants && (int)animal.size > meatEaterSize)
                        {
                            AddToWagon(animal);
                        }
                    }
                }

            }
        }

        private void AddToWagon(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("Animal");
            }

            if (animal.ValidateValues() == false)
            {
                throw new ArgumentException("Animal values");
            }

            animals.Add(animal); 
            usedSpace += (int)animal.size;
        }

        private bool CheckIfFits(BodySize animalSize)
        {
            BodySize meatEaterSize = GetMeatEaterSize();

            if ((usedSpace + (int)animalSize) <= maxSize && animalSize > meatEaterSize)
            {
                return true;
            }

            return false;
        }

        private BodySize GetMeatEaterSize()
        {
            // create instance of alterList, so we can get the meat eater inside of the train wagon
            ListFilters filter = new ListFilters();

            // get the meat eaters inside of the train wagon
            List<Animal> meatEater = filter.GetCarnivoreList(animals);

            BodySize size = 0;
            if (meatEater.Count() > 0)
            {
                // return the size of the only meat eater inside of the train wagon
                size = meatEater.Select(a => a.size).First();
            }

            return size;
        }

        private bool CheckForMeatEater()
        {
            // create an instance of alterList, so we van get a list of the meat eaters inside of the train wagon
            ListFilters filter = new ListFilters();

            // get a list of meat eaters from the train wagon
            List<Animal> meatEaterList = filter.GetCarnivoreList(animals);

            // check if there is a meat eater inside of the train wagon and return as bool
            return meatEaterList.Count() > 0;
        }

        private BodySize GetSmalestAnimalSize()
        {
            // get the smalles animal inside of the train wagon
            return animals.Select(a => a.size).Min();
        }


    }
}


