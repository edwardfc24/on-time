using OnTime.BLL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTime.Controllers
{
    public class HorarioController : Controller
    {
        //
        // GET: /Horario/
        [Authorize]
        public ActionResult Index()
        {
            List<Horario> listaHorarios = HorarioBLL.SelectAll();
            return View(listaHorarios);
        }

        //
        // GET /Horario/Create
        [HttpGet()]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // GET: /Empleado/Create
        [HttpPost()]
        public ActionResult Create(Horario horario)
        {
            HorarioBLL.InsertObjetoHorario(horario);
            return RedirectToAction("Index", "Horario");
        }
    }
}
