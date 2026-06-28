using System;
using System.Collections.Generic;
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
    }
}
