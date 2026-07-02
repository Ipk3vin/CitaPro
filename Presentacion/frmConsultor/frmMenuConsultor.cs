using Presentacion.frmConsultor;
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
    public partial class frmMenuConsultor : Form
    {
        private int idUsuarioSesion;
        public frmMenuConsultor(int idconsultor)
        {
            InitializeComponent();
            idUsuarioSesion = idconsultor;
        }

        private void btnConsultarCitas_Click(object sender, EventArgs e)
        {
            frmConsultarCitas frm = new frmConsultarCitas(idUsuarioSesion);
            frm.Show();
        }

        private void btnModificarContrasena_Click(object sender, EventArgs e)
        {
            frmModificarContrasena frm = new frmModificarContrasena();
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmReportesConsultor frm = new frmReportesConsultor(idUsuarioSesion);
            frm.Show();
            this.Close();
        }
    }
}
