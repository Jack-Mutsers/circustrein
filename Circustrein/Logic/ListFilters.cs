using System.Collections.Generic;
using System.Linq;

namespace Circustrein.Logic
{
    public class ListFilters
    {
        public List<Animal> GetCarnivoreList(List<Animal> animals)
        {
            // return a list of only meat eaters
            var query = animals.Where(a => a.food == FoodType.Meat).OrderByDescending(a => a.size);

            return query.ToList();
        }

        public List<Animal> GetOmnivoreList(List<Animal> animals)
        {
            // return a list of only plant eaters
            var query = animals.Where(a => a.food == FoodType.Plants).OrderByDescending(a => a.size);

            return query.ToList();
        }

    }
}
