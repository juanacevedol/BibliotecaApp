using System;
using System.Windows.Forms;
using BibliotecaApp.Models;

namespace BibliotecaApp
{
    public partial class FormMenuPrincipal : Form
    {
        private readonly Usuario usuarioActual;

        public FormMenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            ConfigurarMenuSegunRol();
        }

        private void ConfigurarMenuSegunRol()
        {
   
            lblBienvenida.Text = $"Bienvenido, {usuarioActual.Username}";
            lblRol.Text = $"Rol: {usuarioActual.Rol}";

            if (usuarioActual.Rol.ToLower() == "admin" || usuarioActual.Rol.ToLower() == "administrador")
            {
          
                btnGestionLibros.Visible = true;
                btnGestionUsuarios.Visible = true;
                btnVerLogs.Visible = true;
            }
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            FormPrestamo formPrestamo = new FormPrestamo(usuarioActual);
            formPrestamo.ShowDialog();
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            FormDevolucion formDevolucion = new FormDevolucion(usuarioActual);
            formDevolucion.ShowDialog();
        }

        private void btnGestionLibros_Click(object sender, EventArgs e)
        {
            if (usuarioActual.Rol.ToLower() == "admin" || usuarioActual.Rol.ToLower() == "administrador")
            {
             
                FormGestionLibros formGestionLibros = new FormGestionLibros(usuarioActual);
                formGestionLibros.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a esta función.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            if (usuarioActual.Rol.ToLower() == "admin" || usuarioActual.Rol.ToLower() == "administrador")
            {
                FormGestionUsuarios formGestionUsuarios = new FormGestionUsuarios();
                formGestionUsuarios.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a esta función.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerLogs_Click(object sender, EventArgs e)
        {
            if (usuarioActual.Rol.ToLower() == "admin" || usuarioActual.Rol.ToLower() == "administrador")
            {
                FormVisualizarLogs formLogs = new FormVisualizarLogs();
                formLogs.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tiene permisos para acceder a esta función.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
  
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
        }

        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
