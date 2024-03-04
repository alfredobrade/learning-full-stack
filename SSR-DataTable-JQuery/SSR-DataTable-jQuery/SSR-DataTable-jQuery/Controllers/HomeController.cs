using Microsoft.AspNetCore.Mvc;
using SSR_DataTable_jQuery.Models;
using System.Diagnostics;

namespace SSR_DataTable_jQuery.Controllers
{
    public class HomeController : Controller
    {
        private readonly DevelopDBContext _dbContext;
        public HomeController(DevelopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerEmpleado()
        {

            //Representa el numero de veces que se ha realizado una peticion
            int NroPeticion = Convert.ToInt32(Request.Form["draw"].FirstOrDefault() ?? "0");
            //cuantos registros va a devolver
            int CantidadRegistros = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
            //cuantos registros va a omitir (los que ya mostró en la pagina anterior y anteriores)
            int OmitirRegistros = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
            //texto de busqueda 
            string ValorBusqueda = Request.Form["search[value"].FirstOrDefault() ?? "";
            //esas cosas mostró en el video pero no tiene idea. preguntar a chatgpt

            List<Empleado> list = new List<Empleado>();

            IQueryable<Empleado> queryEmpleado = _dbContext.Empleados; //select * from empleado

            //totalde registros antes de filtrar
            int TotalRegistros = queryEmpleado.Count();

            queryEmpleado = queryEmpleado.Where(e  => string.Concat(e.Nombre,e.CorreoElectronico,e.Domicilio,e.Telefono).Contains(ValorBusqueda));

            int TotalRegistrosFiltrados = queryEmpleado.Count();

            list = queryEmpleado.Skip(OmitirRegistros).Take(CantidadRegistros).ToList();


            //return Json(list);
            return Json(new {
                drow = NroPeticion,
                recordsTotal = TotalRegistros,
                recordsFiltered = TotalRegistrosFiltrados,
                data = list
            }); //esta es la estructura que espera datatable para recibir los datos
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
