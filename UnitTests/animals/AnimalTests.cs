using Logic;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void ResetToDefault()
        {
            Animal animal = new Herbivour()
            {
                name = "Hippo",
                food = FoodType.Plants,
                size = BodySize.Big
            };

            animal.ResetToDefault();

            Assert.AreEqual("", animal.name);
            Assert.AreEqual(FoodType.Meat, animal.food);
            Assert.AreEqual(BodySize.Small, animal.size);
        }

        [TestMethod]
        public void ValidateValues_success()
        {
            Animal animal = new Herbivour()
            {
                name = "Hippo",
                food = FoodType.Plants,
                size = BodySize.Big
            };

            bool valid = animal.ValidateValues();

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void ValidateValues_Failure()
        {
            Animal animal = new Carnivour();

            bool valid = animal.ValidateValues();

            Assert.IsFalse(valid);
        }
    }
}
