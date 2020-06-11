using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Carnivour : Animal, IAnimal
    {
        public override bool CheckIfAllowed(IAnimal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("No Animal");

            if (animal.name == "")
                throw new ArgumentException("Empty Animal");

            if (animal.food == FoodType.Meat)
                return false;

            if (animal.food == FoodType.Plants && animal.size > size)
                return true;

            return false;
        }
    }
}
