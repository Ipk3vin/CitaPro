using Datos;
using Datos.dao;
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
    public partial class frmReportesConsultor : Form
    {
        private int idUsuarioSesion;
        private NReportesConsultor nReportes = new NReportesConsultor();

        public frmReportesConsultor(int idConsultor)
        {
            InitializeComponent();
            idUsuarioSesion = idConsultor;
        }

        private void btnClienteFrecuentes_Click(object sender, EventArgs e)
        {
            frmReporteClientes frm = new frmReporteClientes(idUsuarioSesion);
            frm.ShowDialog();
        }

        private void btnGraficosIngresos_Click(object sender, EventArgs e)
        {
            frmReporteIngresos frm = new frmReporteIngresos(idUsuarioSesion);
            frm.ShowDialog();
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            frmMenuConsultor frm = new frmMenuConsultor(idUsuarioSesion);
            frm.Show();
            this.Close();
        }

        private void btnReporteCitas_Click(object sender, EventArgs e)
        {
            frmReporteCitas frm = new frmReporteCitas(idUsuarioSesion);
            frm.ShowDialog();
        }
    }
}
