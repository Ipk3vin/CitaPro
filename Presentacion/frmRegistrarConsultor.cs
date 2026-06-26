using Datos;
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
    public partial class frmRegistrarConsultor : Form
    {
        NConsultor objNegocio = new NConsultor();
        private int idUsuarioSesion;

        public frmRegistrarConsultor(int idAdmin)
        {
            InitializeComponent();
            idUsuarioSesion = idAdmin;
        }

        void ActualizarDgv()
        {
            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = objNegocio.ListarConsultores();
            if (dgvConsultores.Columns["IdConsultor"] != null)
                dgvConsultores.Columns["IdConsultor"].Visible = false;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            decimal monto;
            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Ingrese un monto válido");
                return;
            }

            Usuario objUsuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Dni = txtDni.Text,
                Sexo = cboSexo.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Contraseña = txtContrasena.Text
            };

            Consultor objConsultor = new Consultor
            {
                IdRubro = 2,
                Descripcion = txtDescripcion.Text,
                Monto = monto
            };
            
            string mensaje = objNegocio.RegistrarConsultor(objUsuario, objConsultor, idUsuarioSesion);
            MessageBox.Show(mensaje);
            ActualizarDgv();

        }
    }
}