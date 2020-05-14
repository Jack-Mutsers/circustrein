using System;
using System.Collections.Generic;
using System.Linq;

namespace Circustrein.Logic
{
    public class Train
    {
        // create an assigned animal list, so that we may track what animals have already been assined to a train wagon
        private List<Animal> assignedAnimals { get; set; } = new List<Animal>();

        public List<Wagon> wagons { get; set; } = new List<Wagon>();

        public Train FillTrainWagons(List<Animal> animals)
        {
            // check if animals is filled
            if (animals == null)
                throw new ArgumentNullException("Animals");

            // create an instance of alterList to sort and alter the lists
            ListFilters filter = new ListFilters();

            // get all carnivores from the animal list
            //List<Animal> meatEaters = filter.GetCarnivoreList(animals);

            // get all omnivores from the animal list
            //List<Animal> plantEaters = filter.GetOmnivoreList(animals);

            // start a count of the animals, so that we can track if all animals have been assigned to a train wagon
            int animalCount = 0;

            // loop through the animals, untill all animals have been assinged to a train wagon
            while (animalCount < animals.Count)
            {
                //meatEaters = meatEaters.Except(assignedAnimals).ToList();
                //plantEaters = plantEaters.Except(assignedAnimals).ToList();
                List<Animal> animalList = animals.Except(assignedAnimals).ToList();

                Wagon wagon = new Wagon();

                wagon.AddAnimal(animalList);

                wagons.Add(wagon);

                foreach (Animal animal in wagon.animals)
                {
                    assignedAnimals.Add(animal);
                }

                // increase the animal count by the same amount of animals as there are in the newly filled train wagon
                animalCount += wagon.animals.Count;
            }

            return this;
        }


    }
}
