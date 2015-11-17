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
                if (ModelState.IsValid)
                {
                    hackprodb_4Entities db = new hackprodb_4Entities();
                    var login = db.tbl_usuario.Where(p => p.tbl_usuario_correo.Equals(log.User) && p.tbl_usuario_password.Equals(log.Pass));
                    if (login.Count() == 1)
                    {
                        //Session["User"] = "Jose4";
                        return RedirectToAction("Index","Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Email or Password not valid");
                    }
                }
                return RedirectToAction("");
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