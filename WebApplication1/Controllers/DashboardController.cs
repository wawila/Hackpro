using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View("Dashboard");
        }
        [HttpGet]
        public ActionResult EventForm()
        {
            return View("EventForm");
        }

        [HttpPost]
        public ActionResult EventForm(EventModel Event)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Es Evento Valido");
                /*//ConnectUpdate udb = new ConnectUpdate();
                hackprodb_4Entities db = new hackprodb_4Entities();
                var check = db.tbl_evento.Where(p => p.tbl_evento_nombre.Equals(Evento.tbl_evento_nombre));
                if (check.Any() == false)
                {
                    tbl_evento REvento = new tbl_evento();
                    REvento.tbl_evento_nombre = Evento.tbl_evento_nombre;
                    REvento.tbl_evento_desc = Evento.tbl_evento_desc;
                    REvento.tbl_evento_lugar = Evento.tbl_evento_lugar;
                    REvento.tbl_evento_duracion = Evento.tbl_evento_duracion;
                    REvento.tbl_evento_fecha_inicio = Evento.tbl_evento_fecha_inicio;
                    REvento.tbl_evento_presupuesto = Evento.tbl_evento_presupuesto;
                    REvento.tbl_evento_url = Evento.tbl_evento_url;
                    REvento.tbl_evento_activo = true;
                    REvento.tbl_evento_cal_jurado = Evento.tbl_evento_cal_jurado;
                    REvento.tbl_evento_cal_pueblo = Evento.tbl_evento_cal_pueblo;
                    REvento.tbl_evento_precio = Evento.tbl_evento_precio;
                    REvento.tbl_evento_fecha_fin = Evento.tbl_evento_fecha_fin;
                    //REvento.tbl_cat_evento_id = 1;
                    REvento.tbl_usuario_id = 2;
                    db.tbl_evento.Add(REvento);
                    db.SaveChanges();
                    return View("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("ErrorS", "Este Evento Existente");
                }*/
            }
            System.Diagnostics.Debug.WriteLine("Evento Invalido");
            return View();
        }


    }
}