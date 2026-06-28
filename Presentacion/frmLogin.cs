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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        NUsuario objUsuario = new NUsuario();

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string dni = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            UsuarioSesion usuario = new UsuarioSesion();

            usuario = objUsuario.Login(dni, contrasena);

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }

            // Administrador
            if (usuario.Idtipo == 1)
            {
                frmMenuAdministrador frm = new frmMenuAdministrador(usuario.Idusuario);
                frm.Show();
                this.Hide();
            }
            // Consultor
            else if (usuario.Idtipo == 2)
            {
                frmMenuConsultor frm = new frmMenuConsultor(usuario.Idusuario);
                frm.Show();
                this.Hide();
            }
            // Cliente
            else if (usuario.Idtipo == 3)
            {
                frmMenuCliente frm = new frmMenuCliente(usuario.Idusuario);

                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tipo de usuario no válido.");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrarCliente frm = new frmRegistrarCliente();
            frm.Show();
            
        }
    }
}