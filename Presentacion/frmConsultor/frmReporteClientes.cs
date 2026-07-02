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
    public partial class frmReporteClientes : Form
    {
        private int idUsuarioSesion;
        private NReportesConsultor nReportes = new NReportesConsultor();

        public frmReporteClientes(int idConsultor)
        {
            InitializeComponent();
            idUsuarioSesion = idConsultor;
        }


        private void frmReporteClientes_Load_1(object sender, EventArgs e)
        {
            try
            {
                dgvClientes.DataSource = nReportes.ObtenerClientesFrecuentes(idUsuarioSesion);

                // Limpieza visual de la grilla
                dgvClientes.AllowUserToAddRows = false;
                dgvClientes.ReadOnly = true;
                dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
