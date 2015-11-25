using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EventModel
    {
        [Required(ErrorMessage ="Nombre de Evento Requerido")] 
        public string tbl_evento_nombre { get; set; }//

        [Required(ErrorMessage = "Descripcion Requerida")]
        public string tbl_evento_desc { get; set; }//

        [Required(ErrorMessage = "Lugar Requerido")]
        public string tbl_evento_lugar { get; set; }//

        [Required(ErrorMessage = "Duracion Requerida")]
        public int tbl_evento_duracion { get; set; }//

        [Required(ErrorMessage = "Fecha de Inicio Requerido")]
        public DateTime tbl_evento_fecha_inicio { get; set; }//

        [Required(ErrorMessage = "Fecha de Inicio Requerido")]
        public DateTime tbl_evento_fecha_fin { get; set; }//

        [Required(ErrorMessage = "Presupuesto Requerido")]
        public decimal tbl_evento_presupuesto { get; set; }//

        [Required(ErrorMessage = "Ingresar   Correcto")]
        public string tbl_evento_url { get; set; }//

        [Required(ErrorMessage = "Jurado Requerido")]
        public bool tbl_evento_cal_jurado { get; set; }//

        [Required(ErrorMessage = "Votacion Pueblo Requerida")]
        public bool tbl_evento_cal_pueblo { get; set; }//

        [Required(ErrorMessage = "Precio Requerido")]
        public decimal tbl_evento_precio { get; set; }//
    }
}