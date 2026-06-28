using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.dao
{
    public class DClientes
    {
        public string RegistrarCliente(Usuario objUsuario, Cliente objCliente)
        {
            string respuesta = "";

            using (var context = new DBcitaproEntities())
            {
                Usuario usuarioTemp = null;

                foreach (var u in context.Usuario)
                {
                    if (u.Dni == objUsuario.Dni)
                    {
                        usuarioTemp = u;
                        break;
                    }
                }

                if (usuarioTemp != null)
                {
                    respuesta = "Ya existe un usuario registrado con ese DNI.";
                }
                else
                {
                    objUsuario.Idtipo = 3;
                    objUsuario.CreatedAt = DateTime.Now;

                    // Primero se registra el usuario.
                    // La BD genera automáticamente el Idusuario.
                    context.Usuario.Add(objUsuario);
                    context.SaveChanges();

                    // Aquí ya tenemos el Idusuario generado por la BD.
                    int idUsuarioGenerado = objUsuario.Idusuario;

                    // Como el cliente se creó a sí mismo,
                    // su CreatedBy será su propio Idusuario.
                    objUsuario.CreatedBy = idUsuarioGenerado;
                    context.SaveChanges();

                    // Ahora vinculamos el cliente con el usuario creado.
                    objCliente.Idusuario = idUsuarioGenerado;
                    objCliente.CreatedBy = idUsuarioGenerado;
                    objCliente.CreatedAt = DateTime.Now;

                    context.Cliente.Add(objCliente);
                    context.SaveChanges();

                    respuesta = "Cliente registrado correctamente.";
                }
            }

            return respuesta;
        }
    }
}
