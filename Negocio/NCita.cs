using Datos;
using Datos.Clientes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class NCita
    {
        private DCita objDatos = new DCita();

        public string RegistrarCita(Cita obj)
        {
            bool resultado = objDatos.GuardarCita(obj);

            if (resultado)
            {
                return "Cita registrada correctamente.";
            }
            else
            {
                return "Error al registrar la cita. Intente de nuevo.";
            }
        }

        public IList BuscarCitasPorFecha(DateTime fecha, int idConsultor)
        {
            if (idConsultor <= 0)
                throw new ArgumentException("El ID del consultor no es válido.");

            return objDatos.BuscarCitasPorFecha(fecha, idConsultor);
        }

        public bool AtenderCita(int idCita, int idUsuarioSesion)
        {
            if (idCita <= 0)
                throw new ArgumentException("ID de cita inválido.");

            return objDatos.AtenderCita(idCita, idUsuarioSesion);
        }
    }
}
