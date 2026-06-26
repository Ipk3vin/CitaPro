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
    public partial class frmMenuEditarConsultor : Form
    {
        private int idUsuarioSesion;

        NConsultor objConsultor = new NConsultor();

        ConsultorVista consultorSeleccionado = null;

        bool cargandoDatos = false;

        // Constructor que recibe el ID del administrador
        public frmMenuEditarConsultor(int idAdmin)
        {
            InitializeComponent();

            idUsuarioSesion = idAdmin;

            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            btnBuscarConsultor.Click += btnBuscarConsultor_Click;
            chkEstadoConsultor.CheckedChanged += chkEstadoConsultor_CheckedChanged;
            btnEliminarConsultor.Click += btnEliminarConsultor_Click;
            btnEditarDatosConsultor.Click += btnEditarDatosConsultor_Click;
            btnVolver.Click += btnVolver_Click;

            DeshabilitarAcciones();
        }
        private void DeshabilitarAcciones()
        {
            cargandoDatos = true;

            consultorSeleccionado = null;

            lblNombreConsultor.Text = "-";

            chkEstadoConsultor.Checked = false;
            chkEstadoConsultor.Enabled = false;

            btnEliminarConsultor.Enabled = false;
            btnEditarDatosConsultor.Enabled = false;

            cargandoDatos = false;
        }
        private void HabilitarAcciones(ConsultorVista consultor)
        {
            cargandoDatos = true;

            consultorSeleccionado = consultor;

            lblNombreConsultor.Text = consultor.Nombre;

            chkEstadoConsultor.Enabled = true;
            btnEliminarConsultor.Enabled = true;
            btnEditarDatosConsultor.Enabled = true;

            if (consultor.Estado == "Activo")
            {
                chkEstadoConsultor.Checked = true;
            }
            else
            {
                chkEstadoConsultor.Checked = false;
            }

            cargandoDatos = false;
        }
        private void btnBuscarConsultor_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (dni == "")
            {
                MessageBox.Show("Ingrese el DNI del consultor.");
                DeshabilitarAcciones();
                return;
            }

            ConsultorVista consultor = objConsultor.BuscarConsultorPorDni(dni);

            if (consultor == null)
            {
                MessageBox.Show("No se encontró ningún consultor con ese DNI.");
                DeshabilitarAcciones();
                return;
            }

            HabilitarAcciones(consultor);
        }

        private void chkEstadoConsultor_CheckedChanged(object sender, EventArgs e)
        {
            if (cargandoDatos == true)
            {
                return;
            }

            if (consultorSeleccionado == null)
            {
                return;
            }

            bool habilitar = chkEstadoConsultor.Checked;

            string mensaje = objConsultor.CambiarEstadoConsultor(
                consultorSeleccionado.IdConsultor,
                habilitar
            );

            MessageBox.Show(mensaje);

            if (habilitar)
            {
                consultorSeleccionado.Estado = "Activo";
            }
            else
            {
                consultorSeleccionado.Estado = "Inactivo";
            }
        }

        private void btnEliminarConsultor_Click(object sender, EventArgs e)
        {
            if (consultorSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un consultor.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea eliminar este consultor?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.Yes)
            {
                string mensaje = objConsultor.EliminarConsultor(
                    consultorSeleccionado.IdConsultor
                );

                MessageBox.Show(mensaje);

                txtDni.Clear();
                DeshabilitarAcciones();
            }
        }

        private void btnEditarDatosConsultor_Click(object sender, EventArgs e)
        {
            if (consultorSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un consultor.");
                return;
            }

            frmMenuEditarDatosConsultor formulario = new frmMenuEditarDatosConsultor(
                consultorSeleccionado.IdConsultor
            ); formulario.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}