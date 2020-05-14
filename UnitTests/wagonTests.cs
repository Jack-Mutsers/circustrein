using System;
using System.Collections.Generic;
using System.Linq;
using Circustrein.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class wagonTests
    {

        [TestMethod]
        public void TestAnimalSizeCompairedToMeatEater()
        {
            AnimalList List = new AnimalList();
            List<Animal> animalList = List.Animals;

            Train train = new Train();
            train.FillTrainWagons(animalList);

            // loop trough the train to get to all wagons
            foreach (Wagon trainWagon in train.wagons)
            {
                // Convert the trainWagon into a list object
                List<Animal> wagon = trainWagon.animals;

                // check if there is a meat eater assigned to the wagon
                bool meatEaterInWagon = trainWagon.CheckForMeatEater();

                // is there a meat eater assigned to the wagon?
                if (meatEaterInWagon)
                {
                    // there is a meat eater assigned to the wagon
                    // get the size of the meat eater in this train wagon
                    BodySize size = trainWagon.GetMeatEaterSize();

                    // count how many animals in the wagon are of the same or smaller size than the meateater
                    int meatEaterSizeCount = wagon.Where(a => a.size == size || a.size < size).Count();

                    // assert if the meat eater is the smallest animal in the train wagon
                    Assert.AreEqual(1, meatEaterSizeCount, "Meat eater is bigger or the same size as another animal in the wagon");
                }
            }
        }

        [TestMethod]
        public void TestForOptimalWagonsUse()
        {
            AnimalList List = new AnimalList();
            List<Animal> animalList = List.Animals;

            Train train = new Train();
            train.FillTrainWagons(animalList);

            bool optimised = TestWagonOptimacy(train);
            Assert.IsTrue(optimised, "wagons are not properly filled");
        }

        [TestMethod]
        public void AddToWagon_Happy()
        {
            Animal animal = new Animal()
            {
                food = FoodType.Meat,
                name = "Lion",
                size = BodySize.Big
            };

            Wagon wagon = new Wagon();
            wagon.AddToWagon(animal);

            Assert.AreEqual(1, wagon.animals.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddToWagon_null()
        {
            Animal animal = null;

            Wagon wagon = new Wagon();
            wagon.AddToWagon(animal);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToWagon_IncorrectValues()
        {
            Animal animal = new Animal();

            Wagon wagon = new Wagon();
            wagon.AddToWagon(animal);
        }

        [TestMethod]
        public void CheckIfFits_Happy_Small()
        {
            Animal animal = new Animal()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            BodySize animalSize = BodySize.Small;
            Wagon wagon = new Wagon();
            wagon.AddToWagon(animal);

            bool result = wagon.CheckIfFits(animalSize);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfFits_Happy_Medium()
        {
            Animal animal = new Animal()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            BodySize animalSize = BodySize.Medium;
            Wagon wagon = new Wagon();
            wagon.AddToWagon(animal);

            bool result = wagon.CheckIfFits(animalSize);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfFits_Happy_Big()
        {
            Animal animal = new Animal()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            BodySize animalSize = BodySize.Big;
            Wagon wagon = new Wagon();
            wagon.AddToWagon(animal);

            bool result = wagon.CheckIfFits(animalSize);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddMeatEaters_Happy(List<Animal> meatEaters)
        {
            Animal animal = new Animal()
            {
                name = "Wolf",
                food = FoodType.Meat,
                size = BodySize.Medium
            };

            Wagon wagon = new Wagon();
            wagon.AddToWagon(animal);

            List<Animal> animals = new List<Animal>() { 
                new Animal()
                {
                    name = "tiger",
                    food = FoodType.Meat,
                    size = BodySize.Big
                },
                new Animal()
                {
                    name = "feret",
                    food = FoodType.Meat,
                    size = BodySize.Small
                }
            };

            wagon.AddMeatEaters(animals);

            Assert.AreEqual(1, wagon.animals.Count());
        }

        [TestMethod]
        public void AddPlantEaters(List<Animal> plantEaters)
        {

        }


        public bool TestWagonOptimacy(Train train)
        {
            // loop though all wagons
            for (int i = 0; i < train.wagons.Count(); i++)
            {
                Wagon wagon = train.wagons[i];

                // loop through all wagons to come
                for (int j = (i + 1); j < train.wagons.Count(); j++)
                {
                    Wagon nextWagon = train.wagons[j];

                    // loop through all animals in the current wagon to come
                    foreach (Animal animal in nextWagon.animals)
                    {

                        // check if there is enough space left for this animal to fit
                        if ((wagon.usedSpace + (int)animal.size) <= wagon.maxSize)
                        {

                            bool hasMeatEater = wagon.CheckForMeatEater();
                            // the wagon has a meat eater and the current animal is not a meat eater
                            if (hasMeatEater && animal.food == FoodType.Plants)
                            {
                                BodySize meatEaterSize = wagon.GetMeatEaterSize();

                                if (meatEaterSize < animal.size)
                                {
                                    return false;
                                }
                            }
                            // the wagon has no meat eater but the current animal is a meat eater
                            else if (!hasMeatEater && animal.food == FoodType.Meat)
                            {
                                // check size of meat eater compaired to the smalest animal in the wagon
                                BodySize smallestSize = wagon.GetSmalestAnimalSize();

                                if (smallestSize > animal.size)
                                {
                                    return false;
                                }
                            }
                            // the wagon has no meat eater and the curren animal is not a meat eater
                            else if (!hasMeatEater && animal.food == FoodType.Plants)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }


    }
}
