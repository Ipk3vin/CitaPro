using Datos.Clientes;
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
    public partial class frmMisCitas : Form
    {
        private int idUsuarioSesion;
        NCliente ncliente = new NCliente();

        public frmMisCitas(int idcliente)
        {
            InitializeComponent();
            idUsuarioSesion = idcliente;
            CargarGrid();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvMisCitas.CurrentRow != null)
            {
                Citas citaSeleccionada = (Citas)dgvMisCitas.CurrentRow.DataBoundItem;

                ncliente.CancelarCita(citaSeleccionada.IdCita);

                MessageBox.Show("La cita ha sido cancelada exitosamente.");

                CargarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cita de la lista.");
            }
        }
        private void CargarGrid()
        {
            dgvMisCitas.DataSource = ncliente.ObtenerCitas();
        }





    }
}
