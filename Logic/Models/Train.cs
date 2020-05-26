using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Models
{
    public class Train: ITrain
    {
        // create an assigned animal list, so that we may track what animals have already been assined to a train wagon
        private List<IAnimal> assignedAnimals { get; set; } = new List<IAnimal>();

        public List<IWagon> wagons { get; private set; } = new List<IWagon>();

        public Train FillTrainWagons(List<IAnimal> animals)
        {
            // check if animals is filled
            if (animals == null)
                throw new ArgumentNullException("Animals");

            // start a count of the animals, so that we can track if all animals have been assigned to a train wagon
            int animalCount = 0;

            // loop through the animals, untill all animals have been assinged to a train wagon
            while (animalCount < animals.Count)
            {
                List<IAnimal> animalList = animals.Except(assignedAnimals).ToList();

                Wagon wagon = new Wagon();

                wagon.AsignAnimalsToWagon(animalList);

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
