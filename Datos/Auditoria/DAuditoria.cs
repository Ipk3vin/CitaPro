using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DAuditoria
    {
        public List<Auditoria> ListarAuditoria()
        {
            using (var context = new DBcitaproEntities())
            {
                return context.Auditoria.ToList();
            }
        }
    }
}

