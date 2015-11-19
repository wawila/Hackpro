using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Usuario Requerido")]
        public string User { get; set; }

        [Required(ErrorMessage = "Contraseña Requerida")]
        public string Pass { get; set; }
    }
}