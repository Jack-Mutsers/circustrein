using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface ITrain
    {
        List<IWagon> trainWagons { get; }

        void FillTrainWagons(List<IAnimal> animals);
    }
}
