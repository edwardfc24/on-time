using OnTime.BLL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnTime.Controllers
{
    public class EmpleadoController : Controller
    {

        private static List<EmpCargo> cargos = new List<EmpCargo>();
        private static List<HoTurno> turnos = new List<HoTurno>();
        //
        // GET: /Empleado/
        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<Empleado> listaEmpleado = EmpleadoBLL.SelectAll();
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

            var empleados = from s in listaEmpleado
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                empleados = empleados.Where(s => s.txtNombre.ToUpper().Contains(searchString.ToUpper())
                                       || s.txtApellidos.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    empleados = empleados.OrderByDescending(s => s.txtNombre);
                    break;
                case "Date":
                    empleados = empleados.OrderBy(s => s.dateFechaContrato);
                    break;
                case "date_desc":
                    empleados = empleados.OrderByDescending(s => s.dateFechaContrato);
                    break;
                default:  // Name ascending 
                    empleados = empleados.OrderBy(s => s.txtNombre);
                    break;
            }
            return View(empleados.ToList<Empleado>());
        }
        //
        // GET: /Empleado/Create

        [HttpGet()]
        [Authorize]
        public ActionResult Create()
        {
            List<Departamento> listaDepartamento = DepartamentoBLL.SelectAll();
            ViewBag.DepartamentoPk = new SelectList(listaDepartamento, "pkDepartamento", "txtNombre");
            List<Cargo> listaCargo = new List<Cargo>();
            ViewBag.CargoPk = new SelectList(listaCargo, "pkCargo", "txtNombre");
            List<Horario> listaHorarios = HorarioBLL.SelectAll();
            ViewBag.HorarioPk = new SelectList(listaHorarios, "pkHorario", "txtNombre");
            return View();
        }

        //
        // GET: /Empleado/Create
        [HttpPost()]
        public ActionResult Create([Bind(Prefix = "Item1")]Empleado empleado, [Bind(Prefix = "Item2")]Turno turno)
        {
            int idEmpleado = EmpleadoBLL.InsertObjetoEmpleado(empleado);
            try
            {
                foreach (EmpCargo relacion in cargos)
                {
                    relacion.fkEmpleado = idEmpleado;
                    EmpCargoBLL.InsertObjetoEmpCargo(relacion);
                }
            }
            catch
            {

            }

            int idTurno = TurnoBLL.InsertObjetoTurno(turno);
            try
            {
                foreach (HoTurno relacion in turnos)
                {
                    relacion.fkTurno = idTurno;
                    int idHOT = HoTurnoBLL.InsertObjetoHoTurno(relacion);
                    HTEmpleado htEmpleado = new HTEmpleado();
                    htEmpleado.fkEmpleado = idEmpleado;
                    htEmpleado.fkHoTurno = idHOT;
                    HTEmpleadoBLL.InsertObjetoHTEmpleado(htEmpleado);
                }
            }
            catch
            {

            }

            return RedirectToAction("Index", "Empleado");
        }

        [HttpPost]
        public ActionResult GetCargosByIdDpto(int idDpto)
        {
            List<Cargo> objCargo = CargoBLL.GetCargosByIdDpto(idDpto);
            SelectList listCargos = new SelectList(objCargo, "pkCargo", "txtNombre");
            return Json(listCargos);
        }

        [Authorize]
        public ViewResult Details(int id)
        {
            Empleado empleado = EmpleadoBLL.GetEmpleadoById(id);
            return View(empleado);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Empleado empleado = EmpleadoBLL.GetEmpleadoById(id);
            return View(empleado);
        }

        //
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpleadoBLL.UpdateEmpleado(empleado);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "No fue posible guardar la información, contacte con el administrador.");
            }
            return View(empleado);
        }

        [HttpPost]
        public void setListaCargos(List<EmpCargo> auxiliar)
        {
            if (auxiliar != null)
            {
                cargos = new List<EmpCargo>();
                foreach (EmpCargo aux in auxiliar)
                {
                    cargos.Add(aux);
                }
            }
        }

        [HttpPost]
        public void setListaHorarios(List<HoTurno> horarios)
        {
            if (horarios != null)
            {
                turnos = new List<HoTurno>();
                foreach (HoTurno aux in horarios)
                {
                    turnos.Add(aux);
                }
            }
        }

        [Authorize]
        public ActionResult EditSolo()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string name = ticket.Name;
            int User = Convert.ToInt32(name);
            Empleado emp = EmpleadoBLL.GetEmpleadoById(User);
            return View(emp);
        }

        [HttpPost]
        public ActionResult EditSolo(Empleado empleado)
        {
            try
            {
                    EmpleadoBLL.UpdateEmpleado(empleado);
                    return RedirectToAction("Index", "Admin");
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "No fue posible guardar la información, contacte con el administrador.");
            }
            return View(empleado);
        }

    }
}
