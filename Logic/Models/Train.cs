using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Models
{
    public class Train: ITrain
    {
        private List<IAnimal> assignedAnimals { get; set; } = new List<IAnimal>();

        public List<IWagon> trainWagons { get; private set; } = new List<IWagon>();

        public void FillTrainWagons(List<IAnimal> animals)
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

                IWagon wagon = new Wagon();

                wagon.AsignAnimalsToWagon(animalList);

                trainWagons.Add(wagon);

                foreach (IAnimal animal in wagon.animals)
                {
                    assignedAnimals.Add(animal);
                }

                // increase the animal count by the same amount of animals as there are in the newly filled train wagon
                animalCount += wagon.animals.Count();
            }
        }

    }
}
