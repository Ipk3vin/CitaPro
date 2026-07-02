using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Consultores
{
    public class DHorarioConsultor
    {
        public string GenerarHorariosConsultor(
            int idConsultor,
            DateTime fechaInicio,
            DateTime fechaFin,
            int horasPorCita,
            List<int> diasSeleccionados,
            int idUsuarioSesion
        )
        {
            string respuesta = "";
            int cantidadGenerada = 0;

            using (var context = new DBcitaproEntities())
            {
                DateTime fechaActual = fechaInicio.Date;
                DateTime fechaFinal = fechaFin.Date;

                while (fechaActual <= fechaFinal)
                {
                    int diaSemana = (int)fechaActual.DayOfWeek;

                    bool diaPermitido = false;

                    foreach (int dia in diasSeleccionados)
                    {
                        if (dia == diaSemana)
                        {
                            diaPermitido = true;
                            break;
                        }
                    }

                    if (diaPermitido == true)
                    {
                        DateTime horaInicio = fechaActual.AddHours(8);
                        DateTime horaLimite = fechaActual.AddHours(18);

                        while (horaInicio.AddHours(horasPorCita) <= horaLimite)
                        {
                            DateTime horaFin = horaInicio.AddHours(horasPorCita);

                            bool existeHorario = false;

                            foreach (var h in context.HorarioConsultor)
                            {
                                if (h.IdConsultor == idConsultor &&
                                    h.FechaHoraInicio == horaInicio &&
                                    h.FechaHoraFin == horaFin)
                                {
                                    existeHorario = true;
                                    break;
                                }
                            }

                            if (existeHorario == false)
                            {
                                HorarioConsultor objHorario = new HorarioConsultor();

                                objHorario.IdConsultor = idConsultor;

                                // 1 = Disponible
                                // 2 = Reservado
                                objHorario.IdEstadoHorario = 1;

                                objHorario.FechaHoraInicio = horaInicio;
                                objHorario.FechaHoraFin = horaFin;

                                objHorario.CreatedBy = idUsuarioSesion;
                                objHorario.CreatedAt = DateTime.Now;

                                context.HorarioConsultor.Add(objHorario);

                                cantidadGenerada++;
                            }

                            horaInicio = horaFin;
                        }
                    }

                    fechaActual = fechaActual.AddDays(1);
                }

                context.SaveChanges();

                respuesta = "Se generaron " + cantidadGenerada + " horarios correctamente.";
            }

            return respuesta;
        }

        public List<HorarioVista> ListarPorConsultorYFecha(int idConsultor, DateTime fecha)
        {
            using (var contexto = new DBcitaproEntities())
            {
                DateTime inicio = fecha.Date;
                DateTime fin = inicio.AddDays(1);

                // Creamos la consulta pero no la ejecutamos todavía
                var consulta = contexto.HorarioConsultor
                    .Where(hc => hc.IdConsultor == idConsultor
                              && hc.FechaHoraInicio >= inicio
                              && hc.FechaHoraInicio < fin)
                    .Join(contexto.EstadoHorario,
                          hc => hc.IdEstadoHorario,
                          e => e.IdEstadoHorario,
                          (hc, e) => new HorarioVista
                          {
                              IdHorario = hc.IdHorario,
                              FechaHoraInicio = (DateTime)hc.FechaHoraInicio,
                              FechaHoraFin = (DateTime)hc.FechaHoraFin,
                              IdEstadoHorario = hc.IdEstadoHorario, 
                              NombreEstado = e.NombreEstado
                          });

                // Ejecutamos la consulta y devolvemos la lista al final
                return consulta.ToList();
            }
        }


        // Usamos object o IList para poder devolver una proyección anónima limpia a la grilla
        // Agregamos el idConsultor como parámetro obligatorio
        public IList BuscarHorariosPorFecha(DateTime fechaSeleccionada, int idConsultor)
        {
            using (var db = new DBcitaproEntities()) // Reemplaza por tu DbContext
            {
                // Definimos el inicio y fin del día para una búsqueda segura en SQL
                DateTime inicioDia = fechaSeleccionada.Date;
                DateTime finDia = inicioDia.AddDays(1);

                var horarios = db.HorarioConsultor
                    .Where(h => h.IdConsultor == idConsultor && // Filtro vital
                                h.FechaHoraInicio.HasValue &&
                                h.FechaHoraInicio.Value >= inicioDia &&
                                h.FechaHoraInicio.Value < finDia)
                    .Select(h => new
                    {
                        IdHorario = h.IdHorario,
                        Inicio = h.FechaHoraInicio,
                        Fin = h.FechaHoraFin,
                        // Ajusta "NombreEstado" según cómo se llame la propiedad en tu clase EstadoHorario
                        Estado = h.EstadoHorario.NombreEstado,
                        IdEstado = h.IdEstadoHorario
                    })
                    .ToList();

                return horarios;
            }
        }

        public bool AtenderCita(int idHorario, int idUsuarioModifica)
        {
            using (var db = new DBcitaproEntities())
            {
                try
                {
                    // Buscamos el horario por su Primary Key
                    var horario = db.HorarioConsultor.FirstOrDefault(h => h.IdHorario == idHorario);

                    if (horario != null)
                    {
                        // Suponiendo que el IdEstadoHorario = 2 significa "Atendido"
                        horario.IdEstadoHorario = 2;

                        // Actualizamos los campos de auditoría que tienes en tu clase
                        horario.ModifiedBy = idUsuarioModifica;
                        horario.ModifiedAt = DateTime.Now;

                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
