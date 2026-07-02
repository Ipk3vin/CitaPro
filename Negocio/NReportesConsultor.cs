using Datos.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NReportesConsultor
    {
        private DReportesConsultor dReportes = new DReportesConsultor();

        public DReportesConsultor.DtoCitasAtendidas ObtenerCitasAtendidas(int idConsultor)
        {
            return dReportes.ObtenerCitasAtendidas(idConsultor);
        }

        public List<DReportesConsultor.DtoIngresosTrimestre> ObtenerIngresosPorTrimestre(int idConsultor, int anio)
        {
            return dReportes.ObtenerIngresosPorTrimestre(idConsultor, anio);
        }

        public List<DReportesConsultor.DtoClienteFrecuente> ObtenerClientesFrecuentes(int idConsultor)
        {
            return dReportes.ObtenerClientesFrecuentes(idConsultor);
        }
    }
}
