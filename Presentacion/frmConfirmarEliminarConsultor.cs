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
    public partial class frmConfirmarEliminarConsultor : Form
    {
        private int idConsultor;
        private int idUsuarioSesion;
        NConsultor objConsultor = new NConsultor();
        public frmConfirmarEliminarConsultor(int idConsul, int idUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            idConsultor = idConsul;
            idUsuarioSesion = idUsuario;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string mensaje = objConsultor.EliminarConsultor(idConsultor);

            MessageBox.Show(mensaje);

            frmMenuEditarConsultor frm = new frmMenuEditarConsultor(idUsuarioSesion);
            frm.Show();

            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuEditarConsultor frm = new frmMenuEditarConsultor(idUsuarioSesion);
            frm.Show();

            this.Close();
        }
    }
}

