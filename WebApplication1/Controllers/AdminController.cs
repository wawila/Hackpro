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
        [HttpGet]
        public ActionResult Admin(LoginModel lm)
        {
            //System.Diagnostics.Debug.WriteLine("Usuario");
            if (Session["UserC"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }

            hackprodb_4Entities db = new hackprodb_4Entities();
            //System.Diagnostics.Debug.WriteLine(Session["UserID"].ToString());
            List<tbl_usuario> ListUsuario = db.tbl_usuario.ToList();
            var UserName = "";
            var Name = "";
            foreach (tbl_usuario usu in ListUsuario)
            {
                if (usu.tbl_usuario_correo.Equals(Session["UserC"].ToString()))
                {
                    Name = usu.tbl_usuario_p_nombre + " " + usu.tbl_usuario_p_apellido;
                    UserName = usu.tbl_usuario_username;
                }
            }
            var Email = Session["UserC"].ToString();
            ViewBag.correo = Email;
            ViewBag.user = UserName;
            ViewBag.name = Name;
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
        public ActionResult ListaCategoria()
        {
            GetListasCategoria();
            return View("ListaCategoria");
        }

        [HttpGet]
        public ActionResult ListaEquipos()
        {
            GetListasEquipos();
            return View("ListaEquipos");
        }
        [HttpGet]
        public ActionResult ListaProyectos()
        {
            GetListasProyectos();
            return View("ListaProyectos");
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
        public void GetListasEquipos()
        {
            hackprodb_4Entities tdb = new hackprodb_4Entities();
            List<tbl_equipo> ListTeam = tdb.tbl_equipo.ToList();
            var lista = "";

            foreach (tbl_equipo usu in ListTeam)
            {

                lista += "<tr>";
                lista += "<td> " + usu.tbl_equipo_id + " </td>";
                lista += "<td> " + usu.tbl_equipo_nombre + " </td>";
                lista += "<td> " + usu.tbl_equipo_fecha_creacion + " </td>";
                lista += "<td> " + usu.tbl_equipo_usuario_admin + " </td>";     
                lista += "</tr>";

            }
            ViewBag.equipo = lista;
        }
        [HttpGet]
        public void GetListasProyectos()
        {
            hackprodb_4Entities pdb = new hackprodb_4Entities();
            List<tbl_proyecto> ListProyect = pdb.tbl_proyecto.ToList();
            var lista = "";

            foreach (tbl_proyecto usu in ListProyect)
            {

                lista += "<tr>";
                lista += "<td> " + usu.tbl_proyecto_id + " </td>";
                lista += "<td> " + usu.tbl_proyecto_nombre + " </td>";
                lista += "<td> " + usu.tbl_evento_id + " </td>";
                lista += "<td> " + usu.tbl_equipo_id + " </td>";
                lista += "<td> " + usu.tbl_proyecto_url + " </td>";
                lista += "<td> " + usu.tbl_proyecto_git + " </td>";
                lista += "<td> " + usu.tbl_proyecto_estatus + " </td>";
               
                lista += "</tr>";

            }
            ViewBag.proyect = lista;
        }
        [HttpGet]
        public void GetListasCategoria()
        {
            hackprodb_4Entities cdb = new hackprodb_4Entities();
            List<tbl_cat_evento> ListCat = cdb.tbl_cat_evento.ToList();
            var lista = "";

            foreach (tbl_cat_evento usu in ListCat)
            {

                lista += "<tr>";
                lista += "<td> " + usu.tbl_cat_evento_id + " </td>";
                lista += "<td> " + usu.tbl_cat_evento_desc + " </td>";
                System.Diagnostics.Debug.WriteLine(usu.tbl_cat_evento_id);
                System.Diagnostics.Debug.WriteLine(usu.tbl_cat_evento_desc);
                lista += "</tr>";
            }
            ViewBag.categoria = lista;
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
            if (Session["UserC"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Este Evento es Valido");
                hackprodb_4Entities db = new hackprodb_4Entities();
                DateTime Fecha = DateTime.Now;
                var check = db.tbl_evento.Where(p => p.tbl_evento_nombre.Equals(Evento.tbl_evento_nombre));
                List<tbl_usuario> ListUsuario = db.tbl_usuario.ToList();
                int ID = 0;
                foreach (tbl_usuario usu in ListUsuario)
                {
                    if (usu.tbl_usuario_correo.Equals(Session["UserC"].ToString()))
                    {
                        ID = usu.tbl_usuario_id; 
                    }
                }
                if (check.Any() == false)
                {
                    tbl_evento REvento = new tbl_evento();
                    REvento.tbl_evento_nombre = Evento.tbl_evento_nombre;
                    REvento.tbl_evento_desc = Evento.tbl_evento_desc;
                    REvento.tbl_evento_lugar = Evento.tbl_evento_lugar;
                    REvento.tbl_evento_lugar_x = 0;
                    REvento.tbl_evento_lugar_y = 0;
                    REvento.tbl_evento_duracion = Evento.tbl_evento_duracion;
                    REvento.tbl_evento_fecha_inicio = Fecha;
                    REvento.tbl_evento_fecha_fin = Fecha;
                    REvento.tbl_evento_url = Evento.tbl_evento_url;
                    REvento.tbl_evento_activo = true;
                    REvento.tbl_evento_cal_jurado = Evento.tbl_evento_cal_jurado;
                    REvento.tbl_evento_cal_pueblo = Evento.tbl_evento_cal_pueblo;
                    REvento.tbl_evento_precio = Evento.tbl_evento_precio;
                    REvento.tbl_evento_presupuesto = Evento.tbl_evento_presupuesto;
                    REvento.tbl_usuario_id = ID;
                    REvento.tbl_cat_evento_id = Evento.tbl_cat_evento_id;
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
        [HttpGet]
        public ActionResult NewTeam()
        {
            return View("NewTeam");
        }
        [HttpPost]
        public ActionResult NewTeam(TeamModel team)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (Session["UserC"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Este Equipo es Valido");
                hackprodb_4Entities db = new hackprodb_4Entities();
                DateTime Fecha = DateTime.Now;
                var check = db.tbl_equipo.Where(p => p.tbl_equipo_nombre.Equals(team.equipo_nombre));
                List<tbl_usuario> ListUsuario = db.tbl_usuario.ToList();
                int ID = 0;
                foreach (tbl_usuario usu in ListUsuario)
                {
                    if (usu.tbl_usuario_correo.Equals(Session["UserC"].ToString()))
                    {
                        ID = usu.tbl_usuario_id;
                    }
                }
                if (check.Any() == false)
                {
                    tbl_equipo Wequipo = new tbl_equipo();
                    Wequipo.tbl_equipo_nombre = team.equipo_nombre;
                    Wequipo.tbl_equipo_fecha_creacion = Fecha;
                    Wequipo.tbl_equipo_usuario_admin = ID;
                    Wequipo.tbl_equipo_activo = true;
                    db.tbl_equipo.Add(Wequipo);
                    db.SaveChanges();
                    return View("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("ErrorT", "Este Equipo Ya Existe");
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult NewProyect()
        {
            return View("NewProyect");
        }
        [HttpPost]
        public ActionResult NewProyect(ProyectModel pro)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (Session["UserC"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Este Evento es Valido");
                hackprodb_4Entities db = new hackprodb_4Entities();
                DateTime Fecha = DateTime.Now;
                var check = db.tbl_proyecto.Where(p => p.tbl_proyecto_nombre.Equals(pro.proyecto_nombre));
                if (check.Any() == false)
                {
                    tbl_proyecto Wproyecto = new tbl_proyecto();
                    Wproyecto.tbl_proyecto_nombre = pro.proyecto_nombre;
                    Wproyecto.tbl_proyecto_url = pro.proyecto_url;
                    Wproyecto.tbl_proyecto_git = pro.proyecto_git;
                    Wproyecto.tbl_proyecto_activo = true;
                    Wproyecto.tbl_proyecto_estatus = pro.proyecto_estatus;
                    Wproyecto.tbl_equipo_id = pro.equipo_id;
                    Wproyecto.tbl_evento_id = pro.evento_id;


                    db.tbl_proyecto.Add(Wproyecto);
                    db.SaveChanges();
                    return View("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("ErrorP", "Este Proyecto Ya Existe");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult CatEvent()
        {
            return View("CatEvent");
        }
        [HttpPost]
        public ActionResult CatEvent(CatEventModel cat)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (Session["UserC"] == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Este Evento es Valido");
                hackprodb_4Entities db = new hackprodb_4Entities();
                DateTime Fecha = DateTime.Now;
                var check = db.tbl_cat_evento.Where(p => p.tbl_cat_evento_desc.Equals(cat.cat_evento_desc));
                if (check.Any() == false)
                {
                    tbl_cat_evento Wcategoria = new tbl_cat_evento();
                    Wcategoria.tbl_cat_evento_desc = cat.cat_evento_desc;
                    Wcategoria.tbl_cat_evento_activo = true;
                    db.tbl_cat_evento.Add(Wcategoria);
                    db.SaveChanges();
                    return View("Dashboard");
                }
                else
                {
                    ModelState.AddModelError("ErrorCT", "Esta Categoria Ya Existe");
                }
            }
            return View();
        }
    }
}