using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibliotecaApp.Models;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public partial class FormPanelUsuarioRegular : Form
    {
        private readonly Usuario usuarioActual;
        private readonly LogProcesoService _logService = new LogProcesoService();
        private string placeholderText = "🔍 Buscar por nombre...";

        public FormPanelUsuarioRegular()
        {
            InitializeComponent();
        }

        public FormPanelUsuarioRegular(Usuario usuario) : this()
        {
            usuarioActual = usuario;
        }

        private void FormPanelUsuarioRegular_Load(object sender, EventArgs e)
        {

            if (usuarioActual != null)
            {
                lblUsuarioActual.Text = $"Usuario: {usuarioActual.Username}";
            }


            txtBuscar.Text = placeholderText;
            txtBuscar.ForeColor = Color.Gray;

        
            CargarFiltros();


            ConfigurarDataGridView();


            CargarInventario();
        }

  
        private void CargarFiltros()
        {
            try
            {

                var generos = Libro.ObtenerGeneros();
                cmbFiltroGenero.DataSource = generos;

 
                var estados = Libro.ObtenerEstados();
                cmbFiltroEstado.DataSource = estados.ToList();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar filtros: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarDataGridView()
        {
            dgvInventario.EnableHeadersVisualStyles = false;
            dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(121, 85, 72);
            dgvInventario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvInventario.ColumnHeadersHeight = 40;
            dgvInventario.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvInventario.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 214, 229);
            dgvInventario.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvInventario.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvInventario.RowTemplate.Height = 35;
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.ReadOnly = true;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.MultiSelect = false;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarInventario()
        {
            try
            {
                var libros = Libro.ObtenerTodos();
                dgvInventario.DataSource = libros;

                ConfigurarColumnas();
                ActualizarContadorLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
        private void ConfigurarColumnas()
        {
            if (dgvInventario.Columns.Count == 0) return;

            try
            {

                if (dgvInventario.Columns.Contains("Portada"))
                    dgvInventario.Columns["Portada"].Visible = false;

                if (dgvInventario.Columns.Contains("Sinopsis"))
                    dgvInventario.Columns["Sinopsis"].Visible = false;

     
                if (dgvInventario.Columns.Contains("IdLibro"))
                {
                    dgvInventario.Columns["IdLibro"].HeaderText = "ID";
                    dgvInventario.Columns["IdLibro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventario.Columns["IdLibro"].Width = 60;
                }

                if (dgvInventario.Columns.Contains("Nombre"))
                {
                    dgvInventario.Columns["Nombre"].HeaderText = "Nombre del Libro";
                    dgvInventario.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvInventario.Columns.Contains("Genero"))
                {
                    dgvInventario.Columns["Genero"].HeaderText = "Género";
                    dgvInventario.Columns["Genero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventario.Columns["Genero"].Width = 120;
                }

                if (dgvInventario.Columns.Contains("Estado"))
                {
                    dgvInventario.Columns["Estado"].HeaderText = "Estado";
                    dgvInventario.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventario.Columns["Estado"].Width = 120;
                }

                if (dgvInventario.Columns.Contains("Cantidad"))
                {
                    dgvInventario.Columns["Cantidad"].HeaderText = "Disponibles";
                    dgvInventario.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventario.Columns["Cantidad"].Width = 100;
                }

                if (dgvInventario.Columns.Contains("FechaPublicacion"))
                {
                    dgvInventario.Columns["FechaPublicacion"].HeaderText = "F. Publicación";
                    dgvInventario.Columns["FechaPublicacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventario.Columns["FechaPublicacion"].Width = 110;
                    dgvInventario.Columns["FechaPublicacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dgvInventario.Columns.Contains("Disponibilidad"))
                {
                    dgvInventario.Columns["Disponibilidad"].HeaderText = "Disponibilidad";
                    dgvInventario.Columns["Disponibilidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvInventario.Columns["Disponibilidad"].Width = 130;
                }


                foreach (DataGridViewRow row in dgvInventario.Rows)
                {
                    if (row.Cells["Cantidad"].Value != null)
                    {
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                        if (cantidad > 0)
                        {
                            row.Cells["Cantidad"].Style.BackColor = Color.LightGreen;
                            row.Cells["Cantidad"].Style.ForeColor = Color.DarkGreen;
                            row.Cells["Cantidad"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        }
                        else
                        {
                            row.Cells["Cantidad"].Style.BackColor = Color.LightCoral;
                            row.Cells["Cantidad"].Style.ForeColor = Color.DarkRed;
                            row.Cells["Cantidad"].Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al configurar columnas: " + ex.Message);
            }
        }


        private void ActualizarContadorLibros()
        {
            try
            {
                int totalLibros = dgvInventario.Rows.Count;
                int disponibles = 0;

                foreach (DataGridViewRow row in dgvInventario.Rows)
                {
                    if (row.Cells["Cantidad"].Value != null)
                    {
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        if (cantidad > 0) disponibles++;
                    }
                }

                lblInfoRegistros.Text = $"Libros en el inventario: {totalLibros} | Disponibles: {disponibles}";
            }
            catch
            {
                lblInfoRegistros.Text = $"Libros en el inventario: {dgvInventario.Rows.Count}";
            }
        }


        private void AplicarFiltros()
        {
            try
            {
                string busqueda = txtBuscar.Text;
                if (busqueda == placeholderText)
                    busqueda = "";

                string genero = cmbFiltroGenero.SelectedItem?.ToString() ?? "Todos";
                string estado = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todos";

    
                var librosFiltrados = Libro.BuscarConFiltros(busqueda, genero, estado);
                dgvInventario.DataSource = librosFiltrados;

                ConfigurarColumnas();
                ActualizarContadorLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar filtros: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != placeholderText && !string.IsNullOrEmpty(txtBuscar.Text))
            {
                AplicarFiltros();
            }
            else if (string.IsNullOrEmpty(txtBuscar.Text) || txtBuscar.Text == placeholderText)
            {
                if (cmbFiltroGenero.SelectedIndex == 0 && cmbFiltroEstado.SelectedIndex == 0)
                {
                    CargarInventario();
                }
                else
                {
                    AplicarFiltros();
                }
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == placeholderText)
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = placeholderText;
                txtBuscar.ForeColor = Color.Gray;
            }
        }


        private void Filtros_Changed(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

 
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = placeholderText;
            txtBuscar.ForeColor = Color.Gray;

            cmbFiltroGenero.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndex = 0;

          

            CargarInventario();
        }

 
        private void btnPrestarLibro_Click(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un libro de la lista para prestar.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvInventario.SelectedRows[0];
            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value ?? 0);

            if (cantidad <= 0)
            {
                MessageBox.Show("Este libro no está disponible en este momento.",
                    "No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FormPrestamo formPrestamo = new FormPrestamo(usuarioActual);
            if (formPrestamo.ShowDialog() == DialogResult.OK)
            {
                CargarInventario();
            }
        }


        private void btnDevolverLibro_Click(object sender, EventArgs e)
        {
            FormDevolucion formDevolucion = new FormDevolucion(usuarioActual);
            if (formDevolucion.ShowDialog() == DialogResult.OK)
            {
                CargarInventario();
            }
        }

    
        private void btnMisPrestamos_Click(object sender, EventArgs e)
        {
            FormMisPrestamos formMisPrestamos = new FormMisPrestamos(usuarioActual);
            formMisPrestamos.ShowDialog();
        }

   
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
      
                var log = LogProceso.CrearLogout(usuarioActual.IdUsuario, usuarioActual.Username);
                _logService.RegistrarLog(log);

      
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
        }
        private void btnRecomendaciones_Click(object sender, EventArgs e)
        {
            FormRecomendaciones formRecomendaciones = new FormRecomendaciones(usuarioActual);
            formRecomendaciones.ShowDialog();
        }
    }
}