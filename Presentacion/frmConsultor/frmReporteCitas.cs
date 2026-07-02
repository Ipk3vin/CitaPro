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

namespace Presentacion.frmConsultor
{
    public partial class frmReporteCitas : Form
    {
        private int idUsuarioSesion;
        private NReportesConsultor nReportes = new NReportesConsultor();

        public frmReporteCitas(int idConsultor)
        {
            InitializeComponent();
            idUsuarioSesion = idConsultor;
        }
        private void frmReporteCitas_Load_1(object sender, EventArgs e)
        {
            try
            {
                var datos = nReportes.ObtenerCitasAtendidas(idUsuarioSesion);
                lblCitasHoy.Text = datos.CitasHoy.ToString();
                lblCitasMes.Text = datos.CitasMes.ToString();
                lblTotalCitas.Text = datos.TotalCitas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
