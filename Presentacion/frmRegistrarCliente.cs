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
    public partial class frmRegistrarCliente : Form
    {
        NCliente objNegocio = new NCliente();

        public frmRegistrarCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
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

            Cliente objCliente = new Cliente();

            string mensaje = objNegocio.RegistrarCliente(objUsuario, objCliente);

            MessageBox.Show(mensaje);

            if (mensaje == "Cliente registrado correctamente.")
            {
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
            cboSexo.SelectedIndex = -1;

            txtNombre.Focus();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
