using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using OdeToFood.Data.Entities;

namespace OdeToFood.Data.Services
{
    public class InMemomoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemomoryRestaurantData()
        {
            _restaurants = new List<Restaurant>() 
            { 
                new Restaurant() {Id=1,Name="Scott's Pizza",Cuisine=CuisineType.Italian},
                new Restaurant() {Id=2,Name="Tersiguels",Cuisine=CuisineType.French},
                new Restaurant() {Id=1,Name="Mango Grove",Cuisine=CuisineType.Indian},
                //new Restaurant() {Id=1,Name="Scott's Pizza",Cuisine=CuisineType.Italian},
                //new Restaurant() {Id=1,Name="Scott's Pizza",Cuisine=CuisineType.Italian},
                //new Restaurant() {Id=1,Name="Scott's Pizza",Cuisine=CuisineType.Italian},

            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(x => x.Id) + 1;
            _restaurants.Add(restaurant);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(x => x.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var model = Get(restaurant.Id);
            if (model != null)
            {
                model.Name = restaurant.Name;
                model.Cuisine = restaurant.Cuisine;
            }
        }

        
    }
}
