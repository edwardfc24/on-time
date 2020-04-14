using OnTime.BLL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTime.Controllers
{
    public class TurnoController : Controller
    {

        private static List<HoTurno> turnos = new List<HoTurno>();
        //
        // GET: /Turno/
        [Authorize]
        public ActionResult Index()
        {
            List<Turno> listaTurnos = TurnoBLL.SelectAll();
            return View(listaTurnos);
        }

        //
        // GET: /Turno/Create
        [Authorize]
        public ActionResult Create()
        {
            List<Horario> listaHorarios = HorarioBLL.SelectAll();
            ViewBag.HorarioPk = new SelectList(listaHorarios, "pkHorario", "txtNombre");
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Turno turno)
        {
            int idTurno = TurnoBLL.InsertObjetoTurno(turno);
            foreach (HoTurno relacion in turnos)
            {
                relacion.fkTurno = idTurno;
                HoTurnoBLL.InsertObjetoHoTurno(relacion);
            }
            return RedirectToAction("Index", "Turno");
        }

        [HttpPost]
        public ActionResult GetDatosHorario(int idHorario)
        {
            Horario objCargo = HorarioBLL.GetHorarioById(idHorario);
            return Json(objCargo);
        }

        [HttpPost]
        public void setListaHorarios(List<HoTurno> auxiliar)
        {
            if (auxiliar != null)
            {
                turnos = new List<HoTurno>();
                foreach (HoTurno aux in auxiliar)
                {
                    turnos.Add(aux);
                }
            }
        }
    }
}
