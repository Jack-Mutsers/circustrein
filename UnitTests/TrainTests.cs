using Logic.Interfaces;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void TestFillTrainWagon_Success()
        {
            AnimalList List = new AnimalList();
            List<IAnimal> animalList = List.Animals;

            ITrain train = new Train();
            train.FillTrainWagons(animalList);

            Assert.AreEqual(7, train.wagons.Count, "The amount of wagons for the train is incorect");
            Assert.AreEqual(4, train.wagons[0].animals.Count, "The animal count for wagon one is incorrect");
            Assert.AreEqual(1, train.wagons[1].animals.Count, "The animal count for wagon two is incorrect");
            Assert.AreEqual(1, train.wagons[2].animals.Count, "The animal count for wagon three is incorrect");
            Assert.AreEqual(1, train.wagons[3].animals.Count, "The animal count for wagon four is incorrect");
            Assert.AreEqual(1, train.wagons[4].animals.Count, "The animal count for wagon five is incorrect");
            Assert.AreEqual(2, train.wagons[5].animals.Count, "The animal count for wagon six is incorrect");
            Assert.AreEqual(1, train.wagons[6].animals.Count, "The animal count for wagon seven is incorrect");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FillTrainWagon_Null()
        {
            List<IAnimal> animalList = null;

            ITrain train = new Train();
            train.FillTrainWagons(animalList);
        }

        [TestMethod]
        public void FillTrainWagon_Empty()
        {
            List<IAnimal> animalList = new List<IAnimal>();

            ITrain train = new Train();
            train.FillTrainWagons(animalList);

            Assert.AreEqual(0, train.wagons.Count, "The amount of wagons for the train is incorect");
        }
    }
}
