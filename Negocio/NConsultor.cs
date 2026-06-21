using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class NConsultor
    {
        DConsultores objDatos = new DConsultores();

        public string RegistrarConsultor(Usuario objUsuario, Consultor objConsultor, int idUsuarioSesion)
        {
            return objDatos.RegistrarConsultor(objUsuario, objConsultor, idUsuarioSesion);
        }

        public List<ConsultorVista> ListarConsultores()
        {
            return objDatos.ListarConsultores();
        }

        public List<Rubro> ListarRubros()
        {
            return objDatos.ListarRubros();
        }
    }
}