using Logic.Helpers;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            List<Animal> animalList = List.UnsortedAnimals;

            // get all carnivores from the animal list
            List<Animal> meatEaters = alterList.GetCarnivoreList(animalList);

            Assert.AreEqual(6, meatEaters.Count, "There are more or less animals in the meat eater list than there should be");
        }

        [TestMethod]
        public void TestGetPlantEaters()
        {
            ListFilters alterList = new ListFilters();
            AnimalList List = new AnimalList();
            List<Animal> animalList = List.UnsortedAnimals;

            // get all omnivores from the animal list
            List<Animal> plantEaters = alterList.GetHerbivoreList(animalList);

            Assert.AreEqual(5, plantEaters.Count, "There are more or less animals in the plant eater list than there should be");
        }
    }
}
