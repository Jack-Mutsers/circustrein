using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class wagonTests
    {

        [TestMethod]
        public void AsignAnimalsToWagon_Success()
        {
            AnimalList animalList = new AnimalList();
            IWagon wagon = new Wagon();

            wagon.AsignAnimalsToWagon(animalList.Animals);

            Assert.AreEqual(10, wagon.usedSpace);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AsignAnimalsToWagon_Failure()
        {
            List<IAnimal> animals = new List<IAnimal>()
            {
                new Animal(){name = "Squirl", food = FoodType.Plants, size = BodySize.Small},
                new Animal(){name = "mice", food = FoodType.Plants, size = BodySize.Small},
                new Animal()
            };

            IWagon wagon = new Wagon();

            wagon.AsignAnimalsToWagon(animals);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsignAnimalsToWagon_EmptyAnimal()
        {
            List<IAnimal> animals = new List<IAnimal>()
            {
                new Animal(){name = "Squirl", food = FoodType.Plants, size = BodySize.Small},
                new Animal(){name = "mice", food = FoodType.Plants, size = BodySize.Small},
                null
            };

            IWagon wagon = new Wagon();

            wagon.AsignAnimalsToWagon(animals);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsignAnimalsToWagon_Empty()
        {
            List<IAnimal> animals = null;

            IWagon wagon = new Wagon();

            wagon.AsignAnimalsToWagon(animals);
        }


    }
}
