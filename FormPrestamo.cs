using System;
using System.Windows.Forms;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public partial class FormPrestamo : Form
    {
        private readonly Usuario usuarioActual;
        private readonly LogProcesoService _logService = new LogProcesoService();
        private int libroSeleccionadoId = 0;

        public FormPrestamo()
        {
            InitializeComponent();
        }

        public FormPrestamo(Usuario usuario) : this()
        {
            usuarioActual = usuario;
        }

        private void FormPrestamo_Load(object sender, EventArgs e)
        {
            dtpFechaPrestamo.Value = DateTime.Now;

            if (usuarioActual != null)
            {
                lblUsuarioActual.Text = "Usuario: " + usuarioActual.Username;
            }

            CargarLibrosDisponibles();
        }

        private void CargarLibrosDisponibles()
        {
            try
            {
                var libros = Libro.ObtenerDisponibles();
                dgvLibrosDisponibles.DataSource = libros;

                if (dgvLibrosDisponibles.Columns.Contains("Portada"))
                {
                    dgvLibrosDisponibles.Columns["Portada"].Visible = false;
                }

                if (dgvLibrosDisponibles.Columns.Contains("Sinopsis"))
                {
                    dgvLibrosDisponibles.Columns["Sinopsis"].Visible = false;
                }

                lblEstado.Text = "Libros disponibles: " + libros.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar libros: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = txtBuscarLibro.Text.Trim();

            if (string.IsNullOrEmpty(terminoBusqueda))
            {
                CargarLibrosDisponibles();
            }
            else
            {
                try
                {
                    var libros = Libro.BuscarPorNombre(terminoBusqueda);
                    dgvLibrosDisponibles.DataSource = libros;

                    if (dgvLibrosDisponibles.Columns.Contains("Portada"))
                    {
                        dgvLibrosDisponibles.Columns["Portada"].Visible = false;
                    }

                    if (dgvLibrosDisponibles.Columns.Contains("Sinopsis"))
                    {
                        dgvLibrosDisponibles.Columns["Sinopsis"].Visible = false;
                    }

                    lblEstado.Text = "Resultados encontrados: " + libros.Count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar libros: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLibrosDisponibles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLibrosDisponibles.SelectedRows.Count > 0)
            {
                var row = dgvLibrosDisponibles.SelectedRows[0];

                libroSeleccionadoId = Convert.ToInt32(row.Cells["IdLibro"].Value);
                txtLibroSeleccionado.Text = row.Cells["Nombre"].Value?.ToString();
                txtCantidadDisponible.Text = row.Cells["Cantidad"].Value?.ToString();

                int cantidadDisponible = Convert.ToInt32(row.Cells["Cantidad"].Value);
                numCantidad.Maximum = cantidadDisponible > 0 ? cantidadDisponible : 0;
                numCantidad.Value = cantidadDisponible > 0 ? 1 : 0;

                lblEstado.Text = "Libro seleccionado. Ingrese la cantidad a prestar.";
            }
        }

        private void btnRealizarPrestamo_Click(object sender, EventArgs e)
        {
            if (dgvLibrosDisponibles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un libro de la lista.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidadDisponible = Convert.ToInt32(txtCantidadDisponible.Text);
            if (numCantidad.Value > cantidadDisponible)
            {
                MessageBox.Show("La cantidad solicitada excede la disponible.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Confirma el préstamo de " + numCantidad.Value + " unidad(es) del libro '" + txtLibroSeleccionado.Text + "'?",
                "Confirmar Préstamo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    Prestamo nuevoPrestamo = new Prestamo
                    {
                        IdUsuario = usuarioActual.IdUsuario,
                        IdLibro = libroSeleccionadoId,
                        Cantidad = (int)numCantidad.Value,
                        Fecha = dtpFechaPrestamo.Value
                    };

                    nuevoPrestamo.Guardar();


                    var log = LogProceso.CrearPrestamo(
                        usuarioActual.IdUsuario,
                        usuarioActual.Username,
                        libroSeleccionadoId,
                        txtLibroSeleccionado.Text,
                        nuevoPrestamo.IdPrestamo,
                        (int)numCantidad.Value
                    );
                    _logService.RegistrarLog(log);


                    MessageBox.Show("Préstamo realizado exitosamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al realizar el préstamo: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}