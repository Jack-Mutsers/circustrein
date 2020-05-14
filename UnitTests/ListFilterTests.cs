using System;
using System.Collections.Generic;
using Circustrein.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ListFilterTests
    {
        [TestMethod]
        public void TestGetMeatEaters()
        {
            ListFilters alterList = new ListFilters();
            AnimalList List = new AnimalList();
            List<Animal> animalList = List.Animals;

            // get all carnivores from the animal list
            List<Animal> meatEaters = alterList.GetCarnivoreList(animalList);

            Assert.AreEqual(6, meatEaters.Count, "There are more or less animals in the meat eater list than there should be");
        }

        [TestMethod]
        public void TestGetPlantEaters()
        {
            ListFilters alterList = new ListFilters();
            AnimalList List = new AnimalList();
            List<Animal> animalList = List.Animals;

            // get all omnivores from the animal list
            List<Animal> plantEaters = alterList.GetOmnivoreList(animalList);

            Assert.AreEqual(5, plantEaters.Count, "There are more or less animals in the plant eater list than there should be");
        }
    }
}
