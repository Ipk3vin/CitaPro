using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DConsultores
    {

        public string RegistrarConsultor(Usuario objUsuario, Consultor objConsultor, int idUsuarioSesion)
        {
            using (var contexto = new DBcitaproEntities())
            {
                try
                {
                    // 1. CONFIGURAR DATOS DEL USUARIO
                    objUsuario.CreatedBy = idUsuarioSesion;
                    objUsuario.CreatedAt = DateTime.Now;

                    // Debes asignar el Idtipo, ya que es obligatorio (N-N) en tu BD
                    // Cambia el 2 por el ID real que corresponda a "Consultor" en tu tabla TipoUsuario
                    objUsuario.Idtipo = 2;

                    contexto.Usuario.Add(objUsuario);
                    contexto.SaveChanges(); // El ID se genera automáticamente aquí

                    // 2. CONFIGURAR DATOS DEL CONSULTOR
                    // Usamos el Idusuario recién generado
                    objConsultor.Idusuario = objUsuario.Idusuario;
                    objConsultor.Estado = "Activo";
                    objConsultor.CreatedBy = idUsuarioSesion;
                    objConsultor.CreatedAt = DateTime.Now;

                    // Asegúrate de que IdRubro ya viene cargado desde el formulario (cboRubro)
                    contexto.Consultor.Add(objConsultor);

                    contexto.SaveChanges(); // Guardamos el consultor vinculado al usuario

                    return "Consultor registrado correctamente";
                }
                catch (Exception ex)
                {
                    // Vamos a buscar en todas las capas de la excepción
                    Exception errorActual = ex;
                    while (errorActual.InnerException != null)
                    {
                        errorActual = errorActual.InnerException;
                    }

                    // Ahora 'errorActual' tiene el mensaje real, incluso si es muy profundo
                    return "Error real: " + errorActual.Message;
                }
            }
        }

        public List<ConsultorVista> ListarConsultores()
        {
            using (var contexto = new DBcitaproEntities())
            {
                var lista = from c in contexto.Consultor
                            join u in contexto.Usuario on c.Idusuario equals u.Idusuario
                            join r in contexto.Rubro on c.IdRubro equals r.IdRubro
                            select new ConsultorVista
                            {
                                IdConsultor = c.IdConsultor,
                                Nombre = u.Nombre,
                                Dni = u.Dni,
                                Sexo = u.Sexo,
                                Telefono = u.Telefono,
                                Correo = u.Correo,
                                Rubro = r.NombreRubro,
                                Descripcion = c.Descripcion,
                                Monto = c.Monto,
                                Estado = c.Estado
                            };

                return lista.ToList();
            }
        }

        public List<Rubro> ListarRubros()
        {
            using (var contexto = new DBcitaproEntities())
            {
                return contexto.Rubro.ToList();
            }
        }

    } 
}

