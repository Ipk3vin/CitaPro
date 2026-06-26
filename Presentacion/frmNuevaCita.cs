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
    public partial class frmNuevaCita : Form
    {
        NConsultor objConsultor = new NConsultor();
        private int idUsuarioSesion;
        public frmNuevaCita(int id)
        {
            InitializeComponent();
            CargarRubros();
            CargarConsultores();
            idUsuarioSesion = id;
        }

        private void CargarRubros()
        {
            cboRubro.DataSource = null;
            cboRubro.DataSource = objConsultor.ListarRubros();

            cboRubro.DisplayMember = "NombreRubro";
            cboRubro.ValueMember = "IdRubro";

            cboRubro.SelectedIndex = -1;
        }

        private void CargarConsultores()
        {
            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = objConsultor.ListarConsultores();

            if (dgvConsultores.Columns["IdConsultor"] != null)
            {
                dgvConsultores.Columns["IdConsultor"].Visible = false;
            }

            if (dgvConsultores.Columns["Dni"] != null)
            {
                dgvConsultores.Columns["Dni"].Visible = false;
            }

            if (dgvConsultores.Columns["Sexo"] != null)
            {
                dgvConsultores.Columns["Sexo"].Visible = false;
            }

            if (dgvConsultores.Columns["Estado"] != null)
            {
                dgvConsultores.Columns["Estado"].Visible = false;
            }

            if (dgvConsultores.Columns["Idusuario"] != null)
            {
                dgvConsultores.Columns["Idusuario"].Visible = false;
            }

            if (dgvConsultores.Columns["IdRubro"] != null)
            {
                dgvConsultores.Columns["IdRubro"].Visible = false;
            }

            if (dgvConsultores.Columns["Contraseña"] != null)
            {
                dgvConsultores.Columns["Contraseña"].Visible = false;
            }

            if (dgvConsultores.Columns["Nombre"] != null)
            {
                dgvConsultores.Columns["Nombre"].HeaderText = "Nombre";
            }

            if (dgvConsultores.Columns["Rubro"] != null)
            {
                dgvConsultores.Columns["Rubro"].HeaderText = "Rubro";
            }

            if (dgvConsultores.Columns["Descripcion"] != null)
            {
                dgvConsultores.Columns["Descripcion"].HeaderText = "Descripción";
            }

            if (dgvConsultores.Columns["Monto"] != null)
            {
                dgvConsultores.Columns["Monto"].HeaderText = "Monto";
            }

            if (dgvConsultores.Columns["Telefono"] != null)
            {
                dgvConsultores.Columns["Telefono"].HeaderText = "Teléfono";
            }

            if (dgvConsultores.Columns["Correo"] != null)
            {
                dgvConsultores.Columns["Correo"].HeaderText = "Correo";
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


















    }
}
