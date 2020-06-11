using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface IWagon
    {
        IEnumerable<IAnimal> animals { get; }
        int maxSize { get; }
        int usedSpace { get; }

        void AsignAnimalsToWagon(List<IAnimal> animalList);
    }
}
