using Circustrein.Logic;
using System.Collections.Generic;
using System.Windows;

namespace Circustrein
{
    /// <summary>
    /// Interaction logic for TrainWindow.xaml
    /// </summary>
    public partial class TrainWindow : Window
    {
        // create an instance for the list of animals that gets send over
        private List<Animal> animalList;

        public TrainWindow(List<Animal> list)
        {
            InitializeComponent();

            // add the animals that got send over to the list
            animalList = list;

            Train train = new Train();
            train.FillTrainWagons(animalList);

            // assign the train collection to the listbox
            lbWagons.ItemsSource = train.wagons;
        }

    }
}
