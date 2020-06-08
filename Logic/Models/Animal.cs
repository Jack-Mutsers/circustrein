using Logic.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic.Models
{
    public abstract class Animal : INotifyPropertyChanged
    {
        private string _name { get; set; } = "";
        private BodySize _size { get; set; } = BodySize.Small;
        private FoodType _food { get; set; } = FoodType.Meat;

        public string name 
        { 
            get { return _name; }
            set {

                if (value == null)
                    throw new ArgumentNullException();

                _name = value; 
                OnPropertyChanged(); 
            } 
        }

        public BodySize size
        {
            get { return _size; }
            set { _size = value; OnPropertyChanged(); }
        }

        public FoodType food
        {
            get { return _food; }
            set { _food = value; OnPropertyChanged(); }
        }

        public Animal()
        {
            ResetToDefault();
        }

        public void ResetToDefault()
        {
            // empty the animal name
            name = "";

            // set the foodType to meat
            food = FoodType.Meat;

            // set the bodySize to small
            size = BodySize.Small;
        }

        public bool ValidateValues()
        {
            if (_name == "")
                return false;

            return true;
        }

        public abstract bool CheckIfAllowed(Animal animal);

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    
}
