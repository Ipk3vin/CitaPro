using Datos.Reportes;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmReportes : Form
    {
        // Instancia global de la capa de negocio
        private NReporteAdministrador nReportes = new NReporteAdministrador();
        private NConsultor nConsultor = new NConsultor(); // Tu clase de negocio para Consultores/Rubros

        public frmReportes()
        {
            InitializeComponent();
        }
            

        // Llenar el combo principal con los 7 nombres de tus requerimientos
        private void ConfigurarSelectorReportes()
        {
            cboSeleccionarReporte.Items.Clear();
            cboSeleccionarReporte.Items.Add("1. Ingresos totales acumulados");
            cboSeleccionarReporte.Items.Add("2. Rentabilidad por consultor");
            cboSeleccionarReporte.Items.Add("3. Rentabilidad por rubro");
            cboSeleccionarReporte.Items.Add("4. Demanda por rubro");
            cboSeleccionarReporte.Items.Add("5. Citas por estado");
            cboSeleccionarReporte.Items.Add("6. Ocupación de consultores");
            cboSeleccionarReporte.Items.Add("7. Productividad comparativa de consultores");

            cboSeleccionarReporte.SelectedIndex = 0; // Selecciona el primero por defecto
        }

        // Carga los datos iniciales de tus tablas (puedes usar tus clases NConsultores o NRubros existentes)
        private void CargarFiltrosBase()
        {
            try
            {
                // ---------------------------------------------------------
                // 1. LLENAR COMBOBOX DE RUBROS
                // ---------------------------------------------------------
                // Obtenemos la lista de la base de datos
                var listaRubros = nConsultor.ListarRubros();

                // Creamos un rubro ficticio para la opción "Todos"
                // Asegúrate de que las propiedades coincidan con tu clase real (ej. IdRubro, NombreRubro)
                var rubroTodos = new Datos.Rubro
                {
                    IdRubro = 0,
                    NombreRubro = "Todos"
                };

                // Lo insertamos en la posición 0 (al inicio de la lista)
                listaRubros.Insert(0, rubroTodos);

                // Asignamos la lista al ComboBox
                cboRubro.DataSource = listaRubros;
                cboRubro.DisplayMember = "NombreRubro"; // Lo que ve el usuario
                cboRubro.ValueMember = "IdRubro";       // El valor interno (ID) que usamos para filtrar

                // ---------------------------------------------------------
                // 2. LLENAR COMBOBOX DE CONSULTORES
                // ---------------------------------------------------------
                // Según tu código anterior, esto devuelve una List<ConsultorVista>
                var listaConsultores = nConsultor.ListarConsultores();

                var consultorTodos = new Datos.ConsultorVista
                {
                    IdConsultor = 0,
                    Nombre = "Todos" // Asumiendo que la propiedad se llama 'Nombre'
                };

                listaConsultores.Insert(0, consultorTodos);

                cboConsultor.DataSource = listaConsultores;
                cboConsultor.DisplayMember = "Nombre";      // Lo que ve el usuario
                cboConsultor.ValueMember = "IdConsultor";   // El ID del consultor

                // ---------------------------------------------------------
                // 3. LLENAR COMBOBOX DE ESTADOS (Este puede ser manual)
                // ---------------------------------------------------------
                cboEstado.Items.Clear();
                cboEstado.Items.Add("Todos");
                cboEstado.Items.Add("Atendida");
                cboEstado.Items.Add("Cancelada");
                cboEstado.Items.Add("Pendiente");

                // Dejamos seleccionados "Todos" por defecto en los 3 combos
                cboRubro.SelectedIndex = 0;
                cboConsultor.SelectedIndex = 0;
                cboEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los filtros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento que se ejecuta cuando el usuario cambia de reporte en el ComboBox
        // Sirve para apagar o encender los filtros que no necesita el reporte seleccionado
        
        private void frmReportes_Load(object sender, EventArgs e)
        {
            ConfigurarSelectorReportes();
            CargarFiltrosBase();
        }

        private void cboSeleccionarReporte_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int reporteSeleccionado = cboSeleccionarReporte.SelectedIndex + 1;

            // Por defecto encendemos las fechas
            dtpInicio.Enabled = true;
            dtpFin.Enabled = true;

            // Control dinámico de filtros según tus reglas establecidas:
            switch (reporteSeleccionado)
            {
                case 1: // Ingresos totales: Filtros: rango de fechas, rubro, estado de cita.
                case 3: // Rentabilidad por rubro: Filtros: rango de fechas, rubro, estado de cita.
                case 4: // Demanda por rubro: Filtros: rango de fechas, rubro, estado de cita.
                    cboRubro.Enabled = true;
                    cboEstado.Enabled = true;
                    cboConsultor.Enabled = false; // No lo necesita
                    break;

                case 2: // Rentabilidad por consultor: Filtros: rango de fechas, consultor, rubro, estado de cita.
                    cboRubro.Enabled = true;
                    cboConsultor.Enabled = true;
                    cboEstado.Enabled = true;
                    break;

                case 5: // Citas por estado: Filtros: rango de fechas, estado, consultor, rubro.
                    cboEstado.Enabled = true;
                    cboConsultor.Enabled = true;
                    cboRubro.Enabled = true;
                    break;

                case 6: // Ocupación de consultores: Filtros: rango de fechas, consultor, rubro, estado de horario.
                    cboConsultor.Enabled = true;
                    cboRubro.Enabled = true;
                    cboEstado.Enabled = true; // Aquí actúa como estado de horario
                    break;

                case 7: // Productividad comparativa: Filtros: rango de fechas, consultor, rubro.
                    cboConsultor.Enabled = true;
                    cboRubro.Enabled = true;
                    cboEstado.Enabled = false; // No lo necesita
                    break;
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {

            try
            {
                // 1. Recolección de variables comunes
                DateTime inicio = dtpInicio.Value.Date;
                DateTime fin = dtpFin.Value.Date;

                int idRubro = cboRubro.SelectedValue != null ? Convert.ToInt32(cboRubro.SelectedValue) : 0;
                int idConsultor = cboConsultor.SelectedValue != null ? Convert.ToInt32(cboConsultor.SelectedValue) : 0;
                string estadoTexto = cboEstado.SelectedItem != null ? cboEstado.SelectedItem.ToString() : "Todos";

                int reporteSeleccionado = cboSeleccionarReporte.SelectedIndex + 1;

                // Limpiamos el origen de datos anterior para evitar conflictos visuales
                dgvReportes.DataSource = null;

                // 2. Ejecución del reporte seleccionado
                switch (reporteSeleccionado)
                {
                    case 1:
                        var ingresoTotal = nReportes.ObtenerIngresosTotales(inicio, fin, idRubro, estadoTexto);
                        dgvReportes.DataSource = new List<DReporteAdministrador.DtoIngresosTotales> { ingresoTotal };
                        break;

                    case 2:
                        dgvReportes.DataSource = nReportes.ObtenerRentabilidadPorConsultor(inicio, fin, idConsultor, idRubro, estadoTexto);
                        break;

                    case 3:
                        dgvReportes.DataSource = nReportes.ObtenerRentabilidadPorRubro(inicio, fin, idRubro, estadoTexto);
                        break;

                    case 4:
                        dgvReportes.DataSource = nReportes.ObtenerDemandaPorRubro(inicio, fin, idRubro, estadoTexto);
                        break;

                    case 5:
                        dgvReportes.DataSource = nReportes.ObtenerCitasPorEstado(inicio, fin, estadoTexto, idConsultor, idRubro);
                        break;

                    case 6:
                        dgvReportes.DataSource = nReportes.ObtenerOcupacionConsultores(inicio, fin, idConsultor, idRubro, estadoTexto);
                        break;

                    case 7:
                        dgvReportes.DataSource = nReportes.ObtenerProductividadComparativa(inicio, fin, idConsultor, idRubro);
                        break;
                }

                if (dgvReportes.DataSource != null)
                {
                    dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
