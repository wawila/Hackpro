using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Actions
{
    public class Sesion
    {
        public bool IniciarSesion(string usuario, string clave)
        {
            usuario = usuario.ToLower();
            
            if (usuario == "wawila" && clave == "123")
                return true;

            return false;
        }

    }
}