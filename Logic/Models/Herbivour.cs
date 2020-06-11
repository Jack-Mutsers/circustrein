using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Herbivour : Animal, IAnimal
    {
        public override bool CheckIfAllowed(IAnimal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("No Animal");

            if (animal.name == "")
                throw new ArgumentException("Empty Animal");

            if (animal.food == FoodType.Meat && animal.size < size)
                return true;

            if (animal.food == FoodType.Plants)
                return true;

            return false;
        }
    }
}
