using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Entities;

namespace OdeToFood.Data.Services
{
    public class ProjectDBContext : DbContext
    {



        public DbSet<Restaurant> Restaurants { get; set;}

    }
}
