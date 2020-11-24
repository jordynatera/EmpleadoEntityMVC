using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpleadoEntityMVC.Models.VistaModelo
{
    public class EmpleadoVistaModelo
    {
        public int codigo { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Salario")]
        public decimal salario { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaingreso { get; set; }
    }
}