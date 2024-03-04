using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayAttribute(Name = "type of food")]
        public CuisineType Cuisine { get; set; }
    }
}
