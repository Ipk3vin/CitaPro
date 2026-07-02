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
        bool cargandoDatos = false;
        NConsultor objConsultor = new NConsultor();
        ConsultorVista consultorSeleccionado = null;

        // Constructor que recibe el ID del administrador
        public frmMenuEditarConsultor(int idAdmin)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            idUsuarioSesion = idAdmin;
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
            btnAgregarHorarios.Enabled = false;

            cargandoDatos = false;
        }
        private void HabilitarAcciones(ConsultorVista consultor)
        {
            cargandoDatos = true;

            consultorSeleccionado = consultor;

            lblNombreConsultor.Text = consultor.Nombre;

            chkEstadoConsultor.Enabled = true;

            if (consultor.Estado == "Activo")
            {
                chkEstadoConsultor.Checked = true;

                btnEliminarConsultor.Enabled = true;
                btnEditarDatosConsultor.Enabled = true;
                btnAgregarHorarios.Enabled = true;
            }
            else
            {
                chkEstadoConsultor.Checked = false;

                btnEliminarConsultor.Enabled = false;
                btnEditarDatosConsultor.Enabled = false;
                btnAgregarHorarios.Enabled = false;
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
                            habilitar,
                            idUsuarioSesion
                        );

            MessageBox.Show(mensaje);

            if (habilitar == true)
            {
                consultorSeleccionado.Estado = "Activo";

                btnEliminarConsultor.Enabled = true;
                btnEditarDatosConsultor.Enabled = true;
                btnAgregarHorarios.Enabled = true;
            }
            else
            {
                consultorSeleccionado.Estado = "Inactivo";

                btnEliminarConsultor.Enabled = false;
                btnEditarDatosConsultor.Enabled = false;
                btnAgregarHorarios.Enabled = false;
            }

            chkEstadoConsultor.Enabled = true;
        }

        private void btnEliminarConsultor_Click(object sender, EventArgs e)
        {

            frmConfirmarEliminarConsultor frm = new frmConfirmarEliminarConsultor(
                consultorSeleccionado.IdConsultor,
                idUsuarioSesion
            );

            frm.Show();

            this.Close();
        }

        private void btnEditarDatosConsultor_Click(object sender, EventArgs e)
        {
            
            frmMenuEditarDatosConsultor frm = new frmMenuEditarDatosConsultor(
                consultorSeleccionado.IdConsultor, idUsuarioSesion
            );
            
            frm.Show();

            this.Close();

        }

        private void btnAgregarHorarios_Click(object sender, EventArgs e)
        {

            frmAgregarHorarios frm = new frmAgregarHorarios(
                consultorSeleccionado.IdConsultor,
                idUsuarioSesion
            );

            frm.Show();

            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuAdministrador frm = new frmMenuAdministrador(idUsuarioSesion);
            frm.Show();

            this.Close();
        }


    }
}