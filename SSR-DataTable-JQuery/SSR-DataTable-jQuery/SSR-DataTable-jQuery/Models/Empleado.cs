using System;
using System.Collections.Generic;

namespace SSR_DataTable_jQuery.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
    }
}
