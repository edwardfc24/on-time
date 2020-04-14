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
    public class MensajeController : Controller
    {
        private static List<EmpMensaje> destinatarios = new List<EmpMensaje>();


        //
        // GET: /Mensaje/

        public ActionResult Index()
        {
            List<Mensaje> listaMensajes = new List<Mensaje>();
            listaMensajes = MensajeBLL.SelectAll();
            return View("Index", listaMensajes);
        }
        [HttpGet()]
        public ActionResult Create()
        {
            List<Empleado> listaEmpleados = EmpleadoBLL.SelectAll();
            ViewBag.EmpleadoPk = new SelectList(listaEmpleados, "pkEmpleado", "fullName");
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Mensaje mensaje)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string name = ticket.Name;
            mensaje.fkRemitente = Convert.ToInt32(name);
            int idMensaje = MensajeBLL.InsertObjetoMensaje(mensaje);
            try
            {
                foreach (EmpMensaje relacion in destinatarios)
                {
                    relacion.fkMensaje = idMensaje;
                    EmpMensajeBLL.InsertObjetoEmpMensaje(relacion);
                }
            }
            catch
            {

            }
            return RedirectToAction("Index", "Mensaje");
        }

        [HttpPost]
        public void setListaEmpMensaje(List<EmpMensaje> auxiliar)
        {
            if (auxiliar != null)
            {
                destinatarios = new List<EmpMensaje>();
                foreach (EmpMensaje aux in auxiliar)
                {
                    destinatarios.Add(aux);
                }
            }
        }
    }
}
