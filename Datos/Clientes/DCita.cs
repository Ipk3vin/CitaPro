using Datos.Clientes;
using System;
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




    }
}