using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioSesion
    {
        public int Idusuario { get; set; }
        public int Idtipo { get; set; }

        public int? IdConsultor { get; set; }
        public int? IdCliente { get; set; }

        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Rol { get; set; }
    }
}
