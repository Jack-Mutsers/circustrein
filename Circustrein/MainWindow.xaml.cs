using Logic;
using Logic.Helpers;
using Logic.Interfaces;
using Logic.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Circustrein
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // create an animal list collection, so we can display all the animals that have been added in a automaticaly updating list
        private ObservableCollection<Animal> animalList = new ObservableCollection<Animal>();

        // create the getter and setter for the animal list, that is only availible for the window and the window class
        internal ObservableCollection<Animal> AnimalList { get => animalList; set => animalList = value; }

        // create an animal instance to bind the input fields to
        private Animal animal = new Carnivour();

        public MainWindow()
        {
            InitializeComponent();

            // set the datacontext, so we can easly bind the input fields to the animal instance
            DataContext = animal;

            // set the animal list as the source of the listview, so we can display the contents of the animal list in the listview
            lv.ItemsSource = AnimalList;

            // create some animals, so we dont have to spend more time to add new animals
            GetDefaultAnimals();
        }

        private void AddNewAnimal_Click(object sender, RoutedEventArgs e)
        {
            // check if the animal name is not left empty
            if (animal.name != null)
            {
                // add the newly added animal to the animal list
                if (animal.food == FoodType.Meat)
                    AddCarnivourToList();
                else
                    AddHerbivourToList();

                // reset the input fields
                animal.ResetToDefault();
            }
        }

        private void AddCarnivourToList()
        {
            AnimalList.Add(new Carnivour()
            {
                name = animal.name,
                food = animal.food,
                size = animal.size
            });
        }

        private void AddHerbivourToList()
        {
            AnimalList.Add(new Herbivour()
            {
                name = animal.name,
                food = animal.food,
                size = animal.size
            });
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            ListSorter sorter = new ListSorter();
            List<Animal> animals = sorter.SortAnimalsForOptimalAssignment(AnimalList.ToList());

            // pass on the animal list to the train view
            TrainWindow train = new TrainWindow(animals);

            // show the train window
            train.Show();

            // clist this window
            this.Close();
        }

        private void GetDefaultAnimals()
        {
            // add some animals to the animal list
            animalList.Add(new Herbivour() { name = "Ape", food = FoodType.Plants, size = BodySize.Medium });
            animalList.Add(new Herbivour() { name = "Elaphant", food = FoodType.Plants, size = BodySize.Big });
            animalList.Add(new Carnivour() { name = "Lion", food = FoodType.Meat, size = BodySize.Big });
            animalList.Add(new Carnivour() { name = "Tiger", food = FoodType.Meat, size = BodySize.Big });
            animalList.Add(new Carnivour() { name = "Eagle", food = FoodType.Meat, size = BodySize.Medium });
            animalList.Add(new Carnivour() { name = "Wolf", food = FoodType.Meat, size = BodySize.Medium });
            animalList.Add(new Carnivour() { name = "Ferret", food = FoodType.Meat, size = BodySize.Small });
            animalList.Add(new Herbivour() { name = "Mice", food = FoodType.Plants, size = BodySize.Small });
            animalList.Add(new Herbivour() { name = "Bunny", food = FoodType.Plants, size = BodySize.Small });
            animalList.Add(new Herbivour() { name = "Deer", food = FoodType.Plants, size = BodySize.Medium });
        }
    }
}
