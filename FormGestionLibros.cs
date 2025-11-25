using System;
using System.Windows.Forms;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public partial class FormGestionLibros : Form
    {
        private bool modoEdicion = false;

       
        private readonly LogProcesoService logService = new LogProcesoService();
        private Usuario usuarioActual; 

        public FormGestionLibros(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void FormGestionLibros_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            dtpFechaPublicacion.Value = DateTime.Now;
            CargarLibros();
            ConfigurarBotones(false);
        }

        private void CargarLibros()
        {
            try
            {
                var libros = Libro.ObtenerTodos();
                dgvLibros.DataSource = libros;

                dgvLibros.Columns["Portada"].Visible = false;

                lblEstadoOperacion.Text = "Libros cargados: " + libros.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar libros: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count > 0 && !modoEdicion)
            {
                var row = dgvLibros.SelectedRows[0];

                txtIdLibro.Text = row.Cells["IdLibro"].Value?.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                txtGenero.Text = row.Cells["Genero"].Value?.ToString();
                cmbEstado.SelectedItem = row.Cells["Estado"].Value?.ToString();
                numCantidad.Value = Convert.ToDecimal(row.Cells["Cantidad"].Value ?? 0);

                try
                {
                    if (row.Cells["FechaPublicacion"].Value != null)
                    {
                        DateTime fecha = Convert.ToDateTime(row.Cells["FechaPublicacion"].Value);
                        if (fecha >= dtpFechaPublicacion.MinDate && fecha <= dtpFechaPublicacion.MaxDate)
                        {
                            dtpFechaPublicacion.Value = fecha;
                        }
                        else
                        {
                            dtpFechaPublicacion.Value = DateTime.Now;
                        }
                    }
                    else
                    {
                        dtpFechaPublicacion.Value = DateTime.Now;
                    }
                }
                catch
                {
                    dtpFechaPublicacion.Value = DateTime.Now;
                }

                txtSinopsis.Text = row.Cells["Sinopsis"].Value?.ToString();

                ConfigurarBotones(false);
                lblEstadoOperacion.Text = "Libro seleccionado. Puede modificar o eliminar.";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            modoEdicion = true;
            ConfigurarBotones(true);
            txtNombre.Focus();
            lblEstadoOperacion.Text = "Ingrese los datos del nuevo libro.";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                Libro nuevoLibro = new Libro
                {
                    Nombre = txtNombre.Text.Trim(),
                    Genero = txtGenero.Text.Trim(),
                    Estado = cmbEstado.SelectedItem.ToString(),
                    Cantidad = (int)numCantidad.Value,
                    FechaPublicacion = dtpFechaPublicacion.Value,
                    Sinopsis = txtSinopsis.Text.Trim()
                };

                nuevoLibro.Guardar();

             
                var logAgregar = LogProceso.CrearLibro(
                    usuarioActual.IdUsuario,
                    usuarioActual.Username,
                    nuevoLibro.IdLibro,
                    nuevoLibro.Nombre
                );
                logService.RegistrarLog(logAgregar);
               

                MessageBox.Show("Libro agregado exitosamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarLibros();
                LimpiarCampos();
                modoEdicion = false;
                ConfigurarBotones(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar libro: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdLibro.Text))
            {
                MessageBox.Show("Seleccione un libro de la lista para modificar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos())
                return;

            DialogResult result = MessageBox.Show(
                "¿Está seguro de modificar este libro?",
                "Confirmar Modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Libro libroModificado = new Libro
                    {
                        IdLibro = int.Parse(txtIdLibro.Text),
                        Nombre = txtNombre.Text.Trim(),
                        Genero = txtGenero.Text.Trim(),
                        Estado = cmbEstado.SelectedItem.ToString(),
                        Cantidad = (int)numCantidad.Value,
                        FechaPublicacion = dtpFechaPublicacion.Value,
                        Sinopsis = txtSinopsis.Text.Trim()
                    };

                    libroModificado.Guardar();

                 
                    var logModificar = LogProceso.ModificarLibro(
                        usuarioActual.IdUsuario,
                        usuarioActual.Username,
                        libroModificado.IdLibro,
                        libroModificado.Nombre
                    );
                    logService.RegistrarLog(logModificar);
                

                    MessageBox.Show("Libro modificado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarLibros();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar libro: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdLibro.Text))
            {
                MessageBox.Show("Seleccione un libro de la lista para eliminar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar el libro '" + txtNombre.Text + "'?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Libro libro = new Libro { IdLibro = int.Parse(txtIdLibro.Text) };
                    libro.Eliminar();

                   
                    var logEliminar = LogProceso.EliminarLibro(
                        usuarioActual.IdUsuario,
                        usuarioActual.Username,
                        libro.IdLibro,
                        txtNombre.Text
                    );
                    logService.RegistrarLog(logEliminar);
                    

                    MessageBox.Show("Libro eliminado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarLibros();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar libro: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarLibros();
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del libro es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGenero.Text))
            {
                MessageBox.Show("El género del libro es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGenero.Focus();
                return false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado para el libro.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEstado.Focus();
                return false;
            }

            if (numCantidad.Value < 0)
            {
                MessageBox.Show("La cantidad no puede ser negativa.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numCantidad.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtIdLibro.Clear();
            txtNombre.Clear();
            txtGenero.Clear();
            cmbEstado.SelectedIndex = 0;
            numCantidad.Value = 0;
            dtpFechaPublicacion.Value = DateTime.Now;
            txtSinopsis.Clear();
            lblEstadoOperacion.Text = "Seleccione un libro de la lista";
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

                txtNombre.ReadOnly = false;
                txtGenero.ReadOnly = false;
                cmbEstado.Enabled = true;
                numCantidad.ReadOnly = false;
                dtpFechaPublicacion.Enabled = true;
                txtSinopsis.ReadOnly = false;
            }
            else
            {
                btnNuevo.Enabled = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = !string.IsNullOrEmpty(txtIdLibro.Text);
                btnEliminar.Enabled = !string.IsNullOrEmpty(txtIdLibro.Text);
                btnActualizar.Enabled = true;

                bool haySeleccion = !string.IsNullOrEmpty(txtIdLibro.Text);
                txtNombre.ReadOnly = !haySeleccion;
                txtGenero.ReadOnly = !haySeleccion;
                cmbEstado.Enabled = haySeleccion;
                numCantidad.ReadOnly = !haySeleccion;
                dtpFechaPublicacion.Enabled = haySeleccion;
                txtSinopsis.ReadOnly = !haySeleccion;
            }
        }
    }
}
