using Datos;
using System;
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
    }
}
