using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpleadoEntityMVC.Models.VistaModelo
{
    public class ListaEmpleado
    {
        public int codigo { get; set; }
        
        public string nombre { get; set; }
        
        public decimal salario { get; set; }
        
        public DateTime fechaingreso { get; set; }
    }
}