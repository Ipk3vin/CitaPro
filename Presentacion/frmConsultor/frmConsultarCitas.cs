using Datos;
using Datos.Clientes;
using Negocio;
using Presentacion;
using Presentacion.frmConsultor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.frmConsultor
{
    public partial class frmConsultarCitas : Form
    {
        private int idUsuarioSesion;
        private NCita nCitas = new NCita();
        public frmConsultarCitas(int idconsultor)
        {
            InitializeComponent();
            idUsuarioSesion = idconsultor;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuConsultor frm = new frmMenuConsultor(idUsuarioSesion);
            frm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFecha.Value.Date;

                // Llamamos al método actualizado
                var listaCitas = nCitas.BuscarCitasPorFecha(fecha, idUsuarioSesion);

                dgvCitas.DataSource = listaCitas;

                if (dgvCitas.Columns["IdEstado"] != null)
                    dgvCitas.Columns["IdEstado"].Visible = false;

                // Opcional: Ocultar también el IdCita si no quieres que el consultor lo vea
                if (dgvCitas.Columns["IdCita"] != null)
                    dgvCitas.Columns["IdCita"].Visible = false;

                if (dgvCitas.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron citas para la fecha seleccionada.",
                                    "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar citas: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count > 0)
            {
                var fila = dgvCitas.SelectedRows[0];

                // ¡CAMBIO CLAVE AQUÍ! Leemos IdCita
                int idCita = Convert.ToInt32(fila.Cells["IdCita"].Value);
                int idEstado = Convert.ToInt32(fila.Cells["IdEstado"].Value);

                // Suponiendo que el estado 1 es "Reservada / Pendiente"
                if (idEstado == 4)
                {
                    bool exito = nCitas.AtenderCita(idCita, idUsuarioSesion);

                    if (exito)
                    {
                        MessageBox.Show("La cita ha sido marcada como Atendida.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnBuscar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado de la cita.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Esta cita ya fue atendida.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cita de la lista.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
