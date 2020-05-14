﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Circustrein.Logic
{
    public class Animal : INotifyPropertyChanged
    {
        private string _name { get; set; }
        private BodySize _size { get; set; }
        private FoodType _food { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum FoodType
    {
        Meat,
        Plants
    };

    public enum BodySize
    {
        Big = 5,
        Medium = 3,
        Small = 1
    }

    
}
