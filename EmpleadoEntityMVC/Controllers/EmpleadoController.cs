

using EmpleadoEntityMVC.Models;
using EmpleadoEntityMVC.Models.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpleadoEntityMVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado

        public ActionResult Index()
        {
            List<ListaEmpleado> datos;
            using (EmpresaEntities db = new EmpresaEntities())
            {
                datos = (from d in db.Empleado
                         select new ListaEmpleado
                         {
                             codigo = d.codigo,
                             nombre = d.nombre,
                             salario = d.salario,
                             fechaingreso = d.fechaingreso
                         }).ToList();
            }
           
            return View(datos);
        }



    

        public ActionResult Nuevo()
        {
            TempData["Message"] = null;
            ViewBag.Message = null;
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(EmpleadoVistaModelo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (EmpresaEntities db = new EmpresaEntities())
                    {
                        var oTabla = new Empleado();
                        oTabla.nombre = model.nombre;
                        oTabla.salario = model.salario;
                        oTabla.fechaingreso = model.fechaingreso;
                        db.Empleado.Add(oTabla);
                        db.SaveChanges();
                        //ViewBag.Message = "Data was saved successfully.";
                        TempData["Message"] = "Registro Guardado Correctamente";
                    }

                    return Redirect("~/Empleado/index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int id)
        {
            TempData["Message"] = null;
            EmpleadoVistaModelo model = new EmpleadoVistaModelo();
            using (EmpresaEntities db = new EmpresaEntities())
            {
                var oTabla = db.Empleado.Find(id);
                model.nombre = oTabla.nombre;
                model.salario = oTabla.salario;
                model.fechaingreso = oTabla.fechaingreso;
                model.codigo = oTabla.codigo;

            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(EmpleadoVistaModelo model)
        {
            try
            {
                ViewBag.showSuccessAlert = false;
                if (ModelState.IsValid)
                {
                    using (EmpresaEntities db = new EmpresaEntities())
                    {
                        var oTabla = db.Empleado.Find(model.codigo);
                        oTabla.nombre = model.nombre;
                        oTabla.salario = model.salario;
                        oTabla.fechaingreso = model.fechaingreso;
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        TempData["Message"] = "Registro Actualizado Correctamente";
                    }
                    return Redirect("~/Empleado/index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            TempData["Message"] = null;

            using (EmpresaEntities db = new EmpresaEntities())
            {
                var oTabla = db.Empleado.Find(id);
                db.Empleado.Remove(oTabla);
                db.SaveChanges();
                TempData["Message"] = "Registro " + id + " Eliminado";
            }
            return Redirect("~/Empleado/index");
        }
     
   
    }
}