using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ProyectModel
    {
        [Required(ErrorMessage = "Nombre de Proyecto Requerido")]
        public string proyecto_nombre { get; set; }
        [Required(ErrorMessage = "ID de Equipo Requerido")]
        public int equipo_id { get; set; }
        [Required(ErrorMessage = "ID de Evento Requerido")]
        public int evento_id { get; set; }
        //No es Requerido
        public string proyecto_url { get; set; }
        [Required(ErrorMessage = "Repositorio Requerido")]
        public string proyecto_git { get; set; }
        [Required(ErrorMessage = "Estatus Requerido")]
        public int proyecto_estatus { get; set; }
    }
}