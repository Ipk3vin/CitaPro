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

        private void frmRegistrarConsultor_Load(object sender, EventArgs e)
        {
            cboRubro.DataSource = objNegocio.ListarRubros();
            cboRubro.DisplayMember = "NombreRubro";
            cboRubro.ValueMember = "IdRubro";
            cboRubro.SelectedIndex = -1;

            cboSexo.Items.Add("Masculino");
            cboSexo.Items.Add("Femenino");

            ActualizarDgv();
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
                IdRubro = Convert.ToInt32(cboRubro.SelectedValue),
                Descripcion = txtDescripcion.Text,
                Monto = monto
            };

            string mensaje = objNegocio.RegistrarConsultor(objUsuario, objConsultor, txtConfirmarContrasena.Text, idUsuarioSesion);
            MessageBox.Show(mensaje);
            ActualizarDgv();
        }
    }
}