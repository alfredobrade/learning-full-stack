using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Data.Services;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData _data;

        public HomeController(IRestaurantData data)
        {
            _data = data;
        }


        public ActionResult Index()
        {
            var list = _data.GetAll();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}