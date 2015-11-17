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

        [Required(ErrorMessage = "Nombre Requerido")]
        public string PNombre { get; set; }

        [Required(ErrorMessage = "Nombre Requerido")]
        public string SNombre { get; set; }

        [Required(ErrorMessage = "Apellido Requerido")]
        public string PApellido { get; set; }

        [Required(ErrorMessage = "Apellido Requerido")]
        public string SApellido { get; set; }

        [Required(ErrorMessage = "Contraseña Requerida")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Contraseña Requerida")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^(0[1-9]|1[012])[/](0[1-9]|[12][0-9]|3[01])[/]\d{4}$", ErrorMessage = "Formato debe ser asi MM/dd/yyyy")]
        public string FechaN { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se puede ingresar numeros")]
        public string Celular { get; set; }

        [StringLength(1)]
        [RegularExpression("[Mm]{1}[Ff]{1}", ErrorMessage = "M para Masculino F para Femenino")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Ocupacion Requerida")]
        public string Ocupacion { get; set; }

    }
}