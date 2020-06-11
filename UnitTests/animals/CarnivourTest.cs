using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class CarnivourTest
    {
        [TestMethod]
        public void CheckIfAllowedTest_Happy_Planteater_LargerSize()
        {
            IAnimal animal = new Carnivour()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            IAnimal newAnimal = new Herbivour()
            {
                name = "Elephant",
                food = FoodType.Plants,
                size = BodySize.Big
            };

            bool allowed = animal.CheckIfAllowed(newAnimal);

            Assert.IsTrue(allowed);
        }

        [TestMethod]
        public void CheckIfAllowedTest_Happy_Planteater_SameSize()
        {
            Animal animal = new Carnivour()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            Animal newAnimal = new Herbivour()
            {
                name = "deer",
                food = FoodType.Plants,
                size = BodySize.Medium
            };

            bool allowed = animal.CheckIfAllowed(newAnimal);

            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void CheckIfAllowedTest_Happy_Planteater_SmallerSize()
        {
            Animal animal = new Carnivour()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            Animal newAnimal = new Herbivour()
            {
                name = "mice",
                food = FoodType.Plants,
                size = BodySize.Small
            };

            bool allowed = animal.CheckIfAllowed(newAnimal);

            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void CheckIfAllowedTest_Happy_Meateater_LargerSize()
        {
            Animal animal = new Carnivour()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            Animal newAnimal = new Carnivour()
            {
                name = "Lion",
                food = FoodType.Meat,
                size = BodySize.Big
            };

            bool allowed = animal.CheckIfAllowed(newAnimal);

            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void CheckIfAllowedTest_Happy_Meateater_SameSize()
        {
            Animal animal = new Carnivour()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            Animal newAnimal = new Carnivour()
            {
                name = "Eagel",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            bool allowed = animal.CheckIfAllowed(newAnimal);

            Assert.IsFalse(allowed);
        }

        [TestMethod]
        public void CheckIfAllowedTest_Happy_Meateater_SmallerSize()
        {
            Animal animal = new Carnivour()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            Animal newAnimal = new Carnivour()
            {
                name = "Feret",
                food = FoodType.Meat,
                size = BodySize.Small
            };

            bool allowed = animal.CheckIfAllowed(newAnimal);

            Assert.IsFalse(allowed);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckIfAllowedTest_Failure_null()
        {
            Animal animal = new Carnivour()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            Animal newAnimal = null;

            bool allowed = animal.CheckIfAllowed(newAnimal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfAllowedTest_Failure_empty()
        {
            Animal animal = new Carnivour()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            Animal newAnimal = new Carnivour();

            bool allowed = animal.CheckIfAllowed(newAnimal);
        }
    }
}
