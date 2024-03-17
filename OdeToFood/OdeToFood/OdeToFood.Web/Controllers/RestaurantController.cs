using System;
using System.Linq;
using System.Web.Mvc;
using OdeToFood.Data.Entities;
using OdeToFood.Data.Services;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantData _data;

        public RestaurantController(IRestaurantData data)
        {
            _data = data;
        }
        // GET: Restaurant
        public ActionResult Index()
        {
            var model = _data.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _data.Get(id);
            if(model == null)
            {
                //return RedirectToAction("Index");
                return View("NotFound");
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            //if (String.IsNullOrEmpty(restaurant.Name))
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            //}


            if (ModelState.IsValid)
            {
                _data.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        public ActionResult Edit(int id)
        {
            var model = _data.Get(id);
            if (model == null)
            {
                return View("NotFound");

            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _data.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _data.Get(id);
            if (model == null)
            {
                return View("NotFound");

            }
            return View(model);
        }

        [HttpPost] //in this case we don't use HttpDelete cuz the browser work like this with the forms
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form) //the second parameter is only for overloading the method (but it also have a use)
        {
                _data.Delete(id);
                return RedirectToAction("Index");
        }


    }
}