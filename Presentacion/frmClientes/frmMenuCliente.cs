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
    public partial class frmMenuCliente : Form
    {
        private int idUsuarioSesion;
        public frmMenuCliente(int idCliente)
        {
            InitializeComponent();
            idUsuarioSesion = idCliente;
        }

        private void btn_NuevaCita_Click(object sender, EventArgs e)
        {
            frmNuevaCita frm = new frmNuevaCita(idUsuarioSesion);
            frm.Show();
        }

        private void btn_MisCitas_Click(object sender, EventArgs e)
        {
            frmMisCitas frm = new frmMisCitas(idUsuarioSesion);
            frm.Show();
        }










    }
}
