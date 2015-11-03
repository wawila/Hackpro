using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Actions;
using WebApplication1.Models;


namespace System.Windows.Forms
{
    namespace WebApplication1.Controllers
    {
        public class LogInController : Controller
        {
            // GET: LogIn
            [HttpGet]
            public ActionResult LogIn()
            {
                return View("LogIn");
            }
            [HttpPost]
            public RedirectToRouteResult LogIn(LoginModel log)
            {
                Sesion li = new Sesion();
                string usuario = log.User;
                string clave = log.Password;

                if (li.IniciarSesion(usuario, clave))
                    return RedirectToAction("Index", "Dashboard");
               
                else
                    return RedirectToAction("ErrorLoging", "LogIn");
            }

            public ActionResult ErrorLoging()
            {
                return View("ErrorLoging");
            }
        }
    }
}