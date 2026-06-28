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
    public partial class frmAuditoria : Form
    {
        NAuditoria objAuditoria = new NAuditoria();
        private int idUsuarioSesion;
        public frmAuditoria(int idUsuario)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            CargarAuditoria();
            idUsuarioSesion = idUsuario;
        }

        private void CargarAuditoria()
        {
            dgvAuditoria.DataSource = null;
            dgvAuditoria.DataSource = objAuditoria.ListarAuditoria();

            FormatoDgvAuditoria();
        }

        private void FormatoDgvAuditoria()
        {
            if (dgvAuditoria.Columns["IdAuditoria"] != null)
                dgvAuditoria.Columns["IdAuditoria"].HeaderText = "ID";

            if (dgvAuditoria.Columns["NombreTabla"] != null)
                dgvAuditoria.Columns["NombreTabla"].HeaderText = "Tabla";

            if (dgvAuditoria.Columns["IdTablaCambio"] != null)
                dgvAuditoria.Columns["IdTablaCambio"].HeaderText = "ID Usuario";

            if (dgvAuditoria.Columns["Accion"] != null)
                dgvAuditoria.Columns["Accion"].HeaderText = "Acción";

            if (dgvAuditoria.Columns["ValorAnterior"] != null)
                dgvAuditoria.Columns["ValorAnterior"].HeaderText = "Valor Anterior";

            if (dgvAuditoria.Columns["ValorNuevo"] != null)
                dgvAuditoria.Columns["ValorNuevo"].HeaderText = "Valor Nuevo";

            if (dgvAuditoria.Columns["Estado"] != null)
                dgvAuditoria.Columns["Estado"].HeaderText = "Estado";

            if (dgvAuditoria.Columns["CreatedBy"] != null)
                dgvAuditoria.Columns["CreatedBy"].HeaderText = "Creado Por";

            if (dgvAuditoria.Columns["CreatedAt"] != null)
                dgvAuditoria.Columns["CreatedAt"].HeaderText = "Fecha Creación";

            if (dgvAuditoria.Columns["ModifiedBy"] != null)
                dgvAuditoria.Columns["ModifiedBy"].HeaderText = "Modificado Por";

            if (dgvAuditoria.Columns["ModifiedAt"] != null)
                dgvAuditoria.Columns["ModifiedAt"].HeaderText = "Fecha Modificación";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenuAdministrador frm = new frmMenuAdministrador(idUsuarioSesion);
            frm.Show();
            this.Hide();
        }
    }
}
