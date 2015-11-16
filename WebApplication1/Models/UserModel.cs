using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Ususario Requerido") ]
        public string User { get; set; }

        [Required(ErrorMessage = "Correo Requerido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "No Es un correo Valido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Contraseña Requerida")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Nombre Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido Requerido")]
        public string Apellido { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se puede ingresar numeros")]
        public string Celular { get; set; }

        [StringLength(1)]
        [RegularExpression("[Mm]{1}[Ff]{1}", ErrorMessage = "M para Masculino F para Femenino")]
        public string Genero { get; set; }
        
    }
}