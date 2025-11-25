using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace BibliotecaApp
{
    public partial class Form1 : Form
    {
        private readonly Conexion conexion;
        private NpgsqlDataAdapter adaptador;
        private DataTable tablaActual;
        private string tablaSeleccionada = "";

        public Form1()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cargar las tablas del sistema
            cmbTablas.Items.AddRange(new string[]
            {
                "usuario",
                "libro",
                "prestamo",
                "devolucion",
                "log_procesos",
                "recomendacion"
            });

            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.AllowUserToAddRows = false;
            lblEstado.Text = "Seleccione una tabla para comenzar.";
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            tablaSeleccionada = cmbTablas.SelectedItem.ToString();
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (string.IsNullOrEmpty(tablaSeleccionada)) return;

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = $"SELECT * FROM {tablaSeleccionada}";
                    adaptador = new NpgsqlDataAdapter(query, conn);
                    var builder = new NpgsqlCommandBuilder(adaptador);

                    tablaActual = new DataTable();
                    adaptador.Fill(tablaActual);
                    dgvDatos.DataSource = tablaActual;

                    lblEstado.Text = $"Datos cargados de la tabla: {tablaSeleccionada}";
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al cargar datos: " + ex.Message;
            }
        }

        // ===================== BOTONES CRUD =====================

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tablaActual == null)
            {
                MessageBox.Show("Seleccione una tabla primero.");
                return;
            }

            DataRow nuevaFila = tablaActual.NewRow();
            tablaActual.Rows.Add(nuevaFila);
            lblEstado.Text = "Fila agregada. Edite los valores y presione Guardar.";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
                return;
            }

            foreach (DataGridViewRow fila in dgvDatos.SelectedRows)
            {
                if (!fila.IsNewRow)
                    dgvDatos.Rows.Remove(fila);
            }

            lblEstado.Text = "Fila marcada para eliminación. Presione Guardar para aplicar.";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tablaActual == null)
            {
                MessageBox.Show("No hay datos para guardar.");
                return;
            }

            try
            {
                using (var conn = conexion.ObtenerConexion())
                {
                    string query = $"SELECT * FROM {tablaSeleccionada}";
                    adaptador = new NpgsqlDataAdapter(query, conn);
                    var builder = new NpgsqlCommandBuilder(adaptador);

                    adaptador.InsertCommand = builder.GetInsertCommand();
                    adaptador.UpdateCommand = builder.GetUpdateCommand();
                    adaptador.DeleteCommand = builder.GetDeleteCommand();

                    adaptador.Update(tablaActual);
                }

                MessageBox.Show("Cambios guardados correctamente.");
                CargarDatos(); // Recargar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
            lblEstado.Text = "Datos actualizados desde la base de datos.";
        }
    }
}
