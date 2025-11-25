namespace BibliotecaApp
{
    partial class FormVisualizarLogs
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitulo = new Label();
            dgvLogs = new DataGridView();
            groupBoxFiltros = new GroupBox();
            lblFiltroUsuario = new Label();
            txtFiltroUsuario = new TextBox();
            lblFiltroLibro = new Label();
            txtFiltroLibro = new TextBox();
            lblFechaDesde = new Label();
            dtpFechaDesde = new DateTimePicker();
            lblFechaHasta = new Label();
            dtpFechaHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnLimpiarFiltros = new Button();
            btnActualizar = new Button();
            btnCerrar = new Button();
            lblTotalRegistros = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).BeginInit();
            groupBoxFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(121, 85, 72);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(363, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Historial de Actividades (Logs)";
            // 
            // dgvLogs
            // 
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AllowUserToDeleteRows = false;
            dgvLogs.BackgroundColor = Color.Tan;
            dgvLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLogs.Location = new Point(20, 190);
            dgvLogs.MultiSelect = false;
            dgvLogs.Name = "dgvLogs";
            dgvLogs.ReadOnly = true;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.Size = new Size(1160, 420);
            dgvLogs.TabIndex = 1;
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.Controls.Add(lblFiltroUsuario);
            groupBoxFiltros.Controls.Add(txtFiltroUsuario);
            groupBoxFiltros.Controls.Add(lblFiltroLibro);
            groupBoxFiltros.Controls.Add(txtFiltroLibro);
            groupBoxFiltros.Controls.Add(lblFechaDesde);
            groupBoxFiltros.Controls.Add(dtpFechaDesde);
            groupBoxFiltros.Controls.Add(lblFechaHasta);
            groupBoxFiltros.Controls.Add(dtpFechaHasta);
            groupBoxFiltros.Controls.Add(btnFiltrar);
            groupBoxFiltros.Controls.Add(btnLimpiarFiltros);
            groupBoxFiltros.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFiltros.Location = new Point(20, 75);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(1160, 100);
            groupBoxFiltros.TabIndex = 2;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de Búsqueda";
            // 
            // lblFiltroUsuario
            // 
            lblFiltroUsuario.AutoSize = true;
            lblFiltroUsuario.Font = new Font("Segoe UI", 9F);
            lblFiltroUsuario.Location = new Point(15, 30);
            lblFiltroUsuario.Name = "lblFiltroUsuario";
            lblFiltroUsuario.Size = new Size(50, 15);
            lblFiltroUsuario.TabIndex = 0;
            lblFiltroUsuario.Text = "Usuario:";
            // 
            // txtFiltroUsuario
            // 
            txtFiltroUsuario.Font = new Font("Segoe UI", 9F);
            txtFiltroUsuario.Location = new Point(15, 48);
            txtFiltroUsuario.Name = "txtFiltroUsuario";
            txtFiltroUsuario.Size = new Size(200, 23);
            txtFiltroUsuario.TabIndex = 1;
            // 
            // lblFiltroLibro
            // 
            lblFiltroLibro.AutoSize = true;
            lblFiltroLibro.Font = new Font("Segoe UI", 9F);
            lblFiltroLibro.Location = new Point(235, 30);
            lblFiltroLibro.Name = "lblFiltroLibro";
            lblFiltroLibro.Size = new Size(37, 15);
            lblFiltroLibro.TabIndex = 2;
            lblFiltroLibro.Text = "Libro:";
            // 
            // txtFiltroLibro
            // 
            txtFiltroLibro.Font = new Font("Segoe UI", 9F);
            txtFiltroLibro.Location = new Point(235, 48);
            txtFiltroLibro.Name = "txtFiltroLibro";
            txtFiltroLibro.Size = new Size(250, 23);
            txtFiltroLibro.TabIndex = 3;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Font = new Font("Segoe UI", 9F);
            lblFechaDesde.Location = new Point(505, 30);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(76, 15);
            lblFechaDesde.TabIndex = 4;
            lblFechaDesde.Text = "Fecha Desde:";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font = new Font("Segoe UI", 9F);
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(505, 48);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(150, 23);
            dtpFechaDesde.TabIndex = 5;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Font = new Font("Segoe UI", 9F);
            lblFechaHasta.Location = new Point(675, 30);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(74, 15);
            lblFechaHasta.TabIndex = 6;
            lblFechaHasta.Text = "Fecha Hasta:";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font = new Font("Segoe UI", 9F);
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(675, 48);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(150, 23);
            dtpFechaHasta.TabIndex = 7;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(52, 152, 219);
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(850, 45);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(120, 28);
            btnFiltrar.TabIndex = 8;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(149, 165, 166);
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = Color.White;
            btnLimpiarFiltros.Location = new Point(980, 45);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(120, 28);
            btnLimpiarFiltros.TabIndex = 9;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(46, 204, 113);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(940, 625);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(120, 35);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(1070, 625);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(110, 35);
            btnCerrar.TabIndex = 4;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalRegistros.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotalRegistros.Location = new Point(20, 635);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(102, 15);
            lblTotalRegistros.TabIndex = 5;
            lblTotalRegistros.Text = "Total Registros: 0";
            // 
            // FormVisualizarLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 675);
            Controls.Add(lblTotalRegistros);
            Controls.Add(btnCerrar);
            Controls.Add(btnActualizar);
            Controls.Add(groupBoxFiltros);
            Controls.Add(dgvLogs);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormVisualizarLogs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial de Actividades - Sistema Biblioteca";
            Load += FormVisualizarLogs_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLogs).EndInit();
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label lblFiltroUsuario;
        private System.Windows.Forms.TextBox txtFiltroUsuario;
        private System.Windows.Forms.Label lblFiltroLibro;
        private System.Windows.Forms.TextBox txtFiltroLibro;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTotalRegistros;
    }
}