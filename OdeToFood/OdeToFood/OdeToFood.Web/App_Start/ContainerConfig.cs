using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;

namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        //esto lo hace con una libreria que se llama autofac
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            //primero crea el Container Builder y despues y luego agrega todas las abstracciones
            var builder = new ContainerBuilder();

            // este es un extension custom para integrar MVC en el Contenerdor con Autofac
            builder.RegisterControllers(typeof(MvcApplication).Assembly); //Le decimos a la libreria donde buscar el Assembly de la aplicacion web MVC


            builder.RegisterType<InMemomoryRestaurantData>().As<IRestaurantData>() //aca creamos la referencia
                .SingleInstance();//solo para prueba NO SIRVE PARA MULTIPLES USUARIOS - singleton
                //.InstancePerRequest();


            //builder.RegisterType<SqlRestaurantData>()
            //    .As<IRestaurantData>()
            //    //.SingleInstance();
            //    .InstancePerRequest();



            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //metodo de MVC5 donde paso el container con los builders que hice con Autofac
            //le pasa el container con un wrapper de autofac (AutofacDependencyResolver)

            //una vez que pasamos por parametro HttpConfiguration que son las configuraciones de WebApi, ahora hacemos un nuevo DependencyResolver
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}