using Logic;
using Logic.Helpers;
using Logic.Interfaces;
using Logic.Models;
using System.Collections.Generic;

namespace UnitTests
{
    public class AnimalList
    {
        public List<Animal> UnsortedAnimals { get; } = new List<Animal>()
        {
            new Herbivour() { name = "Ape", food = FoodType.Plants, size = BodySize.Medium },
            new Herbivour() { name = "Elaphant", food = FoodType.Plants, size = BodySize.Big },
            new Carnivour() { name = "Lion", food = FoodType.Meat, size = BodySize.Big },
            new Carnivour() { name = "Tiger", food = FoodType.Meat, size = BodySize.Big },
            new Carnivour() { name = "Eagle", food = FoodType.Meat, size = BodySize.Medium },
            new Carnivour() { name = "Wolf", food = FoodType.Meat, size = BodySize.Medium },
            new Herbivour() { name = "Mice", food = FoodType.Plants, size = BodySize.Small },
            new Carnivour() { name = "Ferret", food = FoodType.Meat, size = BodySize.Small },
            new Herbivour() { name = "Bunny", food = FoodType.Plants, size = BodySize.Small },
            new Herbivour() { name = "Deer", food = FoodType.Plants, size = BodySize.Medium },
            new Carnivour() { name = "Croocodile", food = FoodType.Meat, size = BodySize.Big }
        };

        public List<Animal> SortedAnimals
        {
            get
            {
                ListSorter sorter = new ListSorter();
                return sorter.SortAnimalsForOptimalAssignment(UnsortedAnimals);
            }
        }
    }
}
