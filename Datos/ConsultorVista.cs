using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ConsultorVista
    {
        public int IdConsultor { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Rubro { get; set; }
        public string Descripcion { get; set; }
        public decimal? Monto { get; set; }
        public string Estado { get; set; }


        public int Idusuario { get; set; }
        public int IdRubro { get; set; }
        public string Contraseña { get; set; }


    }
}
