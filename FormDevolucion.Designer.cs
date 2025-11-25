namespace BibliotecaApp
{
    partial class FormDevolucion
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
            groupBoxPrestamos = new GroupBox();
            btnActualizar = new Button();
            dgvPrestamosActivos = new DataGridView();
            groupBoxDevolucion = new GroupBox();
            lblPrestamoId = new Label();
            txtPrestamoId = new TextBox();
            lblLibroDevolucion = new Label();
            txtLibroDevolucion = new TextBox();
            lblCantidadPrestada = new Label();
            txtCantidadPrestada = new TextBox();
            lblCantidadDevolver = new Label();
            numCantidadDevolver = new NumericUpDown();
            lblFechaDevolucion = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            btnRealizarDevolucion = new Button();
            btnCancelar = new Button();
            lblEstado = new Label();
            panelHeader.SuspendLayout();
            groupBoxPrestamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamosActivos).BeginInit();
            groupBoxDevolucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadDevolver).BeginInit();
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
            panelHeader.Size = new Size(900, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(256, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Devolución de Libros";
            // 
            // lblUsuarioActual
            // 
            lblUsuarioActual.AutoSize = true;
            lblUsuarioActual.Font = new Font("Segoe UI", 10F);
            lblUsuarioActual.ForeColor = Color.White;
            lblUsuarioActual.Location = new Point(650, 25);
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(107, 19);
            lblUsuarioActual.TabIndex = 1;
            lblUsuarioActual.Text = "Usuario: [Name]";
            // 
            // groupBoxPrestamos
            // 
            groupBoxPrestamos.Controls.Add(btnActualizar);
            groupBoxPrestamos.Controls.Add(dgvPrestamosActivos);
            groupBoxPrestamos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxPrestamos.Location = new Point(20, 90);
            groupBoxPrestamos.Name = "groupBoxPrestamos";
            groupBoxPrestamos.Size = new Size(860, 300);
            groupBoxPrestamos.TabIndex = 1;
            groupBoxPrestamos.TabStop = false;
            groupBoxPrestamos.Text = "Préstamos Activos";
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(710, 25);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(130, 27);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // dgvPrestamosActivos
            // 
            dgvPrestamosActivos.AllowUserToAddRows = false;
            dgvPrestamosActivos.AllowUserToDeleteRows = false;
            dgvPrestamosActivos.BackgroundColor = Color.Tan;
            dgvPrestamosActivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamosActivos.Location = new Point(15, 60);
            dgvPrestamosActivos.MultiSelect = false;
            dgvPrestamosActivos.Name = "dgvPrestamosActivos";
            dgvPrestamosActivos.ReadOnly = true;
            dgvPrestamosActivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamosActivos.Size = new Size(825, 220);
            dgvPrestamosActivos.TabIndex = 0;
            dgvPrestamosActivos.SelectionChanged += dgvPrestamosActivos_SelectionChanged;
            // 
            // groupBoxDevolucion
            // 
            groupBoxDevolucion.Controls.Add(lblPrestamoId);
            groupBoxDevolucion.Controls.Add(txtPrestamoId);
            groupBoxDevolucion.Controls.Add(lblLibroDevolucion);
            groupBoxDevolucion.Controls.Add(txtLibroDevolucion);
            groupBoxDevolucion.Controls.Add(lblCantidadPrestada);
            groupBoxDevolucion.Controls.Add(txtCantidadPrestada);
            groupBoxDevolucion.Controls.Add(lblCantidadDevolver);
            groupBoxDevolucion.Controls.Add(numCantidadDevolver);
            groupBoxDevolucion.Controls.Add(lblFechaDevolucion);
            groupBoxDevolucion.Controls.Add(dtpFechaDevolucion);
            groupBoxDevolucion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxDevolucion.Location = new Point(20, 410);
            groupBoxDevolucion.Name = "groupBoxDevolucion";
            groupBoxDevolucion.Size = new Size(860, 120);
            groupBoxDevolucion.TabIndex = 2;
            groupBoxDevolucion.TabStop = false;
            groupBoxDevolucion.Text = "Información de la Devolución";
            // 
            // lblPrestamoId
            // 
            lblPrestamoId.AutoSize = true;
            lblPrestamoId.Font = new Font("Segoe UI", 9F);
            lblPrestamoId.Location = new Point(15, 30);
            lblPrestamoId.Name = "lblPrestamoId";
            lblPrestamoId.Size = new Size(74, 15);
            lblPrestamoId.TabIndex = 0;
            lblPrestamoId.Text = "ID Préstamo:";
            // 
            // txtPrestamoId
            // 
            txtPrestamoId.Font = new Font("Segoe UI", 9F);
            txtPrestamoId.Location = new Point(15, 50);
            txtPrestamoId.Name = "txtPrestamoId";
            txtPrestamoId.ReadOnly = true;
            txtPrestamoId.Size = new Size(100, 23);
            txtPrestamoId.TabIndex = 1;
            txtPrestamoId.TextAlign = HorizontalAlignment.Center;
            // 
            // lblLibroDevolucion
            // 
            lblLibroDevolucion.AutoSize = true;
            lblLibroDevolucion.Font = new Font("Segoe UI", 9F);
            lblLibroDevolucion.Location = new Point(135, 30);
            lblLibroDevolucion.Name = "lblLibroDevolucion";
            lblLibroDevolucion.Size = new Size(37, 15);
            lblLibroDevolucion.TabIndex = 2;
            lblLibroDevolucion.Text = "Libro:";
            // 
            // txtLibroDevolucion
            // 
            txtLibroDevolucion.Font = new Font("Segoe UI", 9F);
            txtLibroDevolucion.Location = new Point(135, 50);
            txtLibroDevolucion.Name = "txtLibroDevolucion";
            txtLibroDevolucion.ReadOnly = true;
            txtLibroDevolucion.Size = new Size(300, 23);
            txtLibroDevolucion.TabIndex = 3;
            // 
            // lblCantidadPrestada
            // 
            lblCantidadPrestada.AutoSize = true;
            lblCantidadPrestada.Font = new Font("Segoe UI", 9F);
            lblCantidadPrestada.Location = new Point(455, 30);
            lblCantidadPrestada.Name = "lblCantidadPrestada";
            lblCantidadPrestada.Size = new Size(55, 15);
            lblCantidadPrestada.TabIndex = 4;
            lblCantidadPrestada.Text = "Prestada:";
            // 
            // txtCantidadPrestada
            // 
            txtCantidadPrestada.Font = new Font("Segoe UI", 9F);
            txtCantidadPrestada.Location = new Point(455, 50);
            txtCantidadPrestada.Name = "txtCantidadPrestada";
            txtCantidadPrestada.ReadOnly = true;
            txtCantidadPrestada.Size = new Size(80, 23);
            txtCantidadPrestada.TabIndex = 5;
            txtCantidadPrestada.TextAlign = HorizontalAlignment.Center;
            // 
            // lblCantidadDevolver
            // 
            lblCantidadDevolver.AutoSize = true;
            lblCantidadDevolver.Font = new Font("Segoe UI", 9F);
            lblCantidadDevolver.Location = new Point(555, 30);
            lblCantidadDevolver.Name = "lblCantidadDevolver";
            lblCantidadDevolver.Size = new Size(116, 15);
            lblCantidadDevolver.TabIndex = 6;
            lblCantidadDevolver.Text = "Cantidad a Devolver:";
            // 
            // numCantidadDevolver
            // 
            numCantidadDevolver.Font = new Font("Segoe UI", 9F);
            numCantidadDevolver.Location = new Point(555, 50);
            numCantidadDevolver.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidadDevolver.Name = "numCantidadDevolver";
            numCantidadDevolver.Size = new Size(100, 23);
            numCantidadDevolver.TabIndex = 7;
            numCantidadDevolver.TextAlign = HorizontalAlignment.Center;
            numCantidadDevolver.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFechaDevolucion
            // 
            lblFechaDevolucion.AutoSize = true;
            lblFechaDevolucion.Font = new Font("Segoe UI", 9F);
            lblFechaDevolucion.Location = new Point(675, 30);
            lblFechaDevolucion.Name = "lblFechaDevolucion";
            lblFechaDevolucion.Size = new Size(104, 15);
            lblFechaDevolucion.TabIndex = 8;
            lblFechaDevolucion.Text = "Fecha Devolución:";
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Font = new Font("Segoe UI", 9F);
            dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            dtpFechaDevolucion.Location = new Point(675, 50);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Size = new Size(165, 23);
            dtpFechaDevolucion.TabIndex = 9;
            // 
            // btnRealizarDevolucion
            // 
            btnRealizarDevolucion.BackColor = Color.FromArgb(46, 204, 113);
            btnRealizarDevolucion.FlatStyle = FlatStyle.Flat;
            btnRealizarDevolucion.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRealizarDevolucion.ForeColor = Color.White;
            btnRealizarDevolucion.Location = new Point(540, 550);
            btnRealizarDevolucion.Name = "btnRealizarDevolucion";
            btnRealizarDevolucion.Size = new Size(170, 40);
            btnRealizarDevolucion.TabIndex = 3;
            btnRealizarDevolucion.Text = "Realizar Devolución";
            btnRealizarDevolucion.UseVisualStyleBackColor = false;
            btnRealizarDevolucion.Click += btnRealizarDevolucion_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(231, 76, 60);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(720, 550);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 40);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblEstado.ForeColor = Color.FromArgb(52, 73, 94);
            lblEstado.Location = new Point(20, 560);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(204, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Seleccione un préstamo para devolver";
            // 
            // FormDevolucion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 610);
            Controls.Add(lblEstado);
            Controls.Add(btnCancelar);
            Controls.Add(btnRealizarDevolucion);
            Controls.Add(groupBoxDevolucion);
            Controls.Add(groupBoxPrestamos);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormDevolucion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Devolución de Libros";
            Load += FormDevolucion_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupBoxPrestamos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPrestamosActivos).EndInit();
            groupBoxDevolucion.ResumeLayout(false);
            groupBoxDevolucion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadDevolver).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.GroupBox groupBoxPrestamos;
        private System.Windows.Forms.DataGridView dgvPrestamosActivos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox groupBoxDevolucion;
        private System.Windows.Forms.Label lblPrestamoId;
        private System.Windows.Forms.TextBox txtPrestamoId;
        private System.Windows.Forms.Label lblLibroDevolucion;
        private System.Windows.Forms.TextBox txtLibroDevolucion;
        private System.Windows.Forms.Label lblCantidadPrestada;
        private System.Windows.Forms.TextBox txtCantidadPrestada;
        private System.Windows.Forms.Label lblCantidadDevolver;
        private System.Windows.Forms.NumericUpDown numCantidadDevolver;
        private System.Windows.Forms.Label lblFechaDevolucion;
        private System.Windows.Forms.DateTimePicker dtpFechaDevolucion;
        private System.Windows.Forms.Button btnRealizarDevolucion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblEstado;
    }
}