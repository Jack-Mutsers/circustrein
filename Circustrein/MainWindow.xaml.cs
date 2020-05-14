using Circustrein.Logic;
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
        private Animal animal = new Animal();

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
                AnimalList.Add(new Animal()
                {
                    name = animal.name,
                    food = animal.food,
                    size = animal.size
                });

                // reset the input fields
                animal.ResetToDefault();
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            // pass on the animal list to the train view
            TrainWindow train = new TrainWindow(AnimalList.ToList());

            // show the train window
            train.Show();

            // clist this window
            this.Close();
        }

        private void GetDefaultAnimals()
        {
            // add some animals to the animal list
            animalList.Add(new Animal() { name = "Ape", food = FoodType.Plants, size = BodySize.Medium });
            animalList.Add(new Animal() { name = "Elaphant", food = FoodType.Plants, size = BodySize.Big });
            animalList.Add(new Animal() { name = "Lion", food = FoodType.Meat, size = BodySize.Big });
            animalList.Add(new Animal() { name = "Tiger", food = FoodType.Meat, size = BodySize.Big });
            animalList.Add(new Animal() { name = "Eagle", food = FoodType.Meat, size = BodySize.Medium });
            animalList.Add(new Animal() { name = "Wolf", food = FoodType.Meat, size = BodySize.Medium });
            animalList.Add(new Animal() { name = "Ferret", food = FoodType.Meat, size = BodySize.Small });
            animalList.Add(new Animal() { name = "Mice", food = FoodType.Plants, size = BodySize.Small });
            animalList.Add(new Animal() { name = "Bunny", food = FoodType.Plants, size = BodySize.Small });
            animalList.Add(new Animal() { name = "Deer", food = FoodType.Plants, size = BodySize.Medium });
        }
    }
}
