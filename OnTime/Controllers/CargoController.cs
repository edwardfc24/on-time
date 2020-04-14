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
    public class CargoController : Controller
    {
        //
        // GET: /Cargo/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Cargo> listaCargo = CargoBLL.SelectAll();
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

            var students = from s in listaCargo
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.txtNombre.ToUpper().Contains(searchString.ToUpper())
                                       || s.fkDepartamento.ToString().ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.txtNombre);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.fkDepartamento);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.fkDepartamento);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.txtNombre);
                    break;
            }
            return View(students.ToList<Cargo>());
        }

        public ActionResult Create()
        {
            List<Departamento> listaDepartamento = DepartamentoBLL.SelectAll();
            ViewBag.DepartamentoPk = new SelectList(listaDepartamento, "pkDepartamento", "txtNombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cargo cargo)
        {
            CargoBLL.InsertObjetoCargo(cargo);
            return RedirectToAction("Index", "Cargo");
        }


        [Authorize]
        public ViewResult Details(int id)
        {
            Cargo cargo = CargoBLL.GetCargoById(id);
            return View(cargo);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            Cargo departamento = CargoBLL.GetCargoById(id);
            List<Departamento> listaEmpleados = DepartamentoBLL.SelectAll();
            ViewBag.DepartamentoPk = new SelectList(listaEmpleados, "pkDepartamento", "txtNombre");
            
            return View(departamento);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Cargo departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CargoBLL.UpdateCargo(departamento);
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
