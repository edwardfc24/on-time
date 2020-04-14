using OnTime.BLL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnTime.Controllers.MarcadoAsistencia
{
    public class MarcadorController : Controller
    {
        private static Empleado currentUser = new Empleado();

        //
        // GET: /Marcador/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.Marcador user)
        {
            if (ModelState.IsValid) //Verificar que el modelo de datos sea válido en cuanto a la definición de las propiedades
            {
                Empleado inSession = Isvalid(user.TxtCI);
                if (inSession != null)//Verificar que el name y clave exista utilizando el método privado
                {
                    FormsAuthentication.SetAuthCookie(inSession.txtCI.ToString(), false); //crea variable de usuario con el correo del usuario
                    currentUser = inSession;
                    return RedirectToAction("Registro", "Marcador");//dirigir al controlador home vista Index una vez se a autenticado en el sistema
                }
                else
                {
                    ModelState.AddModelError("", "Los datos para el Login son incorrectos"); //adicionar mensaje de error al model
                }
            }
            return View(user);
        }
        /// <summary>
        /// Cerrar sesión del usuario autenticado
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private Empleado Isvalid(string ci)
        {
            Empleado actual = EmpleadoBLL.GetEmpleadoByCI(ci);
            return actual;
        }
        [Authorize]
        [HttpGet]
        public ActionResult Registro()
        {
            List<RegDiario> listaHorarios = RegDiarioBLL.GetHorariosByIDEmpleado(currentUser.pkEmpleado);
            int contador = 0;
            int posicion = -1;
            var date = DateTime.Now;
            string hora = date.Hour + ":" + date.Minute + ":" + date.Second;
            foreach (RegDiario reg in listaHorarios)
            {
                string[] timeEntrada = reg.tHoraEntrada.Split(':');
                string[] timeSalida = reg.tHoraSalida.Split(':');
                var auxEntrada = new DateTime(date.Year, date.Month, date.Day, Convert.ToInt32(timeEntrada[0]), Convert.ToInt32(timeEntrada[1]), Convert.ToInt32(timeEntrada[2]));
                var auxSalida = new DateTime(date.Year, date.Month, date.Day, Convert.ToInt32(timeSalida[0]), Convert.ToInt32(timeSalida[1]), Convert.ToInt32(timeSalida[2]));
                if (date >= auxEntrada)
                {
                    if (date <= auxSalida)
                    {
                        if (reg.tHoraEntradaReal.Equals("00:00:00"))
                        {
                            posicion = contador;
                            RegDiarioBLL.UpdateRegDiario(reg.pkRegDiario, hora, 1);
                            break;
                        }
                        else
                        {
                            posicion = contador;
                            RegDiarioBLL.UpdateRegDiario(reg.pkRegDiario, hora, 2);
                            break;
                        }
                    }
                }
                contador++;
            }
            List<EmpMensaje> relMensajes = EmpMensajeBLL.GetMensajePkByIdEmpleado(currentUser.pkEmpleado);
            List<Mensaje> mensajes = new List<Mensaje>();
            foreach (EmpMensaje relacion in relMensajes)
            {
                mensajes.Add(MensajeBLL.GetMensajeById(relacion.fkMensaje));
            }
            ViewBag.NameEmpleado = currentUser.fullName;
            ViewBag.HorarioSelect = posicion;
            ViewBag.SetHour = hora;
            if (mensajes.Count > 0) { ViewBag.Mensajes = mensajes; }
            return View(listaHorarios);
        }
    }
}
