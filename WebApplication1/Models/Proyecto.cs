using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Proyecto
    {
        public int proyecto_id { get; set; }
        public string proyecto_nombre { get; set; }
        public int equipo_id { get; set; }
        public int evento_id { get; set; }
        public string proyecto_url { get; set; }
        public string proyecto_git { get; set; }
        public int proyecto_estatus { get; set; }
    }
}