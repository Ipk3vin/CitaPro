using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NUsuario
    {
        DUsuario objUsuario = new DUsuario();

        public UsuarioSesion Login(string dni, string contrasena)
        {
            dni = dni.Trim();
            contrasena = contrasena.Trim();

            if (dni == "")
            {
                return null;
            }

            if (contrasena == "")
            {
                return null;
            }

            return objUsuario.Login(dni, contrasena);
        }
    }
}
