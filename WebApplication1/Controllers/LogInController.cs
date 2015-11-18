using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Actions;
using WebApplication1.Models;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;

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

                    // System.ArgumentException Linea de Abajo
                    var login = db.tbl_usuario.Where(p => p.tbl_usuario_correo.Equals(log.User) && p.tbl_usuario_password.Equals(log.Pass));
                    if (login.Count() == 1)
                    {
                        //Session["User"] = "Jose4";
                        return RedirectToAction("Index", "Dashboard");
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

            [HttpGet]
            public ActionResult Register()
            {
                return View("Register");
            }

            [HttpPost]
            public ActionResult Register(UserModel user)
            {
                if (ModelState.IsValid)
                {

                    DateTime Fecha = DateTime.Now;
                    //ConnectUpdate udb = new ConnectUpdate();
                    hackprodb_4Entities db = new hackprodb_4Entities();
                    tbl_usuario Usuario = new tbl_usuario(); 
                    Usuario.tbl_usuario_correo = user.Correo;
                    Usuario.tbl_usuario_password = user.Password;
                    Usuario.tbl_usuario_p_nombre = user.PNombre;
                    Usuario.tbl_usuario_s_nombre = user.SNombre;
                    Usuario.tbl_usuario_p_apellido = user.PApellido;
                    Usuario.tbl_usuario_s_apellido = user.SApellido;
                    Usuario.tbl_usuario_activo = true;
                    Usuario.tbl_usuario_celular = user.Celular;
                    Usuario.tbl_usuario_fecha_nac = user.FechaN;
                    Usuario.tbl_usuario_genero = user.Genero;
                    Usuario.tbl_usuario_ocupacion = user.Ocupacion;
                    Usuario.tbl_usuario_fecha_crea =  Fecha;
                    Usuario.tbl_usuario_admin = false;
                    db.tbl_usuario.Add(Usuario);
                    db.SaveChanges();
                    return View("Login");
                }
                else
                {
                    
                }
                return View();
            }

        }
    }
}