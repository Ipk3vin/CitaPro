using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Reportes
{
    public class DReporteAdministrador
    {

        public class DtoIngresosTotales
        {
            public decimal TotalDinero { get; set; }
            public int TotalCitas { get; set; }
        }

        // Reporte 2
        public class DtoRentabilidadConsultor
        {
            public int IdConsultor { get; set; }
            public string NombreConsultor { get; set; }
            public decimal TotalIngresos { get; set; }
            public int CitasAtendidas { get; set; }
            public decimal TicketPromedio { get; set; }
        }

        // Reporte 3
        public class DtoRentabilidadRubro
        {
            public string NombreRubro { get; set; }
            public decimal TotalIngresos { get; set; }
            public int CitasAtendidas { get; set; }
            public decimal TicketPromedio { get; set; }
        }

        // Reporte 4
        public class DtoDemandaRubro
        {
            public string NombreRubro { get; set; }
            public int CantidadCitas { get; set; }
        }

        // Reporte 5
        public class DtoCitasPorEstado
        {
            public string Estado { get; set; }
            public int Cantidad { get; set; }
        }

        // Reporte 6
        public class DtoOcupacionConsultor
        {
            public string NombreConsultor { get; set; }
            public string EstadoHorario { get; set; }
            public int CantidadHorarios { get; set; }
        }

        // Reporte 7
        public class DtoProductividadComparativa
        {
            public string NombreConsultor { get; set; }
            public int CitasAtendidas { get; set; }
            public decimal TotalIngresos { get; set; }
            public int CitasCanceladas { get; set; }
            public int TotalHorariosAsignados { get; set; }
        }

        // 1. Ingresos totales acumulados
        public DtoIngresosTotales ObtenerIngresosTotales(DateTime inicio, DateTime fin, int idRubro, string estadoCita)
        {
            using (var contexto = new DBcitaproEntities())
            {
                var query = from c in contexto.Cita
                            where c.HorarioConsultor.FechaHoraInicio >= inicio && c.HorarioConsultor.FechaHoraInicio <= fin
                                  && (idRubro == 0 || c.HorarioConsultor.Consultor.IdRubro == idRubro)
                                  && (estadoCita == "Todos" || c.Estado.NombreEstado == estadoCita) // Cambiar NombreEstado si se llama distinto
                            select c;

                var resultado = new DtoIngresosTotales();
                resultado.TotalCitas = query.Count();
                resultado.TotalDinero = query.Any() ? query.Sum(c => (decimal?)c.Monto) ?? 0 : 0;

                return resultado;
            }
        }

        // 2. Rentabilidad por consultor
        public List<DtoRentabilidadConsultor> ObtenerRentabilidadPorConsultor(DateTime inicio, DateTime fin, int idConsultor, int idRubro, string estadoCita)
        {
            using (var contexto = new DBcitaproEntities())
            {
                var query = from c in contexto.Cita
                            where c.HorarioConsultor.FechaHoraInicio >= inicio && c.HorarioConsultor.FechaHoraInicio <= fin
                                  && (idConsultor == 0 || c.HorarioConsultor.IdConsultor == idConsultor)
                                  && (idRubro == 0 || c.HorarioConsultor.Consultor.IdRubro == idRubro)
                                  && (estadoCita == "Todos" || c.Estado.NombreEstado == estadoCita)
                            group c by new { c.HorarioConsultor.IdConsultor, c.HorarioConsultor.Consultor.Usuario.Nombre } into grupo
                            select new DtoRentabilidadConsultor
                            {
                                IdConsultor = grupo.Key.IdConsultor,
                                NombreConsultor = grupo.Key.Nombre,
                                TotalIngresos = grupo.Sum(c => (decimal?)c.Monto) ?? 0,
                                CitasAtendidas = grupo.Count(),
                                TicketPromedio = grupo.Count() > 0 ? (grupo.Sum(c => (decimal?)c.Monto) ?? 0) / grupo.Count() : 0
                            };

                return query.ToList();
            }
        }

        // 3. Rentabilidad por rubro
        public List<DtoRentabilidadRubro> ObtenerRentabilidadPorRubro(DateTime inicio, DateTime fin, int idRubro, string estadoCita)
        {
            using (var contexto = new DBcitaproEntities())
            {
                var query = from c in contexto.Cita
                            where c.HorarioConsultor.FechaHoraInicio >= inicio && c.HorarioConsultor.FechaHoraInicio <= fin
                                  && (idRubro == 0 || c.HorarioConsultor.Consultor.IdRubro == idRubro)
                                  && (estadoCita == "Todos" || c.Estado.NombreEstado == estadoCita)
                            group c by c.HorarioConsultor.Consultor.Rubro.NombreRubro into grupo
                            select new DtoRentabilidadRubro
                            {
                                NombreRubro = grupo.Key,
                                // AQUÍ ESTABA EL ERROR: Ya lo corregí a "grupo.Sum"
                                TotalIngresos = grupo.Sum(c => (decimal?)c.Monto) ?? 0,
                                CitasAtendidas = grupo.Count(),
                                TicketPromedio = grupo.Count() > 0 ? (grupo.Sum(c => (decimal?)c.Monto) ?? 0) / grupo.Count() : 0
                            };

                return query.ToList();
            }
        }

        // 4. Demanda por rubro
        public List<DtoDemandaRubro> ObtenerDemandaPorRubro(DateTime inicio, DateTime fin, int idRubro, string estadoCita)
        {
            using (var contexto = new DBcitaproEntities())
            {
                var query = from c in contexto.Cita
                            where c.HorarioConsultor.FechaHoraInicio >= inicio && c.HorarioConsultor.FechaHoraInicio <= fin
                                  && (idRubro == 0 || c.HorarioConsultor.Consultor.IdRubro == idRubro)
                                  && (estadoCita == "Todos" || c.Estado.NombreEstado == estadoCita)
                            group c by c.HorarioConsultor.Consultor.Rubro.NombreRubro into grupo
                            select new DtoDemandaRubro
                            {
                                NombreRubro = grupo.Key,
                                CantidadCitas = grupo.Count()
                            };

                return query.ToList();
            }
        }

        // 5. Citas por estado
        public List<DtoCitasPorEstado> ObtenerCitasPorEstado(DateTime inicio, DateTime fin, string estado, int idConsultor, int idRubro)
        {
            using (var contexto = new DBcitaproEntities())
            {
                var query = from c in contexto.Cita
                            where c.HorarioConsultor.FechaHoraInicio >= inicio && c.HorarioConsultor.FechaHoraInicio <= fin
                                  && (estado == "Todos" || c.Estado.NombreEstado == estado)
                                  && (idConsultor == 0 || c.HorarioConsultor.IdConsultor == idConsultor)
                                  && (idRubro == 0 || c.HorarioConsultor.Consultor.IdRubro == idRubro)
                            group c by c.Estado.NombreEstado into grupo
                            select new DtoCitasPorEstado
                            {
                                Estado = grupo.Key,
                                Cantidad = grupo.Count()
                            };

                return query.ToList();
            }
        }

        // 6. Ocupación de consultores
        public List<DtoOcupacionConsultor> ObtenerOcupacionConsultores(DateTime inicio, DateTime fin, int idConsultor, int idRubro, string estadoHorario)
        {
            using (var contexto = new DBcitaproEntities())
            {
                var query = from h in contexto.HorarioConsultor
                            where h.FechaHoraInicio >= inicio && h.FechaHoraInicio <= fin
                                  && (idConsultor == 0 || h.IdConsultor == idConsultor)
                                  && (idRubro == 0 || h.Consultor.IdRubro == idRubro)
                                  && (estadoHorario == "Todos" || h.EstadoHorario.NombreEstado == estadoHorario) // Cambiar NombreEstadoHorario si se llama distinto
                            group h by new { h.Consultor.Usuario.Nombre, h.EstadoHorario.NombreEstado } into grupo
                            select new DtoOcupacionConsultor
                            {
                                NombreConsultor = grupo.Key.Nombre,
                                EstadoHorario = grupo.Key.NombreEstado,
                                CantidadHorarios = grupo.Count()
                            };

                return query.ToList();
            }
        }

        // 7. Productividad comparativa de consultores
        public List<DtoProductividadComparativa> ObtenerProductividadComparativa(DateTime inicio, DateTime fin, int idConsultor, int idRubro)
        {
            DateTime inicioBusqueda = inicio.Date;
            DateTime finBusqueda = fin.Date.AddDays(1);

            using (var contexto = new DBcitaproEntities())
            {
                var consultoresQuery = from co in contexto.Consultor
                                       select new { co.IdConsultor, co.Usuario.Nombre, co.IdRubro };

                var listaConsultores = consultoresQuery
                    .Where(co => (idConsultor == 0 || co.IdConsultor == idConsultor)
                                 && (idRubro == 0 || co.IdRubro == idRubro))
                    .ToList();

                var resultado = new List<DtoProductividadComparativa>();

                foreach (var con in listaConsultores)
                {
                    var citasDelConsultor = contexto.Cita
                        .Where(c => c.HorarioConsultor.IdConsultor == con.IdConsultor
                                    && c.HorarioConsultor.FechaHoraInicio >= inicioBusqueda
                                    && c.HorarioConsultor.FechaHoraInicio < finBusqueda)
                        .ToList();

                    var horariosDelConsultor = contexto.HorarioConsultor
                        .Count(h => h.IdConsultor == con.IdConsultor
                                    && h.FechaHoraInicio >= inicioBusqueda
                                    && h.FechaHoraInicio < finBusqueda);

                    var item = new DtoProductividadComparativa
                    {
                        NombreConsultor = con.Nombre,
                        // CORRECCIÓN DE ESTADOS: Antes decían "Atendida" y "Cancelada"
                        CitasAtendidas = citasDelConsultor.Count(c => c.Estado.NombreEstado == "Asistió"),
                        CitasCanceladas = citasDelConsultor.Count(c => c.Estado.NombreEstado == "Cancelado"),
                        TotalIngresos = citasDelConsultor.Where(c => c.Estado.NombreEstado == "Asistió").Sum(c => (decimal?)c.Monto) ?? 0,
                        TotalHorariosAsignados = horariosDelConsultor
                    };
                    resultado.Add(item);
                }

                return resultado;
            }
        }
        }
    }

