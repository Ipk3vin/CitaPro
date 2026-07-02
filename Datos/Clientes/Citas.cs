using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clientes
{
    public class Citas
    {
        public int IdCita { get; set; }
        public string Consultor { get; set; }
        public string Horario { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public string NombreEstado { get; set; }
    }
}
