using Datos;
using Datos.Clientes;
using Datos.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCliente
    {
        DClientes objDatos = new DClientes();
        DCita citaDatos = new DCita(); 

        public string RegistrarCliente(Usuario objUsuario, Cliente objCliente)
        {
            objUsuario.Nombre = objUsuario.Nombre.Trim();
            objUsuario.Dni = objUsuario.Dni.Trim();
            objUsuario.Sexo = objUsuario.Sexo.Trim();
            objUsuario.Telefono = objUsuario.Telefono.Trim();
            objUsuario.Correo = objUsuario.Correo.Trim();
            objUsuario.Contraseña = objUsuario.Contraseña.Trim();

            if (objUsuario.Nombre == "")
            {
                return "Ingrese el nombre del cliente.";
            }

            if (objUsuario.Dni == "")
            {
                return "Ingrese el DNI del cliente.";
            }

            if (objUsuario.Sexo == "")
            {
                return "Seleccione el sexo.";
            }

            if (objUsuario.Telefono == "")
            {
                return "Ingrese el teléfono.";
            }

            if (objUsuario.Correo == "")
            {
                return "Ingrese el correo.";
            }

            if (objUsuario.Contraseña == "")
            {
                return "Ingrese la contraseña.";
            }

            return objDatos.RegistrarCliente(objUsuario, objCliente);
        }
        public int ObtenerIdClientePorUsuario(int idUsuario)
        {
            return objDatos.ObtenerIdClientePorUsuario(idUsuario);
        }

        public List<Citas> ObtenerCitas()
        {
            return citaDatos.ListarCitas();
        }

        public void CancelarCita(int idCita)
        {
            citaDatos.CancelarCita(idCita);
        }


    }
}
