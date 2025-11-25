    namespace BibliotecaApp
    {
        partial class FormPrestamo
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
            groupBoxLibros = new GroupBox();
            lblBuscar = new Label();
            txtBuscarLibro = new TextBox();
            btnBuscar = new Button();
            dgvLibrosDisponibles = new DataGridView();
            groupBoxPrestamo = new GroupBox();
            lblLibroSeleccionado = new Label();
            txtLibroSeleccionado = new TextBox();
            lblCantidadDisponible = new Label();
            txtCantidadDisponible = new TextBox();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            lblFechaPrestamo = new Label();
            dtpFechaPrestamo = new DateTimePicker();
            btnRealizarPrestamo = new Button();
            btnCancelar = new Button();
            lblEstado = new Label();
            panelHeader.SuspendLayout();
            groupBoxLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibrosDisponibles).BeginInit();
            groupBoxPrestamo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
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
            lblTitulo.Size = new Size(234, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Préstamo de Libros";
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
            // groupBoxLibros
            // 
            groupBoxLibros.Controls.Add(lblBuscar);
            groupBoxLibros.Controls.Add(txtBuscarLibro);
            groupBoxLibros.Controls.Add(btnBuscar);
            groupBoxLibros.Controls.Add(dgvLibrosDisponibles);
            groupBoxLibros.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxLibros.Location = new Point(20, 90);
            groupBoxLibros.Name = "groupBoxLibros";
            groupBoxLibros.Size = new Size(860, 300);
            groupBoxLibros.TabIndex = 1;
            groupBoxLibros.TabStop = false;
            groupBoxLibros.Text = "Libros Disponibles";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F);
            lblBuscar.Location = new Point(15, 30);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(75, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar Libro:";
            // 
            // txtBuscarLibro
            // 
            txtBuscarLibro.Font = new Font("Segoe UI", 9F);
            txtBuscarLibro.Location = new Point(100, 27);
            txtBuscarLibro.Name = "txtBuscarLibro";
            txtBuscarLibro.Size = new Size(600, 23);
            txtBuscarLibro.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(52, 152, 219);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(710, 25);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(130, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvLibrosDisponibles
            // 
            dgvLibrosDisponibles.AllowUserToAddRows = false;
            dgvLibrosDisponibles.AllowUserToDeleteRows = false;
            dgvLibrosDisponibles.BackgroundColor = Color.Tan;
            dgvLibrosDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibrosDisponibles.Location = new Point(15, 60);
            dgvLibrosDisponibles.MultiSelect = false;
            dgvLibrosDisponibles.Name = "dgvLibrosDisponibles";
            dgvLibrosDisponibles.ReadOnly = true;
            dgvLibrosDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibrosDisponibles.Size = new Size(825, 220);
            dgvLibrosDisponibles.TabIndex = 3;
            dgvLibrosDisponibles.SelectionChanged += dgvLibrosDisponibles_SelectionChanged;
            // 
            // groupBoxPrestamo
            // 
            groupBoxPrestamo.Controls.Add(lblLibroSeleccionado);
            groupBoxPrestamo.Controls.Add(txtLibroSeleccionado);
            groupBoxPrestamo.Controls.Add(lblCantidadDisponible);
            groupBoxPrestamo.Controls.Add(txtCantidadDisponible);
            groupBoxPrestamo.Controls.Add(lblCantidad);
            groupBoxPrestamo.Controls.Add(numCantidad);
            groupBoxPrestamo.Controls.Add(lblFechaPrestamo);
            groupBoxPrestamo.Controls.Add(dtpFechaPrestamo);
            groupBoxPrestamo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxPrestamo.Location = new Point(20, 410);
            groupBoxPrestamo.Name = "groupBoxPrestamo";
            groupBoxPrestamo.Size = new Size(860, 120);
            groupBoxPrestamo.TabIndex = 2;
            groupBoxPrestamo.TabStop = false;
            groupBoxPrestamo.Text = "Información del Préstamo";
            // 
            // lblLibroSeleccionado
            // 
            lblLibroSeleccionado.AutoSize = true;
            lblLibroSeleccionado.Font = new Font("Segoe UI", 9F);
            lblLibroSeleccionado.Location = new Point(15, 30);
            lblLibroSeleccionado.Name = "lblLibroSeleccionado";
            lblLibroSeleccionado.Size = new Size(37, 15);
            lblLibroSeleccionado.TabIndex = 0;
            lblLibroSeleccionado.Text = "Libro:";
            // 
            // txtLibroSeleccionado
            // 
            txtLibroSeleccionado.Font = new Font("Segoe UI", 9F);
            txtLibroSeleccionado.Location = new Point(15, 50);
            txtLibroSeleccionado.Name = "txtLibroSeleccionado";
            txtLibroSeleccionado.ReadOnly = true;
            txtLibroSeleccionado.Size = new Size(400, 23);
            txtLibroSeleccionado.TabIndex = 1;
            // 
            // lblCantidadDisponible
            // 
            lblCantidadDisponible.AutoSize = true;
            lblCantidadDisponible.Font = new Font("Segoe UI", 9F);
            lblCantidadDisponible.Location = new Point(435, 30);
            lblCantidadDisponible.Name = "lblCantidadDisponible";
            lblCantidadDisponible.Size = new Size(66, 15);
            lblCantidadDisponible.TabIndex = 2;
            lblCantidadDisponible.Text = "Disponible:";
            // 
            // txtCantidadDisponible
            // 
            txtCantidadDisponible.Font = new Font("Segoe UI", 9F);
            txtCantidadDisponible.Location = new Point(435, 50);
            txtCantidadDisponible.Name = "txtCantidadDisponible";
            txtCantidadDisponible.ReadOnly = true;
            txtCantidadDisponible.Size = new Size(80, 23);
            txtCantidadDisponible.TabIndex = 3;
            txtCantidadDisponible.TextAlign = HorizontalAlignment.Center;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F);
            lblCantidad.Location = new Point(535, 30);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(106, 15);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "Cantidad a Prestar:";
            // 
            // numCantidad
            // 
            numCantidad.Font = new Font("Segoe UI", 9F);
            numCantidad.Location = new Point(535, 50);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(100, 23);
            numCantidad.TabIndex = 5;
            numCantidad.TextAlign = HorizontalAlignment.Center;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblFechaPrestamo
            // 
            lblFechaPrestamo.AutoSize = true;
            lblFechaPrestamo.Font = new Font("Segoe UI", 9F);
            lblFechaPrestamo.Location = new Point(655, 30);
            lblFechaPrestamo.Name = "lblFechaPrestamo";
            lblFechaPrestamo.Size = new Size(94, 15);
            lblFechaPrestamo.TabIndex = 6;
            lblFechaPrestamo.Text = "Fecha Préstamo:";
            // 
            // dtpFechaPrestamo
            // 
            dtpFechaPrestamo.Font = new Font("Segoe UI", 9F);
            dtpFechaPrestamo.Format = DateTimePickerFormat.Short;
            dtpFechaPrestamo.Location = new Point(655, 50);
            dtpFechaPrestamo.Name = "dtpFechaPrestamo";
            dtpFechaPrestamo.Size = new Size(185, 23);
            dtpFechaPrestamo.TabIndex = 7;
            // 
            // btnRealizarPrestamo
            // 
            btnRealizarPrestamo.BackColor = Color.FromArgb(46, 204, 113);
            btnRealizarPrestamo.FlatStyle = FlatStyle.Flat;
            btnRealizarPrestamo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRealizarPrestamo.ForeColor = Color.White;
            btnRealizarPrestamo.Location = new Point(550, 550);
            btnRealizarPrestamo.Name = "btnRealizarPrestamo";
            btnRealizarPrestamo.Size = new Size(160, 40);
            btnRealizarPrestamo.TabIndex = 3;
            btnRealizarPrestamo.Text = "Realizar Préstamo";
            btnRealizarPrestamo.UseVisualStyleBackColor = false;
            btnRealizarPrestamo.Click += btnRealizarPrestamo_Click;
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
            lblEstado.Size = new Size(157, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Seleccione un libro de la lista";
            // 
            // FormPrestamo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 610);
            Controls.Add(lblEstado);
            Controls.Add(btnCancelar);
            Controls.Add(btnRealizarPrestamo);
            Controls.Add(groupBoxPrestamo);
            Controls.Add(groupBoxLibros);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormPrestamo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Préstamo de Libros";
            Load += FormPrestamo_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupBoxLibros.ResumeLayout(false);
            groupBoxLibros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibrosDisponibles).EndInit();
            groupBoxPrestamo.ResumeLayout(false);
            groupBoxPrestamo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
            private System.Windows.Forms.Label lblTitulo;
            private System.Windows.Forms.Label lblUsuarioActual;
            private System.Windows.Forms.GroupBox groupBoxLibros;
            private System.Windows.Forms.Label lblBuscar;
            private System.Windows.Forms.TextBox txtBuscarLibro;
            private System.Windows.Forms.Button btnBuscar;
            private System.Windows.Forms.DataGridView dgvLibrosDisponibles;
            private System.Windows.Forms.GroupBox groupBoxPrestamo;
            private System.Windows.Forms.Label lblLibroSeleccionado;
            private System.Windows.Forms.TextBox txtLibroSeleccionado;
            private System.Windows.Forms.Label lblCantidadDisponible;
            private System.Windows.Forms.TextBox txtCantidadDisponible;
            private System.Windows.Forms.Label lblCantidad;
            private System.Windows.Forms.NumericUpDown numCantidad;
            private System.Windows.Forms.Label lblFechaPrestamo;
            private System.Windows.Forms.DateTimePicker dtpFechaPrestamo;
            private System.Windows.Forms.Button btnRealizarPrestamo;
            private System.Windows.Forms.Button btnCancelar;
            private System.Windows.Forms.Label lblEstado;
        }
    }