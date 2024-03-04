using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantController : ApiController
    {
        public readonly IRestaurantData _db;
        public RestaurantController(IRestaurantData db) 
        {
            _db = db;
        }   
    }
}
