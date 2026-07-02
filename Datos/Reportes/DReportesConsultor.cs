using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Reportes
{
    public class DReportesConsultor
    {
        // --- Clases DTO para transportar los datos ---
        public class DtoCitasAtendidas
        {
            public int CitasHoy { get; set; }
            public int CitasMes { get; set; }
            public int TotalCitas { get; set; }
        }

        public class DtoIngresosTrimestre
        {
            public string Trimestre { get; set; }
            public decimal Ingresos { get; set; }
            public int NumeroTrimestre { get; set; } // Para ordenar correctamente
        }

        public class DtoClienteFrecuente
        {
            public string ClienteFrecuente { get; set; }
            public int NumeroDeCitas { get; set; }
        }

        // --- 1. Método para Reporte de Citas Atendidas (Figura 11) ---
        public DtoCitasAtendidas ObtenerCitasAtendidas(int idConsultor)
        {
            using (var db = new DBcitaproEntities())
            {
                DateTime hoy = DateTime.Today;
                DateTime inicioMes = new DateTime(hoy.Year, hoy.Month, 1);
                DateTime finHoy = hoy.AddDays(1);
                DateTime finMes = inicioMes.AddMonths(1);

                // Traemos todas las citas atendidas del consultor a memoria para contarlas
                // Usamos "Asistió" basado en tu base de datos anterior
                var citasAtendidas = db.Cita
                    .Where(c => c.HorarioConsultor.IdConsultor == idConsultor && c.Estado.NombreEstado == "Asistió")
                    .Select(c => c.HorarioConsultor.FechaHoraInicio)
                    .ToList();

                return new DtoCitasAtendidas
                {
                    TotalCitas = citasAtendidas.Count,
                    CitasHoy = citasAtendidas.Count(f => f.HasValue && f.Value >= hoy && f.Value < finHoy),
                    CitasMes = citasAtendidas.Count(f => f.HasValue && f.Value >= inicioMes && f.Value < finMes)
                };
            }
        }

        // --- 2. Método para Reporte de Ingresos por Trimestre (Figura 12) ---
        public List<DtoIngresosTrimestre> ObtenerIngresosPorTrimestre(int idConsultor, int anio)
        {
            using (var db = new DBcitaproEntities())
            {
                // Obtenemos las citas del año solicitado
                var citasAnio = db.Cita
                    .Where(c => c.HorarioConsultor.IdConsultor == idConsultor
                             && c.Estado.NombreEstado == "Asistió"
                             && c.HorarioConsultor.FechaHoraInicio.HasValue
                             && c.HorarioConsultor.FechaHoraInicio.Value.Year == anio)
                    .Select(c => new
                    {
                        Mes = c.HorarioConsultor.FechaHoraInicio.Value.Month,
                        Monto = c.Monto
                    })
                    .ToList();

                // Agrupamos por trimestre matemáticamente
                var reporte = citasAnio
                    .GroupBy(c => (c.Mes - 1) / 3 + 1) // Formula para sacar el trimestre (1 a 4)
                    .Select(g => new DtoIngresosTrimestre
                    {
                        NumeroTrimestre = g.Key,
                        Trimestre = ObtenerNombreTrimestre(g.Key),
                        Ingresos = g.Sum(c => (decimal?)c.Monto) ?? 0
                    })
                    .OrderBy(t => t.NumeroTrimestre)
                    .ToList();

                return reporte;
            }
        }

        private string ObtenerNombreTrimestre(int numeroTrimestre)
        {
            switch (numeroTrimestre)
            {
                case 1: return "Trimestre 1 (ENE-FEB-MAR)";
                case 2: return "Trimestre 2 (ABR-MAY-JUN)";
                case 3: return "Trimestre 3 (JUL-AGO-SEP)";
                case 4: return "Trimestre 4 (OCT-NOV-DIC)";
                default: return "Desconocido";
            }
        }

        // --- 3. Método para Reporte de Clientes Frecuentes (Figura 13) ---
        public List<DtoClienteFrecuente> ObtenerClientesFrecuentes(int idConsultor)
        {
            using (var db = new DBcitaproEntities())
            {
                // Agrupamos por el nombre del cliente
                var query = db.Cita
                    .Where(c => c.HorarioConsultor.IdConsultor == idConsultor && c.Estado.NombreEstado == "Asistió")
                    .GroupBy(c => c.Cliente.Usuario.Nombre) // Ajusta esta ruta a cómo llegas al Nombre del Cliente en tu BD
                    .Select(g => new DtoClienteFrecuente
                    {
                        ClienteFrecuente = g.Key,
                        NumeroDeCitas = g.Count()
                    })
                    .OrderByDescending(x => x.NumeroDeCitas) // Ordenamos de mayor a menor
                    .Take(10) // Mostramos solo el Top 10
                    .ToList();

                return query;
            }
        }
    }
}
