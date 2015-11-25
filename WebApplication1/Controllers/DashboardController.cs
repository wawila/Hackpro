using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Actions;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet]
        public ActionResult Dashboard()
        {
            hackprodb_4Entities db = new hackprodb_4Entities();
            List<tbl_usuario> ListUsuario = db.tbl_usuario.ToList();
            var lista = "";
            lista += "<table>";
            lista += "<tr>";
                lista += "<td> ID </td>";
                lista += "<td> Correo </td>";
                lista += "<td> Username </td>";
                lista += "<td> Nombre </td>";
                lista += "<td> Apellido </td>";
                lista += "<td> Gnero </td>";
                lista += "<td> Celular </td>";
                lista += "<td> Ocupacion </td>";
                lista += "</tr>";
            foreach (tbl_usuario usu in ListUsuario){
                
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
            lista += "</table>";
            ViewBag.HtmlStr = lista;
            return View("Dashboard");
        }

        [HttpGet]
        public ActionResult EventForm()
        {
            return View("EventForm");
        }

        [HttpPost]
        public ActionResult EventForm(EventModel Evento)
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