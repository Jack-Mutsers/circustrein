using System;

namespace Logic.Interfaces
{
    public interface IAnimal
    {
        string name { get; set; }
        BodySize size { get; set; }
        FoodType food { get; set; }

        void ResetToDefault();
        bool ValidateValues();
    }
}
