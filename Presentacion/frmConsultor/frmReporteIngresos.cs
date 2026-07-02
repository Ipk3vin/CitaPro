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
using System.Windows.Forms.DataVisualization.Charting;

namespace Presentacion.frmConsultor
{
    public partial class frmReporteIngresos : Form
    {
        private int idUsuarioSesion;
        private NReportesConsultor nReportes = new NReportesConsultor();

        public frmReporteIngresos(int idConsultor)
        {
            InitializeComponent();
            idUsuarioSesion = idConsultor;
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReporteIngresos_Load_1(object sender, EventArgs e)
        {
            try
            {
                int anioActual = DateTime.Now.Year;
                var datosTrimestre = nReportes.ObtenerIngresosPorTrimestre(idUsuarioSesion, anioActual);

                chartIngresos.Series.Clear();
                chartIngresos.Titles.Clear();

                Series serie = new Series("Ingresos");
                serie.ChartType = SeriesChartType.Column;
                serie.IsValueShownAsLabel = true;
                serie.LabelFormat = "S/ {0:0.00}";

                foreach (var item in datosTrimestre)
                {
                    serie.Points.AddXY(item.Trimestre, item.Ingresos);
                }

                chartIngresos.Series.Add(serie);
                chartIngresos.Titles.Add("Comparativa de Ingresos por Trimestre");

                chartIngresos.ChartAreas[0].AxisX.Title = "Trimestres";
                chartIngresos.ChartAreas[0].AxisY.Title = "Ingresos Totales (S/)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ingresos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
