using OnTime.BLL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnTime.Controllers
{
    public class VacacionesController : Controller
    {
        //
        // GET: /Vacaciones/
        [Authorize]
       public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Vacacion> listaDepartamento = VacacionBLL.SelectAll();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var students = from s in  listaDepartamento
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.fkEmpleado.ToString().ToUpper().Contains(searchString.ToUpper())
                                       || s.dateFechaInicio.ToString().ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.fkEmpleado);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.dateFechaInicio);
                    break;
                case "date_desc":                     
                    students = students.OrderByDescending(s => s.dateFechaInicio);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.fkEmpleado);
                    break;
            }
            return View(students.ToList<Vacacion>());
        }

        //
        // GET: /Vacaciones/Create/
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /Vacaciones/Create/
        [Authorize]
        [HttpPost]
        public ActionResult Create(Vacacion vacacion)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string name = ticket.Name;
            vacacion.fkAutorizacion = Convert.ToInt32(name);
            VacacionBLL.InsertObjetoVacacion(vacacion);
            return RedirectToAction("Index", "Vacaciones");
        }

        [HttpPost]
        public ActionResult AutoCompleteEmpleados(string term)
        {
            IEnumerable<Empleado> listaEmpleado = EmpleadoBLL.SelectAll();
            var empleados = from s in listaEmpleado
                            select s;
            if (!String.IsNullOrEmpty(term))
            {
                empleados = empleados.Where(s => s.txtNombre.ToUpper().Contains(term.ToUpper())
                                       || s.txtApellidos.ToUpper().Contains(term.ToUpper()));
            }
            return Json(empleados.ToList<Empleado>());
        }

        [Authorize]
        public ViewResult Details(int id)
        {
            Vacacion departamento = VacacionBLL.GetVacacionById(id);
            return View(departamento);
        }
        //[Authorize]
        //public ActionResult Edit(int id)
        //{
        //    Vacacion departamento = VacacionBLL.GetVacacionById(id);
        //    List<Empleado> listaEmpleados = EmpleadoBLL.SelectAll();
        //    ViewBag.EmpleadoPk = new SelectList(listaEmpleados, "pkEmpleado", "fullName");
        //    return View(departamento);
        //}

        ////
        //// POST: /Student/Edit/5

        //[HttpPost]
        //public ActionResult Edit(Vacacion departamento)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            VacacionBLL..UpdateDepartamento(departamento);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (DataException /* dex */)
        //    {
        //        //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
        //        ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        //    }
        //    return View(departamento);
        //}

    }
}
