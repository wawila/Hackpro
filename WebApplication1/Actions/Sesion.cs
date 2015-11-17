using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Actions
{
    public class Sesion
    {

        public string user = "w";
        public string key = "1";

        public bool IniciarSesion(string usuario, string clave)
        {
            usuario = usuario.ToLower();
            
            if (usuario == user && clave == key)
                return true;

            return false;
        }

    }
}