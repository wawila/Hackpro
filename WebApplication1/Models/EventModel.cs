using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EventModel
    {
        [Required(ErrorMessage ="Ingresar   Correcto")] 
        public string tbl_evento_nombre { get; set; }

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public string tbl_evento_desc { get; set; }

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public string tbl_evento_lugar { get; set; }

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public int tbl_evento_duracion { get; set; }

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public DateTime tbl_evento_fecha_inicio { get; set; }
        
        [Required(ErrorMessage = "Ingresar   Correcto")]
        public decimal tbl_evento_presupuesto { get; set; }

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public string tbl_evento_url { get; set; }

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public bool tbl_evento_cal_jurado { get; set; }

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public bool tbl_evento_cal_pueblo { get; set; }

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public decimal tbl_evento_precio { get; set; }
    }
}