using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Ususario Requerido") ]
        public string User { get; set; }

        [Required(ErrorMessage = "Ingresar Contraseña Correcta")]
        public string Password { get; set; }
    }
}