using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DConsultores
    {

        //Para registrar un consultor
        public string RegistrarConsultor(Usuario objUsuario, Consultor objConsultor, int idUsuarioSesion)
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
                    objUsuario.CreatedBy = idUsuarioSesion;
                    objUsuario.CreatedAt = DateTime.Now;
                    objUsuario.Idtipo = 2;

                    // La BD genera automáticamente el Idusuario
                    context.Usuario.Add(objUsuario);
                    context.SaveChanges();

                    // Aquí se recupera el Idusuario generado por la BD
                    int idUsuarioGenerado = objUsuario.Idusuario;

                    objConsultor.Idusuario = idUsuarioGenerado;
                    objConsultor.Estado = "Activo";
                    objConsultor.CreatedBy = idUsuarioSesion;
                    objConsultor.CreatedAt = DateTime.Now;

                    // La BD genera automáticamente el IdConsultor
                    context.Consultor.Add(objConsultor);
                    context.SaveChanges();

                    respuesta = "Consultor registrado correctamente.";
                }
            }

            return respuesta;
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

        // Buscar consultor por DNI
        public ConsultorVista BuscarConsultorPorDni(string dni)
        {
            ConsultorVista consultorTemp = null;

            using (var contexto = new DBcitaproEntities())
            {
                var consultor = from c in contexto.Consultor
                                join u in contexto.Usuario on c.Idusuario equals u.Idusuario
                                join r in contexto.Rubro on c.IdRubro equals r.IdRubro
                                where u.Dni == dni && c.Estado != "Inactivo"
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

                foreach (var item in consultor)
                {
                    consultorTemp = item;
                    break;
                }
            }
            return consultorTemp;

        }

        // Habilitar o deshabilitar consultor
        public string CambiarEstadoConsultor(int idConsultor, bool habilitar)
        {
            using (var contexto = new DBcitaproEntities())
            {
                Consultor consultor = contexto.Consultor.Find(idConsultor);

                if (consultor == null)
                {
                    return "No se encontró el consultor.";
                }

                if (habilitar == true)
                {
                    consultor.Estado = "Activo";
                }
                else
                {
                    consultor.Estado = "Inactivo";
                }

                contexto.SaveChanges();

                return "Estado del consultor actualizado correctamente.";
            }
        }

        // Eliminar consultor
        public string EliminarConsultor(int idConsultor)
        {
            using (var contexto = new DBcitaproEntities())
            {
                Consultor consultorTemp = null;

                foreach (var c in contexto.Consultor)
                {
                    if (c.IdConsultor == idConsultor)
                    {
                        consultorTemp = c;
                        break;
                    }
                }

                if (consultorTemp == null)
                {
                    return "No se encontró el consultor.";
                }

                int idUsuario = consultorTemp.Idusuario;

                // Primero eliminamos el consultor
                contexto.Consultor.Remove(consultorTemp);
                contexto.SaveChanges();

                Usuario usuarioTemp = null;

                foreach (var u in contexto.Usuario)
                {
                    if (u.Idusuario == idUsuario)
                    {
                        usuarioTemp = u;
                        break;
                    }
                }

                if (usuarioTemp != null)
                {
                    contexto.Usuario.Remove(usuarioTemp);
                    contexto.SaveChanges();
                }

                return "Consultor eliminado correctamente.";
            }
        }

        //modificar lso datos de consultor 
        public ConsultorVista ObtenerConsultorPorId(int idConsultor)
        {
            ConsultorVista consultorTemp = null;

            using (var context = new DBcitaproEntities())
            {
                var query = from c in context.Consultor
                            join u in context.Usuario on c.Idusuario equals u.Idusuario
                            join r in context.Rubro on c.IdRubro equals r.IdRubro
                            where c.IdConsultor == idConsultor
                            select new ConsultorVista
                            {
                                IdConsultor = c.IdConsultor,
                                Idusuario = u.Idusuario,
                                IdRubro = c.IdRubro,

                                Nombre = u.Nombre,
                                Dni = u.Dni,
                                Sexo = u.Sexo,
                                Telefono = u.Telefono,
                                Correo = u.Correo,
                                Contraseña = u.Contraseña,

                                Rubro = r.NombreRubro,
                                Descripcion = c.Descripcion,
                                Monto = c.Monto,
                                Estado = c.Estado
                            };

                foreach (var item in query)
                {
                    consultorTemp = item;
                    break;
                }
            }

            return consultorTemp;
        }

        public string ActualizarConsultor(int idConsultor, Usuario objUsuario, Consultor objConsultor)
        {
            string respuesta = "";

            using (var context = new DBcitaproEntities())
            {
                Consultor consultorTemp = null;

                foreach (var c in context.Consultor)
                {
                    if (c.IdConsultor == idConsultor)
                    {
                        consultorTemp = c;
                        break;
                    }
                }

                if (consultorTemp == null)
                {
                    return "No se encontró el consultor.";
                }

                Usuario usuarioTemp = null;

                foreach (var u in context.Usuario)
                {
                    if (u.Idusuario == consultorTemp.Idusuario)
                    {
                        usuarioTemp = u;
                        break;
                    }
                }

                if (usuarioTemp == null)
                {
                    return "No se encontró el usuario relacionado al consultor.";
                }

                Usuario usuarioConMismoDni = null;

                foreach (var u in context.Usuario)
                {
                    if (u.Dni == objUsuario.Dni && u.Idusuario != usuarioTemp.Idusuario)
                    {
                        usuarioConMismoDni = u;
                        break;
                    }
                }

                if (usuarioConMismoDni != null)
                {
                    return "Ya existe otro usuario registrado con ese DNI.";
                }

                // Actualizar datos de Usuario
                usuarioTemp.Nombre = objUsuario.Nombre;
                usuarioTemp.Dni = objUsuario.Dni;
                usuarioTemp.Sexo = objUsuario.Sexo;
                usuarioTemp.Telefono = objUsuario.Telefono;
                usuarioTemp.Correo = objUsuario.Correo;
                usuarioTemp.Contraseña = objUsuario.Contraseña;

                // Actualizar datos de Consultor
                consultorTemp.IdRubro = objConsultor.IdRubro;
                consultorTemp.Descripcion = objConsultor.Descripcion;
                consultorTemp.Monto = objConsultor.Monto;

                context.SaveChanges();

                respuesta = "Consultor actualizado correctamente.";
            }

            return respuesta;
        }


        //clientes

        public List<ConsultorVista> ListarConsultoresPorRubro(int idRubro)
        {
            using (var contexto = new DBcitaproEntities())
            {
                var lista = from c in contexto.Consultor
                            join u in contexto.Usuario on c.Idusuario equals u.Idusuario
                            join r in contexto.Rubro on c.IdRubro equals r.IdRubro
                            where c.IdRubro == idRubro
                                  && c.Estado == "Activo"
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











































    }
}

