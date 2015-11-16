using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Actions
{
    public class Sesion
    {

        public string user = null;
        public string key = null;

        public bool IniciarSesion(string usuario, string clave)
        {
            usuario = usuario.ToLower();
            
            if (usuario == user && clave == key)
                return true;

            return false;
        }

    }
}