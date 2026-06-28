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
    public partial class frmAgregarHorarios : Form
    {
        private int idConsultor;
        private int idUsuarioSesion;

        NHorarioConsultor objHorario = new NHorarioConsultor();

        public frmAgregarHorarios(int idC, int idU)
        {
            InitializeComponent();

            idConsultor = idC;
            idUsuarioSesion = idU;
        }

        private void btnGenerarHorarios_Click(object sender, EventArgs e)
        {
            if (txtHorasPorCita.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese las horas por cita.");
                return;
            }

            int horasPorCita = Convert.ToInt32(txtHorasPorCita.Text);

            List<int> diasSeleccionados = new List<int>();

            if (chkLunes.Checked == true)
            {
                diasSeleccionados.Add(1);
            }

            if (chkMartes.Checked == true)
            {
                diasSeleccionados.Add(2);
            }

            if (chkMiercoles.Checked == true)
            {
                diasSeleccionados.Add(3);
            }

            if (chkJueves.Checked == true)
            {
                diasSeleccionados.Add(4);
            }

            if (chkViernes.Checked == true)
            {
                diasSeleccionados.Add(5);
            }

            if (chkSabado.Checked == true)
            {
                diasSeleccionados.Add(6);
            }

            string mensaje = objHorario.GenerarHorariosConsultor(
                idConsultor,
                dtpFechaInicio.Value,
                dtpFechaFin.Value,
                horasPorCita,
                diasSeleccionados,
                idUsuarioSesion
            );

            MessageBox.Show(mensaje);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
