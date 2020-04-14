using OnTime.BLL;
using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnTime.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.Login user)
        {
            if (ModelState.IsValid) //Verificar que el modelo de datos sea válido en cuanto a la definición de las propiedades
            {
                Empleado inSession = Isvalid(user.TxtNombre, user.TxtPassword);
                if (inSession != null)//Verificar que el name y clave exista utilizando el método privado
                {
                    FormsAuthentication.SetAuthCookie(inSession.pkEmpleado.ToString(), false); //crea variable de usuario con el correo del usuario
                    return RedirectToAction("Index", "Admin"); //dirigir al controlador home vista Index una vez se a autenticado en el sistema
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

        private Empleado Isvalid(string name, string password)
        {
            Empleado actual = EmpleadoBLL.GetEmpleadoByNameAndPass(name, password);
            return actual;
        }
    }
}
