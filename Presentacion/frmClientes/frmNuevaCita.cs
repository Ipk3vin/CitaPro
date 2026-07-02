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
    public partial class frmNuevaCita : Form
    {
        NConsultor objConsultor = new NConsultor();
        NCita objcita = new NCita();
        NHorarioConsultor objHorario = new NHorarioConsultor();
        NCita objNegocioCita = new NCita();
        int idConsultorSeleccionado = 0;
        private int idUsuarioSesion;
        private decimal montoSeleccionado = 0;


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

            FormatoDgvConsultores();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboRubro.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rubro.");
                return;
            }

            int idRubro = Convert.ToInt32(cboRubro.SelectedValue);

            dgvConsultores.DataSource = null;
            dgvConsultores.DataSource = objConsultor.ListarConsultoresPorRubro(idRubro);

            FormatoDgvConsultores();
        }

        private void FormatoDgvConsultores()
        {
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

            if (dgvConsultores.Columns["Telefono"] != null)
            {
                dgvConsultores.Columns["Telefono"].HeaderText = "Teléfono";
            }

            if (dgvConsultores.Columns["Correo"] != null)
            {
                dgvConsultores.Columns["Correo"].HeaderText = "Correo";
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
        }


        private void dgvConsultores_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Obtenemos la fila
            var fila = dgvConsultores.Rows[e.RowIndex];

            // Guardamos el ID
            idConsultorSeleccionado = Convert.ToInt32(fila.Cells["IdConsultor"].Value);

            // Guardamos el MONTO convertido a double
            montoSeleccionado = Convert.ToDecimal(fila.Cells["Monto"].Value);

            CargarHorarios();
        }

        private void dtpFecha_Click(object sender, EventArgs e)
        {
            CargarHorarios();
        }
        private void CargarHorarios()
        {
            if (idConsultorSeleccionado == 0) return;

            dgvDetalleConsultor.DataSource =
                objHorario.ListarPorConsultorYFecha(idConsultorSeleccionado, dtpFecha.Value);

            FormatoDgvDetalle();
        }
        private void FormatoDgvDetalle()
        {
            if (dgvDetalleConsultor.Columns.Count == 0) return;

            if (dgvDetalleConsultor.Columns.Contains("IdEstadoHorario"))
            {
                dgvDetalleConsultor.Columns["IdEstadoHorario"].Visible = false;
            }

            if (dgvDetalleConsultor.Columns.Contains("FechaHoraInicio"))
                dgvDetalleConsultor.Columns["FechaHoraInicio"].HeaderText = "Inicio";

            if (dgvDetalleConsultor.Columns.Contains("FechaHoraFin"))
                dgvDetalleConsultor.Columns["FechaHoraFin"].HeaderText = "Fin";

            if (dgvDetalleConsultor.Columns.Contains("NombreEstado"))
                dgvDetalleConsultor.Columns["NombreEstado"].HeaderText = "Estado";
        }

        private void btnGuardarCita_Click(object sender, EventArgs e)
        {
            // 1. Validar selección
            if (dgvDetalleConsultor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un horario.");
                return;
            }

            DataGridViewRow filaSeleccionada = dgvDetalleConsultor.SelectedRows[0];
            string estado = filaSeleccionada.Cells["NombreEstado"].Value.ToString();

            if (estado == "Reservado")
            {
                MessageBox.Show("Este horario ya está reservado. Por favor, selecciona otro.");
                return;
            }

            object valorId = filaSeleccionada.Cells["IdHorario"].Value;

            if (valorId == null || Convert.ToInt32(valorId) == 0)
            {
                MessageBox.Show("Error: El ID del horario no es válido. Verifica la carga de datos.");
                return;
            }

            int idHorarioSeleccionado = Convert.ToInt32(valorId);

            // 4. Crear el objeto
            Cita nuevaCita = new Cita
            {
                IdCliente = idUsuarioSesion,
                IdHorario = idHorarioSeleccionado,
                IdEstado = 4,
                Monto = montoSeleccionado,
                Descripcion = txtDescripcion.Text,
                CreatedAt = DateTime.Now
            };

            // 5. Guardar
            string mensaje = objNegocioCita.RegistrarCita(nuevaCita);
            MessageBox.Show(mensaje);
            CargarHorarios();
        }


    }
}
