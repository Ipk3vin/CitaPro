using Datos;
using Datos.Consultores;
using System;
using System.Collections;
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

        public IList BuscarHorariosPorFecha(DateTime fecha, int idUsuarioSesion)
        {
            if (idUsuarioSesion <= 0)
            {
                throw new ArgumentException("El ID del consultor no es válido.");
            }

            return objDatos.BuscarHorariosPorFecha(fecha, idUsuarioSesion);
        }

        public bool AtenderCita(int idHorario,int idUsuarioSesion)
        {
            if (idHorario <= 0)
                throw new ArgumentException("ID de horario inválido.");

            // Pasamos un ID de usuario fijo por ahora (ej. 1). 
            // En un sistema real, aquí pasarías el ID del usuario logueado en el sistema.
            int idUsuarioActual = 1;

            return objDatos.AtenderCita(idHorario, idUsuarioActual);
        }
    }
}
