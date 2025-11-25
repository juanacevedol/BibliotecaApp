using System;
using System.Windows.Forms;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public partial class FormGestionUsuarios : Form
    {
        private bool modoEdicion = false;
        private string adminActual = "AdminActual"; 

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add("administrador");
            cmbRol.Items.Add("lector");
            cmbRol.SelectedIndex = 0;

            CargarUsuarios();
            ConfigurarBotones(false);
        }

        private void CargarUsuarios()
        {
            try
            {
                var usuarios = Usuario.ObtenerTodos();
                dgvUsuarios.DataSource = usuarios;

                if (dgvUsuarios.Columns.Contains("Password"))
                {
                    dgvUsuarios.Columns["Password"].Visible = false;
                }

                lblEstadoOperacion.Text = "Usuarios cargados: " + usuarios.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0 && !modoEdicion)
            {
                var row = dgvUsuarios.SelectedRows[0];

                txtIdUsuario.Text = row.Cells["IdUsuario"].Value?.ToString();
                txtUsername.Text = row.Cells["Username"].Value?.ToString();
                txtPassword.Text = "";

                string rolBD = row.Cells["Rol"].Value?.ToString();
                if (!string.IsNullOrEmpty(rolBD))
                {
                    int index = cmbRol.FindStringExact(rolBD);
                    if (index >= 0)
                        cmbRol.SelectedIndex = index;
                }

                ConfigurarBotones(false);
                lblEstadoOperacion.Text = "Usuario seleccionado. Puede modificar o eliminar.";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            modoEdicion = true;
            ConfigurarBotones(true);
            txtUsername.Focus();
            lblEstadoOperacion.Text = "Ingrese los datos del nuevo usuario.";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                if (Usuario.ExisteUsername(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                Usuario nuevoUsuario = new Usuario
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    Rol = cmbRol.SelectedItem.ToString()
                };

                nuevoUsuario.Guardar();

                
                var logService = new LogProcesoService();
                var log = LogProceso.CrearUsuario(nuevoUsuario.IdUsuario, adminActual, nuevoUsuario.Username);
                logService.RegistrarLog(log);

                MessageBox.Show("Usuario agregado exitosamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUsuarios();
                LimpiarCampos();
                modoEdicion = false;
                ConfigurarBotones(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario de la lista para modificar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCamposModificar())
                return;

            int idUsuarioActual = int.Parse(txtIdUsuario.Text);

            DialogResult result = MessageBox.Show(
                "¿Está seguro de modificar este usuario?",
                "Confirmar Modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string passwordFinal;
                    if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        Usuario usuarioActual = Usuario.BuscarPorId(idUsuarioActual);
                        passwordFinal = usuarioActual.Password;
                    }
                    else
                    {
                        passwordFinal = txtPassword.Text;
                    }

                    Usuario usuarioModificado = new Usuario
                    {
                        IdUsuario = idUsuarioActual,
                        Username = txtUsername.Text.Trim(),
                        Password = passwordFinal,
                        Rol = cmbRol.SelectedItem.ToString()
                    };

                    usuarioModificado.Guardar();

                   
                    var logService = new LogProcesoService();
                    var log = LogProceso.ModificarUsuario(usuarioModificado.IdUsuario, adminActual, usuarioModificado.Username);
                    logService.RegistrarLog(log);

                    MessageBox.Show("Usuario modificado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarUsuarios();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar usuario: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario de la lista para eliminar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = int.Parse(txtIdUsuario.Text);
            Usuario usuarioAEliminar = Usuario.BuscarPorId(idUsuario);

            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar al usuario '" + txtUsername.Text + "'?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Usuario usuario = new Usuario { IdUsuario = idUsuario };
                    usuario.Eliminar();

                   
                    var logService = new LogProcesoService();
                    var log = LogProceso.EliminarUsuario(usuarioAEliminar.IdUsuario, adminActual, usuarioAEliminar.Username);
                    logService.RegistrarLog(log);

                    MessageBox.Show("Usuario eliminado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarUsuarios();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar usuario: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            LimpiarCampos();
            modoEdicion = false;
            ConfigurarBotones(false);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (txtPassword.Text.Length < 3)
            {
                MessageBox.Show("La contraseña debe tener al menos 3 caracteres.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol para el usuario.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        private bool ValidarCamposModificar()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (txtUsername.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 3 caracteres.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text.Length < 3)
            {
                MessageBox.Show("La contraseña debe tener al menos 3 caracteres.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol para el usuario.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRol.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtIdUsuario.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = 0;
            lblEstadoOperacion.Text = "Seleccione un usuario de la lista";
        }

        private void ConfigurarBotones(bool modoNuevo)
        {
            if (modoNuevo)
            {
                btnNuevo.Enabled = false;
                btnAgregar.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                btnActualizar.Enabled = true;

                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;
                cmbRol.Enabled = true;
            }
            else
            {
                btnNuevo.Enabled = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = !string.IsNullOrEmpty(txtIdUsuario.Text);
                btnEliminar.Enabled = !string.IsNullOrEmpty(txtIdUsuario.Text);
                btnActualizar.Enabled = true;

                bool haySeleccion = !string.IsNullOrEmpty(txtIdUsuario.Text);
                txtUsername.ReadOnly = !haySeleccion;
                txtPassword.ReadOnly = !haySeleccion;
                cmbRol.Enabled = haySeleccion;
            }
        }
    }
}
