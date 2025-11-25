using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public partial class FormDevolucion : Form
    {
        private readonly Usuario usuarioActual;
        private int prestamoSeleccionadoId = 0;
        private int libroSeleccionadoId = 0;
        private int cantidadPrestadaSeleccionada = 0;

        public FormDevolucion()
        {
            InitializeComponent();
        }

        public FormDevolucion(Usuario usuario) : this()
        {
            usuarioActual = usuario;
        }

        private void FormDevolucion_Load(object sender, EventArgs e)
        {
            dtpFechaDevolucion.Value = DateTime.Now;
            if (usuarioActual != null)
                lblUsuarioActual.Text = "Usuario: " + usuarioActual.Username;

            CargarPrestamosActivos();
        }

        private void CargarPrestamosActivos()
        {
            try
            {
                List<PrestamoDetallado> prestamos;

                if (usuarioActual.EsAdmin())
                    prestamos = Prestamo.ObtenerTodosDetallados();
                else
                    prestamos = Prestamo.ObtenerPorUsuarioDetallado(usuarioActual.IdUsuario);

                var listaMostrada = new List<object>();

                foreach (var p in prestamos)
                {
                    int devuelto = Devolucion.ObtenerCantidadDevuelta(p.IdPrestamo);
                    int pendiente = p.Cantidad - devuelto;

                    if (pendiente > 0)
                    {
                        listaMostrada.Add(new
                        {
                            p.IdPrestamo,
                            p.IdLibro,
                            p.NombreLibro,
                            CantidadPrestada = p.Cantidad,
                            CantidadDevuelta = devuelto,
                            CantidadPendiente = pendiente,
                            p.Fecha
                        });
                    }
                }

                dgvPrestamosActivos.DataSource = listaMostrada;

                if (dgvPrestamosActivos.Columns.Contains("IdLibro"))
                    dgvPrestamosActivos.Columns["IdLibro"].Visible = false;

                if (dgvPrestamosActivos.Columns.Contains("IdPrestamo"))
                    dgvPrestamosActivos.Columns["IdPrestamo"].HeaderText = "Id Prestamo";

                lblEstado.Text = "Préstamos activos: " + listaMostrada.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarPrestamosActivos();
            LimpiarCampos();
            lblEstado.Text = "Lista de préstamos actualizada.";
        }

        private void dgvPrestamosActivos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrestamosActivos.SelectedRows.Count == 0)
                return;

            var row = dgvPrestamosActivos.SelectedRows[0];

            object valorIdPrestamo = row.Cells["IdPrestamo"].Value;
            object valorIdLibro = row.Cells["IdLibro"].Value;
            object valorCantidadPendiente = row.Cells["CantidadPendiente"].Value;

            if (valorIdPrestamo == null || valorIdLibro == null || valorCantidadPendiente == null)
                return;

            prestamoSeleccionadoId = Convert.ToInt32(valorIdPrestamo);
            libroSeleccionadoId = Convert.ToInt32(valorIdLibro);
            cantidadPrestadaSeleccionada = Convert.ToInt32(row.Cells["CantidadPrestada"].Value);

            txtPrestamoId.Text = prestamoSeleccionadoId.ToString();
            txtLibroDevolucion.Text = row.Cells["NombreLibro"].Value?.ToString();

            int pendiente;
            if (!int.TryParse(row.Cells["CantidadPendiente"].Value?.ToString(), out pendiente))
            {
                pendiente = Devolucion.ObtenerPendiente(prestamoSeleccionadoId, cantidadPrestadaSeleccionada);
            }

            txtCantidadPrestada.Text = pendiente.ToString();
            numCantidadDevolver.Maximum = Math.Max(1, pendiente);
            numCantidadDevolver.Value = pendiente > 0 ? pendiente : 1;

            lblEstado.Text = $"Pendiente por devolver: {pendiente}";
        }

        private void btnRealizarDevolucion_Click(object sender, EventArgs e)
        {
            if (prestamoSeleccionadoId == 0)
            {
                MessageBox.Show("Seleccione un préstamo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pendiente = Devolucion.ObtenerPendiente(prestamoSeleccionadoId, cantidadPrestadaSeleccionada);
            int cantidadADevolver = (int)numCantidadDevolver.Value;

            if (cantidadADevolver <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidadADevolver > pendiente)
            {
                MessageBox.Show("La cantidad a devolver excede la cantidad pendiente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"¿Confirmar devolución de {cantidadADevolver} unidad(es) del libro '{txtLibroDevolucion.Text}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            var devolucion = new Devolucion
            {
                IdPrestamo = prestamoSeleccionadoId,
                IdUsuario = usuarioActual.IdUsuario,
                IdLibro = libroSeleccionadoId,
                Cantidad = cantidadADevolver,
                Fecha = dtpFechaDevolucion.Value
            };

            if (!devolucion.EsDevolucionValida(pendiente))
            {
                MessageBox.Show("La devolución no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                devolucion.RealizarDevolucion();

          
                var logDevolucion = LogProceso.CrearDevolucion(
                    usuarioActual.IdUsuario,
                    usuarioActual.Username,
                    devolucion.IdLibro,
                    txtLibroDevolucion.Text,
                    devolucion.IdPrestamo,
                    devolucion.IdPrestamo, 
                    cantidadADevolver
                );
                new LogProcesoService().RegistrarLog(logDevolucion);
               

                MessageBox.Show("Devolución registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int prevPrestamoId = prestamoSeleccionadoId;
                CargarPrestamosActivos();

                foreach (DataGridViewRow r in dgvPrestamosActivos.Rows)
                {
                    if (r.Cells["IdPrestamo"].Value != null && Convert.ToInt32(r.Cells["IdPrestamo"].Value) == prevPrestamoId)
                    {
                        r.Selected = true;
                        dgvPrestamosActivos.CurrentCell = r.Cells[0];
                        break;
                    }
                }

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la devolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtPrestamoId.Clear();
            txtLibroDevolucion.Clear();
            txtCantidadPrestada.Clear();
            numCantidadDevolver.Value = 1;
            dtpFechaDevolucion.Value = DateTime.Now;
            lblEstado.Text = "Seleccione un préstamo.";
            prestamoSeleccionadoId = 0;
            libroSeleccionadoId = 0;
            cantidadPrestadaSeleccionada = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
