using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Helpers
{
    public class ListSorter
    {
        public List<IAnimal> SortAnimalsForOptimalAssignment(List<IAnimal> animals)
        {
            ListFilters filter = new ListFilters();

            List<IAnimal> MeatEaters = filter.GetCarnivoreList(animals);
            List<IAnimal> PlantEaters = filter.GetHerbivoreList(animals);

            List<IAnimal> SortedMeatEaters = SortAnimalsByBodySize(MeatEaters);
            List<IAnimal> SortedPlantEaters = SortAnimalsByBodySize(PlantEaters);

            return SortedMeatEaters.Concat(SortedPlantEaters).ToList();
        }

        public List<IAnimal> SortAnimalsByBodySize(List<IAnimal> animals)
        {
            return animals.OrderByDescending(a => a.size).ToList();
        }
    }
}
