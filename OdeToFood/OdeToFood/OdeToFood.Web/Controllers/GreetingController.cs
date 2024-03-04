using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Web.Models;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingVM();
            //var name = HttpContext.Request.QueryString["name"]; //en MVC no necesitamos ingresar al context directamente
            model.Name = name ?? "<script>alert('Hi');</script>";
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model );
        }
    }
}