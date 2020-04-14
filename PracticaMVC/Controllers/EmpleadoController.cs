using PracticaMVC.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaMVC.Models
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/

        public ActionResult Index()
        {
            List<Empleados> listaempleados = EmpleadosBLL.SelectAll();
            return View("Index",listaempleados);
        }
        //
        // GET: /Empleado/Create
        [HttpGet()]
        public ActionResult Create()
        {
                return View();  
        }
        //
        // GET: /Empleado/Create
        [HttpPost()]
        public ActionResult Create(Empleados empleado)
        {
            EmpleadosBLL.Insert(empleado);

            if (!ModelState.IsValid)
            {
                return View(empleado);
            }
            
            return RedirectToAction("Index");
        }
    }
}
