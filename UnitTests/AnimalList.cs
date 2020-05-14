﻿using Circustrein.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class AnimalList
    {
        public List<Animal> Animals { get; set; } = new List<Animal>()
        {
            new Animal() { name = "Ape", food = FoodType.Plants, size = BodySize.Medium },
            new Animal() { name = "Elaphant", food = FoodType.Plants, size = BodySize.Big },
            new Animal() { name = "Lion", food = FoodType.Meat, size = BodySize.Big },
            new Animal() { name = "Tiger", food = FoodType.Meat, size = BodySize.Big },
            new Animal() { name = "Eagle", food = FoodType.Meat, size = BodySize.Medium },
            new Animal() { name = "Wolf", food = FoodType.Meat, size = BodySize.Medium },
            new Animal() { name = "Mice", food = FoodType.Plants, size = BodySize.Small },
            new Animal() { name = "Ferret", food = FoodType.Meat, size = BodySize.Small },
            new Animal() { name = "Bunny", food = FoodType.Plants, size = BodySize.Small },
            new Animal() { name = "Deer", food = FoodType.Plants, size = BodySize.Medium },
            new Animal() { name = "Croocodile", food = FoodType.Meat, size = BodySize.Big }
        };
    }
}