using Logic.Helpers;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Models
{
    public class Wagon: IWagon
    {
        public IEnumerable<Animal> animals { get; private set; } = new List<Animal>();

        public int maxSize { get; private set; } = 10;
        public int usedSpace { get; private set; } = 0;

        public Wagon(int size = 0)
        {
            if(size > 0)
            {
                maxSize = size;
            }
        }

        public void AsignAnimalsToWagon(List<Animal> animalList)
        {
            if (animalList == null)
                throw new ArgumentNullException();

            foreach (Animal animal in animalList)
            {
                if (animal == null)
                    throw new ArgumentNullException("Animal null");

                if (animal.name == "")
                    throw new ArgumentException("Animal name");

                if (maxSize == usedSpace)
                    break;

                if (animals.ToList().Count == 0)
                {
                    AddToWagon(animal);
                    continue;
                }

                bool fits = CheckIfFits(animal.size);
                if (!fits)
                    continue;

                bool allowed = false;
                foreach (Animal animal1 in animals)
                {
                    allowed = animal1.CheckIfAllowed(animal);

                    if (!allowed)
                    {
                        break;
                    }
                }

                if (allowed)
                {
                    AddToWagon(animal);
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

            List<Animal> animalList = animals.ToList();
            animalList.Add(animal);

            animals = animalList;
            usedSpace += (int)animal.size;
        }

        private bool CheckIfFits(BodySize animalSize)
        {
            //BodySize meatEaterSize = GetMeatEaterSize();

            if ((usedSpace + (int)animalSize) <= maxSize)
            {
                return true;
            }

            return false;
        }

    }
}


