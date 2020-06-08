using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IWagon
    {
        IEnumerable<Animal> animals { get; }
        int maxSize { get; }
        int usedSpace { get; }

        void AsignAnimalsToWagon(List<Animal> animalList);
    }
}
