using Datos.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Datos.Reportes.DReporteAdministrador;

namespace Negocio
{
    public class NReporteAdministrador
    {

        private DReporteAdministrador dReportes = new DReporteAdministrador();

        private void ValidarFechas(DateTime inicio, DateTime fin)
        {
            if (inicio > fin)
            {
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");
            }
        }

        public DtoIngresosTotales ObtenerIngresosTotales(DateTime inicio, DateTime fin, int idRubro, string estadoCita)
        {
            ValidarFechas(inicio, fin);
            return dReportes.ObtenerIngresosTotales(inicio, fin, idRubro, estadoCita);
        }

        public List<DtoRentabilidadConsultor> ObtenerRentabilidadPorConsultor(DateTime inicio, DateTime fin, int idConsultor, int idRubro, string estadoCita)
        {
            ValidarFechas(inicio, fin);
            return dReportes.ObtenerRentabilidadPorConsultor(inicio, fin, idConsultor, idRubro, estadoCita);
        }

        public List<DtoRentabilidadRubro> ObtenerRentabilidadPorRubro(DateTime inicio, DateTime fin, int idRubro, string estadoCita)
        {
            ValidarFechas(inicio, fin);
            return dReportes.ObtenerRentabilidadPorRubro(inicio, fin, idRubro, estadoCita);
        }

        public List<DtoDemandaRubro> ObtenerDemandaPorRubro(DateTime inicio, DateTime fin, int idRubro, string estadoCita)
        {
            ValidarFechas(inicio, fin);
            return dReportes.ObtenerDemandaPorRubro(inicio, fin, idRubro, estadoCita);
        }

        public List<DtoCitasPorEstado> ObtenerCitasPorEstado(DateTime inicio, DateTime fin, string estado, int idConsultor, int idRubro)
        {
            ValidarFechas(inicio, fin);
            return dReportes.ObtenerCitasPorEstado(inicio, fin, estado, idConsultor, idRubro);
        }

        public List<DtoOcupacionConsultor> ObtenerOcupacionConsultores(DateTime inicio, DateTime fin, int idConsultor, int idRubro, string estadoHorario)
        {
            ValidarFechas(inicio, fin);
            return dReportes.ObtenerOcupacionConsultores(inicio, fin, idConsultor, idRubro, estadoHorario);
        }

        public List<DtoProductividadComparativa> ObtenerProductividadComparativa(DateTime inicio, DateTime fin, int idConsultor, int idRubro)
        {
            ValidarFechas(inicio, fin);
            return dReportes.ObtenerProductividadComparativa(inicio, fin, idConsultor, idRubro);
        }
    }
}
