using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class CatEvent
    {
        public int cat_evento_id { get; set; }
        public string cat_evento_desc { get; set; }
        public bool cat_evento_activo { get; set; }
    }
}