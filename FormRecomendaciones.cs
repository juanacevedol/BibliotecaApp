using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public partial class FormRecomendaciones : Form
    {
        private readonly Usuario usuarioActual;
        private readonly RecomendacionService _recomendacionService = new RecomendacionService();
        private int libroSeleccionadoId = 0;

        public FormRecomendaciones()
        {
            InitializeComponent();
        }

        public FormRecomendaciones(Usuario usuario) : this()
        {
            usuarioActual = usuario;
        }

        private void FormRecomendaciones_Load(object sender, EventArgs e)
        {
            if (usuarioActual != null)
            {
                lblUsuarioActual.Text = $"Usuario: {usuarioActual.Username}";
            }

            ConfigurarDataGridView();
            CargarRecomendaciones();
        }

        private void ConfigurarDataGridView()
        {
            dgvRecomendaciones.EnableHeadersVisualStyles = false;
            dgvRecomendaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 85, 72);
            dgvRecomendaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRecomendaciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRecomendaciones.ColumnHeadersHeight = 40;
            dgvRecomendaciones.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvRecomendaciones.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 214, 229);
            dgvRecomendaciones.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvRecomendaciones.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvRecomendaciones.RowTemplate.Height = 35;
            dgvRecomendaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarRecomendaciones()
        {
            try
            {
  
                var recomendaciones = _recomendacionService.ObtenerRecomendacionesPorUsuario(usuarioActual.IdUsuario);

  
                if (recomendaciones.Count == 0)
                {
                    recomendaciones = _recomendacionService.GenerarRecomendaciones(usuarioActual.IdUsuario, 10);


                    foreach (var rec in recomendaciones)
                    {
                        var nuevaRec = new Recomendacion
                        {
                            IdUsuario = rec.IdUsuario,
                            IdLibro = rec.IdLibro,
                            Fecha = rec.Fecha
                        };
                        nuevaRec.Guardar();
                    }
                }

                dgvRecomendaciones.DataSource = recomendaciones;
                ConfigurarColumnas();
                ActualizarContador(recomendaciones.Count);

                if (recomendaciones.Count == 0)
                {
                    MessageBox.Show(
                        "No hay recomendaciones disponibles en este momento.\n" +
                        "Intenta prestar algunos libros primero para obtener recomendaciones personalizadas.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar recomendaciones: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
        private void ConfigurarColumnas()
        {
            if (dgvRecomendaciones.Columns.Count == 0) return;

            try
            {

                if (dgvRecomendaciones.Columns.Contains("IdRecomendacion"))
                    dgvRecomendaciones.Columns["IdRecomendacion"].Visible = false;

                if (dgvRecomendaciones.Columns.Contains("IdUsuario"))
                    dgvRecomendaciones.Columns["IdUsuario"].Visible = false;

                if (dgvRecomendaciones.Columns.Contains("IdLibro"))
                    dgvRecomendaciones.Columns["IdLibro"].Visible = false;

                if (dgvRecomendaciones.Columns.Contains("Estado"))
                    dgvRecomendaciones.Columns["Estado"].Visible = false;

  
                if (dgvRecomendaciones.Columns.Contains("NombreLibro"))
                {
                    dgvRecomendaciones.Columns["NombreLibro"].HeaderText = "📖 Libro Recomendado";
                    dgvRecomendaciones.Columns["NombreLibro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvRecomendaciones.Columns.Contains("Genero"))
                {
                    dgvRecomendaciones.Columns["Genero"].HeaderText = "🎭 Género";
                    dgvRecomendaciones.Columns["Genero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvRecomendaciones.Columns["Genero"].Width = 130;
                }

                if (dgvRecomendaciones.Columns.Contains("Disponibilidad"))
                {
                    dgvRecomendaciones.Columns["Disponibilidad"].HeaderText = "✓ Disponibilidad";
                    dgvRecomendaciones.Columns["Disponibilidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvRecomendaciones.Columns["Disponibilidad"].Width = 130;
                }

                if (dgvRecomendaciones.Columns.Contains("RazonRecomendacion"))
                {
                    dgvRecomendaciones.Columns["RazonRecomendacion"].HeaderText = "💡 Por qué te lo recomendamos";
                    dgvRecomendaciones.Columns["RazonRecomendacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvRecomendaciones.Columns.Contains("Fecha"))
                {
                    dgvRecomendaciones.Columns["Fecha"].HeaderText = "📅 Fecha";
                    dgvRecomendaciones.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvRecomendaciones.Columns["Fecha"].Width = 100;
                    dgvRecomendaciones.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvRecomendaciones.Columns.Contains("CantidadDisponible"))
                    dgvRecomendaciones.Columns["CantidadDisponible"].Visible = false;


                foreach (DataGridViewRow row in dgvRecomendaciones.Rows)
                {
                    if (row.Cells["CantidadDisponible"].Value != null)
                    {
                        int cantidad = Convert.ToInt32(row.Cells["CantidadDisponible"].Value);

                        if (cantidad > 0)
                        {
                            if (dgvRecomendaciones.Columns.Contains("Disponibilidad"))
                            {
                                row.Cells["Disponibilidad"].Style.BackColor = Color.LightGreen;
                                row.Cells["Disponibilidad"].Style.ForeColor = Color.DarkGreen;
                                row.Cells["Disponibilidad"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            }
                        }
                        else
                        {
                            if (dgvRecomendaciones.Columns.Contains("Disponibilidad"))
                            {
                                row.Cells["Disponibilidad"].Style.BackColor = Color.LightCoral;
                                row.Cells["Disponibilidad"].Style.ForeColor = Color.DarkRed;
                                row.Cells["Disponibilidad"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al configurar columnas: " + ex.Message);
            }
        }

  
        private void ActualizarContador(int total)
        {
            lblInfo.Text = $"Total recomendaciones: {total}";
        }

        private void dgvRecomendaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecomendaciones.SelectedRows.Count > 0)
            {
                var row = dgvRecomendaciones.SelectedRows[0];

                if (row.Cells["IdLibro"].Value != null)
                {
                    libroSeleccionadoId = Convert.ToInt32(row.Cells["IdLibro"].Value);

                }
            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarRecomendaciones();
            MessageBox.Show("Recomendaciones actualizadas.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}