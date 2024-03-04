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


    }
}