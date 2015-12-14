using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        /*public ActionResult Index()
        {
            return View();
        }*/

        public ActionResult Admin(LoginModel lm)
        {
            System.Diagnostics.Debug.WriteLine("Admin(lm)");

            if (lm == null)
            {
                System.Diagnostics.Debug.WriteLine("No hay lm");
            }
            else
                System.Diagnostics.Debug.WriteLine("lm: " + lm + lm.User);

            var email = "Email: ";
            email += lm.User;

            ViewBag.correo = email;
            return View("Admin");
        }

        [HttpGet]
        public ActionResult ListaUsuarios()
        {
            GetListasUsuarios();
            return View("ListaUsuarios");
        }

        [HttpGet]
        public ActionResult ListaEventos()
        {
            GetListasEventos();
            return View("ListaEventos");
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            return View("Dashboard");
        }

        [HttpGet]
        public void GetListasUsuarios()
        {
            hackprodb_4Entities db = new hackprodb_4Entities();
            List<tbl_usuario> ListUsuario = db.tbl_usuario.ToList();
            var lista = "";

            foreach (tbl_usuario usu in ListUsuario)
            {

                lista += "<tr>";
                lista += "<td> " + usu.tbl_usuario_id + " </td>";
                lista += "<td> " + usu.tbl_usuario_correo + " </td>";
                lista += "<td> " + usu.tbl_usuario_username + " </td>";
                lista += "<td> " + usu.tbl_usuario_p_nombre + " </td>";
                lista += "<td> " + usu.tbl_usuario_p_apellido + " </td>";
                lista += "<td> " + usu.tbl_usuario_genero + " </td>";
                lista += "<td> " + usu.tbl_usuario_celular + " </td>";
                lista += "<td> " + usu.tbl_usuario_ocupacion + " </td>";
                lista += "</tr>";

            }
            ViewBag.HtmlStr = lista;
        }


        [HttpGet]
        public void GetListasEventos()
        {
            hackprodb_4Entities edb = new hackprodb_4Entities();
            List<tbl_evento> ListEventos = edb.tbl_evento.ToList();
            var evento = "";

            foreach (tbl_evento eve in ListEventos)
            {
                evento += "<tr>";
                evento += "<td>" + eve.tbl_evento_id + "</td>";
                evento += "<td>" + eve.tbl_evento_nombre + "</td>";
                evento += "<td>" + eve.tbl_evento_desc + "</td>";
                evento += "<td>" + eve.tbl_evento_lugar + "</td>";
                evento += "<td>" + eve.tbl_evento_duracion + "</td>";
                evento += "<td>" + eve.tbl_evento_fecha_inicio + "</td>";
                evento += "<td>" + eve.tbl_evento_precio + "</td>";
                evento += "<td>" + eve.tbl_evento_url + "</td>";
                evento += "<td>";
                if (eve.tbl_evento_cal_jurado && eve.tbl_evento_cal_pueblo)
                {
                    evento += " J - P";
                }
                else if (eve.tbl_evento_cal_jurado && !eve.tbl_evento_cal_pueblo)
                {
                    evento += "J";
                }
                else if (!eve.tbl_evento_cal_jurado && eve.tbl_evento_cal_pueblo)
                {
                    evento += "P";
                }
                else
                {
                    evento += "N/A";
                }
                evento += "</tr>";
            }
            evento += "</table>";
            ViewBag.eventos = evento;
        }

        [HttpGet]
        public ActionResult NewEvents()
        {
            return View("NewEvents");
        }
        [HttpPost]
        public ActionResult NewEvents(EventModel Evento)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Este Evento es Valido");
                hackprodb_4Entities db = new hackprodb_4Entities();
                DateTime Fecha = DateTime.Now;
                var check = db.tbl_evento.Where(p => p.tbl_evento_nombre.Equals(Evento.tbl_evento_nombre));
                if (check.Any() == false)
                {
                    tbl_evento REvento = new tbl_evento();
                    REvento.tbl_evento_nombre = "a";//Evento.tbl_evento_nombre;
                    REvento.tbl_evento_desc = "a";//Evento.tbl_evento_desc;
                    REvento.tbl_evento_lugar = "a";//Evento.tbl_evento_lugar;
                    REvento.tbl_evento_lugar_x = 0;
                    REvento.tbl_evento_lugar_y = 0;
                    REvento.tbl_evento_duracion = 12;//Evento.tbl_evento_duracion;
                    REvento.tbl_evento_fecha_inicio = Fecha;
                    REvento.tbl_evento_fecha_fin = Fecha;
                    REvento.tbl_evento_url = "";//Evento.tbl_evento_url;
                    REvento.tbl_evento_activo = true;
                    REvento.tbl_evento_cal_jurado = true; //Evento.tbl_evento_cal_jurado;
                    REvento.tbl_evento_cal_pueblo = true;//Evento.tbl_evento_cal_pueblo;
                    REvento.tbl_evento_precio = 0;///Evento.tbl_evento_precio;
                    REvento.tbl_evento_presupuesto = 0;//Evento.tbl_evento_presupuesto;
                    REvento.tbl_usuario_id = 2;
                    REvento.tbl_cat_evento_id = 1;
                    db.tbl_evento.Add(REvento);
                    db.SaveChanges();
                    return View("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("ErrorS", "Este Evento Existente");
                }
            }
            System.Diagnostics.Debug.WriteLine("Evento Invalido");
            return View();
        }
        
    }
}