using OnTime.BLL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTime.Controllers
{
    public class DepartamentoController : Controller
    {
        //
        // GET: /Departamento/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Departamento> listaDepartamento = DepartamentoBLL.SelectAll();
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
                students = students.Where(s => s.txtNombre.ToUpper().Contains(searchString.ToUpper())
                                       || s.fkJefe.ToString().ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.txtNombre);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.fkJefe);
                    break;
                case "date_desc":                     
                    students = students.OrderByDescending(s => s.fkJefe);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.txtNombre);
                    break;
            }




            return View(students.ToList<Departamento>());




        }
        //
        // GET: /Departamento/Create
        [HttpGet()]
        public ActionResult Create()
        {
            List<Empleado> listaEmpleados = EmpleadoBLL.SelectAll();
            ViewBag.EmpleadoPk = new SelectList(listaEmpleados, "pkEmpleado", "fullName");
            return View();
        }

        //
        // GET: /Departamento/Create
        [HttpPost()]
        public ActionResult Create(Departamento departamento)
        {
            DepartamentoBLL.InsertObjetoDepartamento(departamento);
            return RedirectToAction("Index", "Departamento");
        }

        [Authorize]
        public ViewResult Details(int id)
        {
            Departamento departamento = DepartamentoBLL.GetEmpleadoById(id);
            return View(departamento);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            Departamento departamento = DepartamentoBLL.GetEmpleadoById(id);
            List<Empleado> listaEmpleados = EmpleadoBLL.SelectAll();
            ViewBag.EmpleadoPk = new SelectList(listaEmpleados, "pkEmpleado", "fullName");
            return View(departamento);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartamentoBLL.UpdateDepartamento(departamento);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(departamento);
        }

    }
}
