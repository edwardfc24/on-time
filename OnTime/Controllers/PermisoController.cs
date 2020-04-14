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
    public class PermisoController : Controller
    {
        //
        // GET: /Permiso/

        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Permiso> listaDepartamento = PermisoBLL.SelectAll();
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

            var students = from s in listaDepartamento
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.pkPermiso.ToString().ToUpper().Contains(searchString.ToUpper())
                                       || s.txtDescripcion.ToString().ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.pkPermiso);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.txtDescripcion);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.txtDescripcion);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.pkPermiso);
                    break;
            }
            return View(students.ToList<Permiso>());
        }

        //
        // GET: /Vacaciones/Create/
        [Authorize]
        public ActionResult Create()
        {
            List<Empleado> listaEmpleados = EmpleadoBLL.SelectAll();
            ViewBag.EmpleadoPk = new SelectList(listaEmpleados, "pkEmpleado", "fullName");
            return View();
        }

        //
        // GET: /Vacaciones/Create/
        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind(Prefix = "Item1")]Permiso permiso, [Bind(Prefix = "Item2")]EmpPermiso empPermiso)
        {
            empPermiso.fkPermiso = PermisoBLL.InsertObjetoPermiso(permiso);
            EmpPermisoBLL.InsertObjetoEmpPermiso(empPermiso);
            return RedirectToAction("Index", "Permiso");
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

    }
}
