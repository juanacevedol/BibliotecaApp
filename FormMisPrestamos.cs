using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaApp.Models;

namespace BibliotecaApp
{
    public partial class FormMisPrestamos : Form
    {
        private readonly Usuario usuarioActual;

        public FormMisPrestamos()
        {
            InitializeComponent();
        }

        public FormMisPrestamos(Usuario usuario) : this()
        {
            usuarioActual = usuario;
        }

        private void FormMisPrestamos_Load(object sender, EventArgs e)
        {
            if (usuarioActual != null)
            {
                lblUsuarioActual.Text = $"Usuario: {usuarioActual.Username}";
            }

            dtpFechaDesde.Value = DateTime.Now.AddMonths(-1);
            dtpFechaHasta.Value = DateTime.Now;

            CargarPrestamosActivos();
            CargarHistorial();
        }

        private void CargarPrestamosActivos()
        {
            try
            {
       
                List<PrestamoDetallado> prestamos = Prestamo.ObtenerPorUsuarioDetallado(usuarioActual.IdUsuario);

               
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
                            FechaPrestamo = p.Fecha
                        });
                    }
                }

                dgvPrestamosActivos.DataSource = listaMostrada;

                ConfigurarColumnasPrestamosActivos();

                int totalActivos = listaMostrada.Count;
                lblInfoActivos.Text = $"Préstamos activos actuales: {totalActivos}";

   
                btnDevolver.Enabled = totalActivos > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar préstamos activos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorial()
        {
            try
            {
                DateTime fechaDesde = dtpFechaDesde.Value.Date;
                DateTime fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1);


                List<PrestamoDetallado> prestamos = Prestamo.ObtenerPorUsuarioDetallado(usuarioActual.IdUsuario);

        
                var prestamosFiltrados = prestamos.Where(p =>
                    p.Fecha >= fechaDesde && p.Fecha <= fechaHasta
                ).ToList();

             
                var historial = new List<object>();

                foreach (var p in prestamosFiltrados)
                {
                    int devuelto = Devolucion.ObtenerCantidadDevuelta(p.IdPrestamo);
                    int pendiente = p.Cantidad - devuelto;
                    string estado = pendiente > 0 ? "Activo" : "Completado";

                    historial.Add(new
                    {
                        p.IdPrestamo,
                        p.NombreLibro,
                        CantidadPrestada = p.Cantidad,
                        CantidadDevuelta = devuelto,
                        CantidadPendiente = pendiente,
                        FechaPrestamo = p.Fecha,
                        Estado = estado
                    });
                }

                dgvHistorial.DataSource = historial;

                ConfigurarColumnasHistorial();

                int totalHistorial = historial.Count;
                lblInfoHistorial.Text = $"Total de registros: {totalHistorial}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasPrestamosActivos()
        {
            if (dgvPrestamosActivos.Columns.Count == 0) return;

            try
            {
      
                if (dgvPrestamosActivos.Columns.Contains("IdLibro"))
                    dgvPrestamosActivos.Columns["IdLibro"].Visible = false;

          
                if (dgvPrestamosActivos.Columns.Contains("IdPrestamo"))
                    dgvPrestamosActivos.Columns["IdPrestamo"].HeaderText = "ID Préstamo";

                if (dgvPrestamosActivos.Columns.Contains("NombreLibro"))
                    dgvPrestamosActivos.Columns["NombreLibro"].HeaderText = "Libro";

                if (dgvPrestamosActivos.Columns.Contains("CantidadPrestada"))
                    dgvPrestamosActivos.Columns["CantidadPrestada"].HeaderText = "Prestada";

                if (dgvPrestamosActivos.Columns.Contains("CantidadDevuelta"))
                    dgvPrestamosActivos.Columns["CantidadDevuelta"].HeaderText = "Devuelta";

                if (dgvPrestamosActivos.Columns.Contains("CantidadPendiente"))
                    dgvPrestamosActivos.Columns["CantidadPendiente"].HeaderText = "Pendiente";

                if (dgvPrestamosActivos.Columns.Contains("FechaPrestamo"))
                {
                    dgvPrestamosActivos.Columns["FechaPrestamo"].HeaderText = "Fecha Préstamo";
                    dgvPrestamosActivos.Columns["FechaPrestamo"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                foreach (DataGridViewRow row in dgvPrestamosActivos.Rows)
                {
                    if (row.Cells["FechaPrestamo"].Value != null)
                    {
                        DateTime fechaPrestamo = Convert.ToDateTime(row.Cells["FechaPrestamo"].Value);
                        TimeSpan diasTranscurridos = DateTime.Now - fechaPrestamo;

                        if (diasTranscurridos.TotalDays > 30)
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                            row.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed;
                        }
                        else if (diasTranscurridos.TotalDays > 15)
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al configurar columnas: " + ex.Message);
            }
        }

        private void ConfigurarColumnasHistorial()
        {
            if (dgvHistorial.Columns.Count == 0) return;

            try
            {

                if (dgvHistorial.Columns.Contains("IdPrestamo"))
                    dgvHistorial.Columns["IdPrestamo"].HeaderText = "ID Préstamo";

                if (dgvHistorial.Columns.Contains("NombreLibro"))
                    dgvHistorial.Columns["NombreLibro"].HeaderText = "Libro";

                if (dgvHistorial.Columns.Contains("CantidadPrestada"))
                    dgvHistorial.Columns["CantidadPrestada"].HeaderText = "Prestada";

                if (dgvHistorial.Columns.Contains("CantidadDevuelta"))
                    dgvHistorial.Columns["CantidadDevuelta"].HeaderText = "Devuelta";

                if (dgvHistorial.Columns.Contains("CantidadPendiente"))
                    dgvHistorial.Columns["CantidadPendiente"].HeaderText = "Pendiente";

                if (dgvHistorial.Columns.Contains("FechaPrestamo"))
                {
                    dgvHistorial.Columns["FechaPrestamo"].HeaderText = "Fecha Préstamo";
                    dgvHistorial.Columns["FechaPrestamo"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvHistorial.Columns.Contains("Estado"))
                    dgvHistorial.Columns["Estado"].HeaderText = "Estado";


                foreach (DataGridViewRow row in dgvHistorial.Rows)
                {
                    if (row.Cells["Estado"].Value != null)
                    {
                        string estado = row.Cells["Estado"].Value.ToString();

                        if (estado == "Completado")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else if (estado == "Activo")
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al configurar columnas historial: " + ex.Message);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvPrestamosActivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un préstamo de la lista.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

   
            FormDevolucion formDevolucion = new FormDevolucion(usuarioActual);

            if (formDevolucion.ShowDialog() == DialogResult.OK)
            {
  
                CargarPrestamosActivos();
                CargarHistorial();

                MessageBox.Show("¡Devolución registrada exitosamente!",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFiltrarHistorial_Click(object sender, EventArgs e)
        {

            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarHistorial();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarPrestamosActivos();
            CargarHistorial();

            MessageBox.Show("Datos actualizados correctamente.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}