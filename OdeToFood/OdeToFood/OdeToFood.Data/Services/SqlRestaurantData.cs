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

            //this is the way to do Optimistic Concurrency and don't let the users override the others code. (the last to click the update wins)
            var entry = _context.Entry(restaurant);//begin the tracking
            entry.State = System.Data.Entity.EntityState.Modified; //the object is in a modified state



            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }
    }
}
