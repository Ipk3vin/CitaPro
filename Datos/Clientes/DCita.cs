using System;
using System.Collections.Generic;
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
    }
}