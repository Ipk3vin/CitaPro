using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DUsuario
    {
        public UsuarioSesion Login(string dni, string contrasena)
        {
            UsuarioSesion sesionTemp = null;

            using (var context = new DBcitaproEntities())
            {
                Usuario usuarioTemp = null;

                foreach (var u in context.Usuario)
                {
                    if (u.Dni == dni && u.Contraseña == contrasena)
                    {
                        usuarioTemp = u;
                        break;
                    }
                }

                if (usuarioTemp == null)
                {
                    return null;
                }

                if (usuarioTemp.Idtipo == 1)
                {
                    sesionTemp = new UsuarioSesion
                    {
                        Idusuario = usuarioTemp.Idusuario,
                        Idtipo = usuarioTemp.Idtipo,
                        IdConsultor = null,
                        IdCliente = null,
                        Nombre = usuarioTemp.Nombre,
                        Dni = usuarioTemp.Dni,
                        Rol = "Administrador"
                    };
                }
                else if (usuarioTemp.Idtipo == 2)
                {
                    Consultor consultorTemp = null;

                    foreach (var c in context.Consultor)
                    {
                        if (c.Idusuario == usuarioTemp.Idusuario)
                        {
                            consultorTemp = c;
                            break;
                        }
                    }

                    if (consultorTemp == null)
                    {
                        return null;
                    }

                    sesionTemp = new UsuarioSesion
                    {
                        Idusuario = usuarioTemp.Idusuario,
                        Idtipo = usuarioTemp.Idtipo,
                        IdConsultor = consultorTemp.IdConsultor,
                        IdCliente = null,
                        Nombre = usuarioTemp.Nombre,
                        Dni = usuarioTemp.Dni,
                        Rol = "Consultor"
                    };
                }
                else if (usuarioTemp.Idtipo == 3)
                {
                    Cliente clienteTemp = null;

                    foreach (var c in context.Cliente)
                    {
                        if (c.Idusuario == usuarioTemp.Idusuario)
                        {
                            clienteTemp = c;
                            break;
                        }
                    }

                    if (clienteTemp == null)
                    {
                        return null;
                    }

                    sesionTemp = new UsuarioSesion
                    {
                        Idusuario = usuarioTemp.Idusuario,
                        Idtipo = usuarioTemp.Idtipo,
                        IdConsultor = null,
                        IdCliente = clienteTemp.IdCliente,
                        Nombre = usuarioTemp.Nombre,
                        Dni = usuarioTemp.Dni,
                        Rol = "Cliente"
                    };
                }
            }

            return sesionTemp;
        }
    }
}