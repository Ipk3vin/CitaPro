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
            idUsuarioSesion = idAdmin;
        }

        private void btnRegistrarConsultor_Click(object sender, EventArgs e)
        {
            frmRegistrarConsultor frm = new frmRegistrarConsultor(idUsuarioSesion);
            frm.ShowDialog();
        }
    }
}
