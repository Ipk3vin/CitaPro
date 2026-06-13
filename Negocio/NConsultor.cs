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

        public string RegistrarConsultor(Usuario objUsuario, Consultor objConsultor, string confirmarContrasena, int idUsuarioSesion)
        {
            if (string.IsNullOrWhiteSpace(objUsuario.Nombre))
                return "Debe ingresar el nombre";

            if (objUsuario.Contraseña != confirmarContrasena)
                return "Las contraseñas no coinciden";

            if (objConsultor.IdRubro <= 0)
                return "Debe seleccionar un rubro";

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