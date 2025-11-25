using System;
using System.Linq;
using System.Windows.Forms;
using BibliotecaApp.Services;

namespace BibliotecaApp
{
    public partial class FormVisualizarLogs : Form
    {
        private readonly LogProcesoService _service = new LogProcesoService();

        public FormVisualizarLogs()
        {
            InitializeComponent();
        }

        private void FormVisualizarLogs_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Now.AddMonths(-1);
            dtpFechaHasta.Value = DateTime.Now;
            CargarLogs();
        }

        private void CargarLogs()
        {
            var logs = _service.ObtenerLogs();
            dgvLogs.DataSource = logs;
            lblTotalRegistros.Text = $"Total Registros: {logs.Count()}";

            dgvLogs.Columns["IdLog"].Visible = false;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var logs = _service.ObtenerLogs();


            if (!string.IsNullOrWhiteSpace(txtFiltroUsuario.Text))
                logs = logs.Where(l => l.Username.ToLower().Contains(txtFiltroUsuario.Text.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(txtFiltroLibro.Text))
                logs = logs.Where(l => l.NombreLibro.ToLower().Contains(txtFiltroLibro.Text.ToLower())).ToList();

            var desde = dtpFechaDesde.Value.Date;
            var hasta = dtpFechaHasta.Value.Date.AddDays(1);

            logs = logs.Where(l =>
                (l.FechaPrestamo >= desde && l.FechaPrestamo < hasta) ||
                (l.FechaDevolucion >= desde && l.FechaDevolucion < hasta)
            ).ToList();

            dgvLogs.DataSource = logs;
            lblTotalRegistros.Text = $"Filtrados: {logs.Count()}";
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroUsuario.Clear();
            txtFiltroLibro.Clear();
            dtpFechaDesde.Value = DateTime.Now.AddMonths(-1);
            dtpFechaHasta.Value = DateTime.Now;
            CargarLogs();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarLogs();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
