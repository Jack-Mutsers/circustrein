using Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IAnimal
    {
        string name { get; set; }
        BodySize size { get; set; }
        FoodType food { get; set; }

        void ResetToDefault();
        bool ValidateValues();
        bool CheckIfAllowed(IAnimal animal);
    }
}
