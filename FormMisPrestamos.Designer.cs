namespace BibliotecaApp
{
    partial class FormMisPrestamos
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
            lblUsuarioActual = new Label();
            tabControl = new TabControl();
            tabPrestamosActivos = new TabPage();
            lblInfoActivos = new Label();
            btnDevolver = new Button();
            dgvPrestamosActivos = new DataGridView();
            tabHistorial = new TabPage();
            lblInfoHistorial = new Label();
            groupBoxFiltroHistorial = new GroupBox();
            lblFechaDesde = new Label();
            dtpFechaDesde = new DateTimePicker();
            lblFechaHasta = new Label();
            dtpFechaHasta = new DateTimePicker();
            btnFiltrarHistorial = new Button();
            dgvHistorial = new DataGridView();
            btnActualizar = new Button();
            btnCerrar = new Button();
            panelHeader.SuspendLayout();
            tabControl.SuspendLayout();
            tabPrestamosActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamosActivos).BeginInit();
            tabHistorial.SuspendLayout();
            groupBoxFiltroHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(121, 85, 72);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblUsuarioActual);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(181, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Mis Préstamos";
            // 
            // lblUsuarioActual
            // 
            lblUsuarioActual.AutoSize = true;
            lblUsuarioActual.Font = new Font("Segoe UI", 10F);
            lblUsuarioActual.ForeColor = Color.White;
            lblUsuarioActual.Location = new Point(800, 25);
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(107, 19);
            lblUsuarioActual.TabIndex = 1;
            lblUsuarioActual.Text = "Usuario: [Name]";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPrestamosActivos);
            tabControl.Controls.Add(tabHistorial);
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(20, 90);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(960, 480);
            tabControl.TabIndex = 1;
            // 
            // tabPrestamosActivos
            // 
            tabPrestamosActivos.BackColor = Color.White;
            tabPrestamosActivos.Controls.Add(lblInfoActivos);
            tabPrestamosActivos.Controls.Add(btnDevolver);
            tabPrestamosActivos.Controls.Add(dgvPrestamosActivos);
            tabPrestamosActivos.Location = new Point(4, 26);
            tabPrestamosActivos.Name = "tabPrestamosActivos";
            tabPrestamosActivos.Padding = new Padding(3);
            tabPrestamosActivos.Size = new Size(952, 450);
            tabPrestamosActivos.TabIndex = 0;
            tabPrestamosActivos.Text = "Préstamos Activos";
            // 
            // lblInfoActivos
            // 
            lblInfoActivos.AutoSize = true;
            lblInfoActivos.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblInfoActivos.ForeColor = Color.FromArgb(52, 73, 94);
            lblInfoActivos.Location = new Point(15, 405);
            lblInfoActivos.Name = "lblInfoActivos";
            lblInfoActivos.Size = new Size(159, 15);
            lblInfoActivos.TabIndex = 2;
            lblInfoActivos.Text = "Préstamos activos actuales: 0";
            // 
            // btnDevolver
            // 
            btnDevolver.BackColor = Color.FromArgb(46, 204, 113);
            btnDevolver.FlatStyle = FlatStyle.Flat;
            btnDevolver.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDevolver.ForeColor = Color.White;
            btnDevolver.Location = new Point(775, 395);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(160, 35);
            btnDevolver.TabIndex = 1;
            btnDevolver.Text = "Devolver Libro";
            btnDevolver.UseVisualStyleBackColor = false;
            btnDevolver.Click += btnDevolver_Click;
            // 
            // dgvPrestamosActivos
            // 
            dgvPrestamosActivos.AllowUserToAddRows = false;
            dgvPrestamosActivos.AllowUserToDeleteRows = false;
            dgvPrestamosActivos.BackgroundColor = Color.Tan;
            dgvPrestamosActivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamosActivos.Location = new Point(15, 15);
            dgvPrestamosActivos.MultiSelect = false;
            dgvPrestamosActivos.Name = "dgvPrestamosActivos";
            dgvPrestamosActivos.ReadOnly = true;
            dgvPrestamosActivos.RowHeadersWidth = 51;
            dgvPrestamosActivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamosActivos.Size = new Size(920, 370);
            dgvPrestamosActivos.TabIndex = 0;
            // 
            // tabHistorial
            // 
            tabHistorial.BackColor = Color.White;
            tabHistorial.Controls.Add(lblInfoHistorial);
            tabHistorial.Controls.Add(groupBoxFiltroHistorial);
            tabHistorial.Controls.Add(dgvHistorial);
            tabHistorial.Location = new Point(4, 26);
            tabHistorial.Name = "tabHistorial";
            tabHistorial.Padding = new Padding(3);
            tabHistorial.Size = new Size(952, 450);
            tabHistorial.TabIndex = 1;
            tabHistorial.Text = "Historial Completo";
            // 
            // lblInfoHistorial
            // 
            lblInfoHistorial.AutoSize = true;
            lblInfoHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInfoHistorial.ForeColor = Color.FromArgb(52, 73, 94);
            lblInfoHistorial.Location = new Point(15, 435);
            lblInfoHistorial.Name = "lblInfoHistorial";
            lblInfoHistorial.Size = new Size(116, 15);
            lblInfoHistorial.TabIndex = 2;
            lblInfoHistorial.Text = "Total de registros: 0";
            // 
            // groupBoxFiltroHistorial
            // 
            groupBoxFiltroHistorial.Controls.Add(lblFechaDesde);
            groupBoxFiltroHistorial.Controls.Add(dtpFechaDesde);
            groupBoxFiltroHistorial.Controls.Add(lblFechaHasta);
            groupBoxFiltroHistorial.Controls.Add(dtpFechaHasta);
            groupBoxFiltroHistorial.Controls.Add(btnFiltrarHistorial);
            groupBoxFiltroHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBoxFiltroHistorial.Location = new Point(15, 15);
            groupBoxFiltroHistorial.Name = "groupBoxFiltroHistorial";
            groupBoxFiltroHistorial.Size = new Size(920, 75);
            groupBoxFiltroHistorial.TabIndex = 1;
            groupBoxFiltroHistorial.TabStop = false;
            groupBoxFiltroHistorial.Text = "Filtrar por Fecha";
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Font = new Font("Segoe UI", 9F);
            lblFechaDesde.Location = new Point(15, 25);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(42, 15);
            lblFechaDesde.TabIndex = 0;
            lblFechaDesde.Text = "Desde:";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font = new Font("Segoe UI", 9F);
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(15, 43);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(180, 23);
            dtpFechaDesde.TabIndex = 1;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Font = new Font("Segoe UI", 9F);
            lblFechaHasta.Location = new Point(215, 25);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(40, 15);
            lblFechaHasta.TabIndex = 2;
            lblFechaHasta.Text = "Hasta:";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font = new Font("Segoe UI", 9F);
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(215, 43);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(180, 23);
            dtpFechaHasta.TabIndex = 3;
            // 
            // btnFiltrarHistorial
            // 
            btnFiltrarHistorial.BackColor = Color.FromArgb(52, 152, 219);
            btnFiltrarHistorial.FlatStyle = FlatStyle.Flat;
            btnFiltrarHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFiltrarHistorial.ForeColor = Color.White;
            btnFiltrarHistorial.Location = new Point(415, 40);
            btnFiltrarHistorial.Name = "btnFiltrarHistorial";
            btnFiltrarHistorial.Size = new Size(120, 28);
            btnFiltrarHistorial.TabIndex = 4;
            btnFiltrarHistorial.Text = "Filtrar";
            btnFiltrarHistorial.UseVisualStyleBackColor = false;
            btnFiltrarHistorial.Click += btnFiltrarHistorial_Click;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(15, 100);
            dgvHistorial.MultiSelect = false;
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(920, 330);
            dgvHistorial.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(750, 585);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 35);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(127, 140, 141);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(870, 585);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(110, 35);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FormMisPrestamos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 630);
            Controls.Add(btnCerrar);
            Controls.Add(btnActualizar);
            Controls.Add(tabControl);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormMisPrestamos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mis Préstamos - Sistema Biblioteca";
            Load += FormMisPrestamos_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPrestamosActivos.ResumeLayout(false);
            tabPrestamosActivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamosActivos).EndInit();
            tabHistorial.ResumeLayout(false);
            tabHistorial.PerformLayout();
            groupBoxFiltroHistorial.ResumeLayout(false);
            groupBoxFiltroHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPrestamosActivos;
        private System.Windows.Forms.DataGridView dgvPrestamosActivos;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Label lblInfoActivos;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.GroupBox groupBoxFiltroHistorial;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Button btnFiltrarHistorial;
        private System.Windows.Forms.Label lblInfoHistorial;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
    }
}