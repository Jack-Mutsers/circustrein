using Logic.Models;
using System;
using System.Collections.Generic;

namespace Logic.Interfaces
{
    public interface ITrain
    {
        List<IWagon> wagons { get; }

        Train FillTrainWagons(List<IAnimal> animals);
    }
}
