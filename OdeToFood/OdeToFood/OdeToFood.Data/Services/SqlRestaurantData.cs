using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Entities;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly ProjectDBContext _context;

        public SqlRestaurantData(ProjectDBContext context) 
        {
            _context = context;
        }
        public void Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges(); //dice que usa unit of work pattern
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(x => x.Name);
        }

        public void Update(Restaurant restaurant)
        {
            //_context.Restaurants.AddOrUpdate(restaurant);
            var entry = _context.Entry(restaurant);
            entry.State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
