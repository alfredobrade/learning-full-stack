using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


//adding for using WebApis
using System.Web.Http;
//using System.Web.Routing;

namespace OdeToFood.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //adding configuration for WebApis avobe of the Routing
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Adding the Dependency Injection Container for IoC
            //ContainerConfig.RegisterContainer(); //este usabamos cuando era solo MVC
            //vamos a configurar con el mismo container, pasandole GlobalConfiguration.Configuration para que tambien reconozca WebApi
            ContainerConfig.RegisterContainer(GlobalConfiguration.Configuration);
        }
    }
}
