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
    public partial class frmMenuAdministrador : Form
    {
        private int idUsuarioSesion;
        public frmMenuAdministrador(int idAdmin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            idUsuarioSesion = idAdmin;
        }

        private void btn_RegistrarConsultor_Click(object sender, EventArgs e)
        {
            frmRegistrarConsultor frm = new frmRegistrarConsultor(idUsuarioSesion);
            frm.Show();

            this.Close();
        }

        private void btn_HabilitarEditarEliminar_Click(object sender, EventArgs e)
        {
            frmMenuEditarConsultor frm = new frmMenuEditarConsultor(idUsuarioSesion);
            frm.Show();

            this.Close();
        }
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            frmLogin frmlogin = new frmLogin();
            frmlogin.Show();

            this.Close();
        }
        private void btn_Auditoria_Click(object sender, EventArgs e)
        {
            frmAuditoria frm = new frmAuditoria(idUsuarioSesion);
            frm.Show();

            this.Close();
        }
    }
}
