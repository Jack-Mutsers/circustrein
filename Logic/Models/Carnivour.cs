using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Carnivour : Animal
    {
        public override bool CheckIfAllowed(Animal animal)
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
