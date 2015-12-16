using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class JuryModel
    {
        [Required(ErrorMessage = "ID de Evento Requerido")]
        public int evento_id { get; set; }
    }
}