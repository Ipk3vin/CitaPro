using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NAuditoria
    {
        DAuditoria objDatos = new DAuditoria();

        public List<Auditoria> ListarAuditoria()
        {
            return objDatos.ListarAuditoria();
        }
    }
}
