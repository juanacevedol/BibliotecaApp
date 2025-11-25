using System;
using System.Windows.Forms;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña.",
                    "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Usuario usuarioAutenticado = Usuario.ValidarCredenciales(username, password);

                if (usuarioAutenticado != null)
                {
                    MessageBox.Show("¡Bienvenido " + usuarioAutenticado.Username + "!",
                        "Acceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                    var logService = new LogProcesoService();
                    var log = LogProceso.CrearLogin(usuarioAutenticado.IdUsuario, usuarioAutenticado.Username);
                    logService.RegistrarLog(log);

                 
                    if (usuarioAutenticado.EsAdmin())
                    {
                        FormMenuPrincipal menuAdmin = new FormMenuPrincipal(usuarioAutenticado);
                        menuAdmin.Show();
                    }
                    else if (usuarioAutenticado.EsLector())
                    {
                        FormPanelUsuarioRegular panelUsuario = new FormPanelUsuarioRegular(usuarioAutenticado);
                        panelUsuario.Show();
                    }
                    else
                    {
                        MessageBox.Show("Rol no reconocido: " + usuarioAutenticado.Rol,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.",
                        "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}