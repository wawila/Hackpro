using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TeamModel
    {
        [Required(ErrorMessage = "Nombre de Equipo Requerido")]
        public string equipo_nombre { get; set; }
    }
}