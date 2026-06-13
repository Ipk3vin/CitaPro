using Datos;
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
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string dni = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            using (var contexto = new DBcitaproEntities())
            {
                var usuario = contexto.Usuario
                      .FirstOrDefault(u => u.Dni == dni && u.Contraseña == contrasena);

                if (usuario == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                    return;
                }



                frmMenuAdministrador menu = new frmMenuAdministrador(usuario.Idusuario);
                menu.Show();
                this.Hide();
            }
        }
    }
}