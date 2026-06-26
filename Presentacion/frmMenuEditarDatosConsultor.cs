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
    public partial class frmMenuEditarDatosConsultor : Form
    {
        private int idConsultor;
        NConsultor objNegocio = new NConsultor();

        public frmMenuEditarDatosConsultor(int idConsultor)
        {
            InitializeComponent();
            this.idConsultor = idConsultor;
            CargarRubros();
            CargarDatosConsultor();
        }

        private void CargarRubros()
        {
            cboRubro.DataSource = null;
            cboRubro.DataSource = objNegocio.ListarRubros();
            cboRubro.DisplayMember = "NombreRubro";
            cboRubro.ValueMember = "IdRubro";
            cboRubro.SelectedIndex = -1;
        }

        private void CargarDatosConsultor()
        {
            ConsultorVista consultor = objNegocio.ObtenerConsultorPorId(idConsultor);

            if (consultor == null)
            {
                MessageBox.Show("No se encontraron los datos del consultor.");
                this.Close();
                return;
            }

            txtNombre.Text = consultor.Nombre;
            txtDni.Text = consultor.Dni;
            cboSexo.Text = consultor.Sexo;
            txtTelefono.Text = consultor.Telefono;
            txtCorreo.Text = consultor.Correo;

            cboRubro.SelectedValue = consultor.IdRubro;

            txtDescripcion.Text = consultor.Descripcion;
            txtMonto.Text = consultor.Monto.ToString();

            txtContrasena.Text = consultor.Contraseña;
            txtConfirmarContrasena.Text = consultor.Contraseña;
        }
        private void btnActualizarConsultor_Click(object sender, EventArgs e)
        {
            decimal monto;

            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            if (txtContrasena.Text.Trim() != txtConfirmarContrasena.Text.Trim())
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            if (cboRubro.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un rubro.");
                return;
            }

            Usuario objUsuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Dni = txtDni.Text.Trim(),
                Sexo = cboSexo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Contraseña = txtContrasena.Text.Trim()
            };

            Consultor objConsultor = new Consultor
            {
                IdRubro = Convert.ToInt32(cboRubro.SelectedValue),
                Descripcion = txtDescripcion.Text,
                Monto = monto
            };

            string mensaje = objNegocio.ActualizarConsultor(
                idConsultor,
                objUsuario,
                objConsultor
            );

            MessageBox.Show(mensaje);

            if (mensaje == "Consultor actualizado correctamente.")
            {
                this.Close();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
