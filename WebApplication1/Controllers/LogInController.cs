using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Actions;


namespace WebApplication1.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View("LogIn");
        }

        public ActionResult LogIn()
        {
            Sesion li = new Sesion();
            String usuario = "";
            String clave = "";
            
            if (li.IniciarSesion(usuario, clave))
                return View("Dashboard");

            return View("LogIn");
        }
    }
}