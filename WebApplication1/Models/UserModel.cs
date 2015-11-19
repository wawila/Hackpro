using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Usuario Requerido")]
        public string UserName { get; set; }

        //hackprodb_4Entities db = new hackprodb_4Entities();
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
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Contraseña Requerida")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Fecha Requerida")]
        public DateTime FechaN { get; set; }

        [Required(ErrorMessage = "Celular Requerido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se puede ingresar numeros")]
        public string Celular { get; set; }

        [StringLength(1)]
        [Required(ErrorMessage = "Genero Requerido")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Ocupacion Requerida")]
        public string Ocupacion { get; set; }
        
    }
}