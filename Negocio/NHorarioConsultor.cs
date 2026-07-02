using Datos;
using Datos.Consultores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NHorarioConsultor
    {
        DHorarioConsultor objDatos = new DHorarioConsultor();

        public string GenerarHorariosConsultor(
            int idConsultor,
            DateTime fechaInicio,
            DateTime fechaFin,
            int horasPorCita,
            List<int> diasSeleccionados,
            int idUsuarioSesion
        )
        {
            if (idConsultor <= 0)
            {
                return "Debe seleccionar un consultor válido.";
            }

            if (fechaFin < fechaInicio)
            {
                return "La fecha fin no puede ser menor que la fecha inicio.";
            }

            if (horasPorCita <= 0)
            {
                return "Ingrese una cantidad de horas válida.";
            }

            if (horasPorCita > 10)
            {
                return "Las horas por cita no pueden ser mayores a 10.";
            }

            if (diasSeleccionados.Count == 0)
            {
                return "Seleccione al menos un día.";
            }

            return objDatos.GenerarHorariosConsultor(
                idConsultor,
                fechaInicio,
                fechaFin,
                horasPorCita,
                diasSeleccionados,
                idUsuarioSesion
            );
        }

        public List<HorarioVista> ListarPorConsultorYFecha(int idConsultor, DateTime fecha)
        {
            return objDatos.ListarPorConsultorYFecha(idConsultor, fecha);
        }


    }
}
