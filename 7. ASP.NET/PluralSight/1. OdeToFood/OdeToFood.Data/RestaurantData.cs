using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurants> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurants> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurants>()
            {
                new Restaurants {Id = 1, Name = "Scott's Pizza", Location ="Maryland", Cusine = CuisineType.Italian},
                new Restaurants {Id = 2, Name = "Haralds Snabbmat", Location ="Tvååker", Cusine = CuisineType.Mexian},
                new Restaurants {Id = 1, Name = "RörmockarNs fynd", Location ="Tjottahejti", Cusine = CuisineType.Indian},
            };
        }
        public IEnumerable<Restaurants> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
