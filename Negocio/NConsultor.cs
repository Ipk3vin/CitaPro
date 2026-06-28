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

        DConsultores objConsultor = new DConsultores();
        //Para registrar un consultor
        public string RegistrarConsultor(Usuario objUsuario, Consultor objConsultorDatos, int idUsuarioSesion)
        {
            return objConsultor.RegistrarConsultor(objUsuario, objConsultorDatos, idUsuarioSesion);
        }

        public List<ConsultorVista> ListarConsultores()
        {
            return objConsultor.ListarConsultores();
        }

        public List<Rubro> ListarRubros()
        {
            return objConsultor.ListarRubros();
        }
        //Editar consultor
        public ConsultorVista BuscarConsultorPorDni(string dni)
        {
            dni = dni.Trim();

            if (dni == "")
            {
                return null;
            }

            return objConsultor.BuscarConsultorPorDni(dni);
        }

        public string CambiarEstadoConsultor(int idConsultor, bool habilitar, int idUsuarioSesion)
        {
            if (idConsultor <= 0)
            {
                return "Debe seleccionar un consultor válido.";
            }

            return objConsultor.CambiarEstadoConsultor(idConsultor, habilitar, idUsuarioSesion);
        }

        public string EliminarConsultor(int idConsultor)
        {
            if (idConsultor <= 0)
            {
                return "Debe seleccionar un consultor válido.";
            }

            return objConsultor.EliminarConsultor(idConsultor);
        }
        //modificar los datos del consultor
        public ConsultorVista ObtenerConsultorPorId(int idConsultor)
        {
            if (idConsultor <= 0)
            {
                return null;
            }

            return objConsultor.ObtenerConsultorPorId(idConsultor);
        }

        public string ActualizarConsultor(int idConsultor, Usuario objUsuario, Consultor objConsultorDatos)
        {
            if (idConsultor <= 0)
            {
                return "Debe seleccionar un consultor válido.";
            }

            objUsuario.Nombre = objUsuario.Nombre.Trim();
            objUsuario.Dni = objUsuario.Dni.Trim();
            objUsuario.Contraseña = objUsuario.Contraseña.Trim();

            if (objUsuario.Nombre == "")
            {
                return "Ingrese el nombre del consultor.";
            }

            if (objUsuario.Dni == "")
            {
                return "Ingrese el DNI del consultor.";
            }

            if (objUsuario.Contraseña == "")
            {
                return "Ingrese la contraseña.";
            }

            return objConsultor.ActualizarConsultor(idConsultor, objUsuario, objConsultorDatos);
        }


        //clientessss
        public List<ConsultorVista> ListarConsultoresPorRubro(int idRubro)
        {
            if (idRubro <= 0)
            {
                return new List<ConsultorVista>();
            }

            return objConsultor.ListarConsultoresPorRubro(idRubro);
        }




















    }
}