using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Helpers
{
    public class ListSorter
    {
        public List<Animal> SortAnimalsForOptimalAssignment(List<Animal> animals)
        {
            ListFilters filter = new ListFilters();

            List<Animal> MeatEaters = filter.GetCarnivoreList(animals);
            List<Animal> PlantEaters = filter.GetHerbivoreList(animals);

            List<Animal> SortedMeatEaters = SortAnimalsByBodySize(MeatEaters);
            List<Animal> SortedPlantEaters = SortAnimalsByBodySize(PlantEaters);

            return SortedMeatEaters.Concat(SortedPlantEaters).ToList();
        }

        public List<Animal> SortAnimalsByBodySize(List<Animal> animals)
        {
            return animals.OrderByDescending(a => a.size).ToList();
        }
    }
}
