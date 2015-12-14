using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class CatEventModel
    {
        [Required(ErrorMessage = "Descripcion De Evento Requerido")]
        public string cat_evento_desc { get; set; }
    }
}