using Datos.Clientes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCita
    {
        public bool GuardarCita(Cita nuevaCita)
        {
            using (var contexto = new DBcitaproEntities())
            {
                contexto.Cita.Add(nuevaCita);

                var horario = contexto.HorarioConsultor.Find(nuevaCita.IdHorario);

                if (horario != null)
                {
                    horario.IdEstadoHorario = 2;
                }

                contexto.SaveChanges();
                return true;
            }
        }

        public List<Citas> ListarCitas()
        {
            using (var contexto = new DBcitaproEntities())
            {
                var lista = from c in contexto.Cita
                            join hc in contexto.HorarioConsultor on c.IdHorario equals hc.IdHorario
                            join co in contexto.Consultor on hc.IdConsultor equals co.IdConsultor
                            join u in contexto.Usuario on co.Idusuario equals u.Idusuario
                            join e in contexto.Estado on c.IdEstado equals e.IdEstado
                            select new Citas
                            {
                                IdCita = c.IdCita,
                                Consultor = u.Nombre,
                                Horario = hc.FechaHoraInicio.ToString(), // O el campo que represente el horario
                                Monto = (decimal)c.Monto,
                                Descripcion = c.Descripcion,
                                NombreEstado = e.NombreEstado
                            };

                return lista.ToList();
            }
        }

        public void CancelarCita(int idCita)
        {
            using (var contexto = new DBcitaproEntities())
            {
                var cita = contexto.Cita.Find(idCita);

                if (cita != null)
                {
                    cita.IdEstado = 1;

                    var horario = contexto.HorarioConsultor.Find(cita.IdHorario);

                    if (horario != null)
                    {
                        horario.IdEstadoHorario = 1;
                    }
                    contexto.SaveChanges();
                }
            }
        }

        public IList BuscarCitasPorFecha(DateTime fechaSeleccionada, int idConsultor)
        {
            using (var db = new DBcitaproEntities())
            {
                DateTime inicioDia = fechaSeleccionada.Date;
                DateTime finDia = inicioDia.AddDays(1);

                var citas = db.Cita // Asegúrate de que este sea el nombre de tu DbSet
                    .Where(c => c.HorarioConsultor.IdConsultor == idConsultor &&
                                c.HorarioConsultor.FechaHoraInicio.HasValue &&
                                c.HorarioConsultor.FechaHoraInicio.Value >= inicioDia &&
                                c.HorarioConsultor.FechaHoraInicio.Value < finDia)
                    .Select(c => new
                    {
                        IdCita = c.IdCita, // OJO: Ahora capturamos el ID de la Cita, no del horario

                        // Si tu Cita está ligada a un Cliente, ¡puedes mostrarlo en la grilla!
                        // Cliente = c.Cliente.Nombre, 

                        Inicio = c.HorarioConsultor.FechaHoraInicio,
                        Fin = c.HorarioConsultor.FechaHoraFin,

                        // Ajusta estos nombres según tu entidad Cita y su Estado
                        IdEstado = c.IdEstado,
                        Estado = c.Estado.NombreEstado
                    })
                    .ToList();

                return citas;
            }
        }

        public bool AtenderCita(int idCita, int idUsuarioModifica)
        {
            using (var db = new DBcitaproEntities())
            {
                try
                {
                    // Buscamos la CITA, no el horario
                    var cita = db.Cita.FirstOrDefault(c => c.IdCita == idCita);

                    if (cita != null)
                    {
                        // Suponiendo que el IdEstadoCita = 2 significa "Atendido"
                        cita.IdEstado = 3;

                        // Auditoría de la tabla Cita
                        cita.ModifiedBy = idUsuarioModifica;
                        cita.ModifiedAt = DateTime.Now;

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