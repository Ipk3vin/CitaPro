using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DConsultores
    {
        // Registrar consultor
        public string RegistrarConsultor(Usuario objUsuario, Consultor objConsultor, int idUsuarioSesion)
        {
            using (var contexto = new DBcitaproEntities())
            {
                using (var transaccion = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        // Asignar auditoría
                        objUsuario.CreatedBy = idUsuarioSesion;
                        objUsuario.CreatedAt = DateTime.Now;

                        contexto.Usuario.Add(objUsuario);
                        contexto.SaveChanges(); // ID autogenerado por SQL Server

                        objConsultor.Idusuario = objUsuario.Idusuario;
                        objConsultor.Estado = "Activo";
                        objConsultor.CreatedBy = idUsuarioSesion;
                        objConsultor.CreatedAt = DateTime.Now;

                        contexto.Consultor.Add(objConsultor);
                        contexto.SaveChanges();

                        transaccion.Commit();
                        return "Consultor registrado correctamente";
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        return "Error al registrar consultor: " + ex.Message;
                    }
                }
            }
        }

        // Listar consultores para DataGridView
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

        // Listar rubros
        public List<Rubro> ListarRubros()
        {
            using (var contexto = new DBcitaproEntities())
            {
                return contexto.Rubro.ToList();
            }
        }


        // Clase para mostrar datos en DataGridView

    } 
}

