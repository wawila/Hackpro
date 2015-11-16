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
            public RedirectToRouteResult LogIn(UserModel log)
            {
                Diagnostics.Debug.WriteLine("LogIn");
                Diagnostics.Debug.WriteLine(log.Nombre);
                Diagnostics.Debug.WriteLine(log.Apellido);
                Diagnostics.Debug.WriteLine(log.User);
                Diagnostics.Debug.WriteLine(log.Password);
                Diagnostics.Debug.WriteLine(log.Correo);
                Diagnostics.Debug.WriteLine(log.Genero);
                Diagnostics.Debug.WriteLine(log.Celular);
           
            Sesion li = new Sesion();
                if (li.user == null)
                {
                    string usuario = log.User;
                    string clave = log.Password;

                    if (li.IniciarSesion(usuario, clave))
                        return RedirectToAction("Index", "Dashboard");

                    else
                        return RedirectToAction("LogIn", "LogIn");
                }
                else
                {
                    li.user = log.User;
                    li.key = log.Password;

                    return RedirectToAction("LogIn", "LogIn");
                }
            }

            public ActionResult ErrorLoging()
            {
                return View("ErrorLoging");
            }

            [HttpPost]
            public void Register(UserModel log)
            {
                Diagnostics.Debug.WriteLine("Register");
                Diagnostics.Debug.WriteLine(log.Nombre);
                Diagnostics.Debug.WriteLine(log.Apellido);
                Diagnostics.Debug.WriteLine(log.User);
                Diagnostics.Debug.WriteLine(log.Password);
                Diagnostics.Debug.WriteLine(log.Correo);
                Diagnostics.Debug.WriteLine(log.Genero);
                Diagnostics.Debug.WriteLine(log.Celular);
            }
        }
    }
}