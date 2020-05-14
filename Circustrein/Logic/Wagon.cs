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

        public void AddToWagon(Animal animal)
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

        public bool CheckIfFits(BodySize animalSize)
        {
            BodySize meatEaterSize = GetMeatEaterSize();

            if ((usedSpace + (int)animalSize) <= maxSize && animalSize > meatEaterSize)
            {
                return true;
            }

            return false;
        }

        public BodySize GetMeatEaterSize()
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

        public bool CheckForMeatEater()
        {
            // create an instance of alterList, so we van get a list of the meat eaters inside of the train wagon
            ListFilters filter = new ListFilters();

            // get a list of meat eaters from the train wagon
            List<Animal> meatEaterList = filter.GetCarnivoreList(animals);

            // check if there is a meat eater inside of the train wagon and return as bool
            return meatEaterList.Count() > 0;
        }

        public BodySize GetSmalestAnimalSize()
        {
            // get the smalles animal inside of the train wagon
            return animals.Select(a => a.size).Min();
        }

        public void AddMeatEaters(List<Animal> meatEaters)
        {
            if (meatEaters == null)
                throw new ArgumentNullException();

            foreach (Animal animal in meatEaters)
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
                        AddToWagon(animal);
                    }
                }

            }
        }

        public void AddPlantEaters(List<Animal> plantEaters)
        {
            if (plantEaters == null)
                throw new ArgumentNullException();

            foreach (Animal animal in plantEaters)
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
                        AddToWagon(animal);
                    }
                    else
                    {
                        if (fits)
                        {
                            AddToWagon(animal);
                        }
                    }
                }

            }
        }
    }
}


