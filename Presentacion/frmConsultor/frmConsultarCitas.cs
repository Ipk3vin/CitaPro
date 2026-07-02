using Datos;
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
        private NHorarioConsultor nHorarios = new NHorarioConsultor();
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

                // MEJORA: Pasamos el ID del consultor para que solo vea SUS horarios
                var listaHorarios = nHorarios.BuscarHorariosPorFecha(fecha, idUsuarioSesion);

                dgvCitas.DataSource = listaHorarios;

                // Ocultamos la columna del IdEstado para que el usuario no la vea, 
                // pero la mantenemos en la grilla para validaciones lógicas
                if (dgvCitas.Columns["IdEstado"] != null)
                {
                    dgvCitas.Columns["IdEstado"].Visible = false;
                }

                if (dgvCitas.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron horarios para la fecha seleccionada.",
                                    "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar horarios: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count > 0)
            {
                var fila = dgvCitas.SelectedRows[0];
                int idHorario = Convert.ToInt32(fila.Cells["IdHorario"].Value);
                int idEstado = Convert.ToInt32(fila.Cells["IdEstado"].Value);

                // Suponiendo que el IdEstadoHorario = 4 es "Pendiente"
                if (idEstado == 2)
                {
                    // MEJORA: Pasamos el ID del consultor actual para la auditoría (ModifiedBy)
                    bool exito = nHorarios.AtenderCita(idHorario, idUsuarioSesion);

                    if (exito)
                    {
                        MessageBox.Show("El horario ha sido marcado como Atendido.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescamos la lista automáticamente
                        btnBuscar.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Este horario ya fue atendido o no se encuentra pendiente.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un horario de la lista.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
