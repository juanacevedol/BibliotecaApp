namespace BibliotecaApp
{
    partial class FormGestionLibros
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
            dgvLibros = new DataGridView();
            groupBoxDatos = new GroupBox();
            lblIdLibro = new Label();
            txtIdLibro = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblGenero = new Label();
            txtGenero = new TextBox();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            lblCantidad = new Label();
            numCantidad = new NumericUpDown();
            lblFechaPublicacion = new Label();
            dtpFechaPublicacion = new DateTimePicker();
            lblSinopsis = new Label();
            txtSinopsis = new TextBox();
            btnNuevo = new Button();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnCerrar = new Button();
            lblEstadoOperacion = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            groupBoxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(121, 85, 72);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(213, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Libros";
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.BackgroundColor = Color.Tan;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(20, 80);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(700, 500);
            dgvLibros.TabIndex = 1;
            dgvLibros.SelectionChanged += dgvLibros_SelectionChanged;
            // 
            // groupBoxDatos
            // 
            groupBoxDatos.Controls.Add(lblIdLibro);
            groupBoxDatos.Controls.Add(txtIdLibro);
            groupBoxDatos.Controls.Add(lblNombre);
            groupBoxDatos.Controls.Add(txtNombre);
            groupBoxDatos.Controls.Add(lblGenero);
            groupBoxDatos.Controls.Add(txtGenero);
            groupBoxDatos.Controls.Add(lblEstado);
            groupBoxDatos.Controls.Add(cmbEstado);
            groupBoxDatos.Controls.Add(lblCantidad);
            groupBoxDatos.Controls.Add(numCantidad);
            groupBoxDatos.Controls.Add(lblFechaPublicacion);
            groupBoxDatos.Controls.Add(dtpFechaPublicacion);
            groupBoxDatos.Controls.Add(lblSinopsis);
            groupBoxDatos.Controls.Add(txtSinopsis);
            groupBoxDatos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxDatos.Location = new Point(740, 80);
            groupBoxDatos.Name = "groupBoxDatos";
            groupBoxDatos.Size = new Size(340, 420);
            groupBoxDatos.TabIndex = 2;
            groupBoxDatos.TabStop = false;
            groupBoxDatos.Text = "Datos del Libro";
            // 
            // lblIdLibro
            // 
            lblIdLibro.AutoSize = true;
            lblIdLibro.Font = new Font("Segoe UI", 9F);
            lblIdLibro.Location = new Point(15, 30);
            lblIdLibro.Name = "lblIdLibro";
            lblIdLibro.Size = new Size(51, 15);
            lblIdLibro.TabIndex = 0;
            lblIdLibro.Text = "ID Libro:";
            // 
            // txtIdLibro
            // 
            txtIdLibro.Font = new Font("Segoe UI", 9F);
            txtIdLibro.Location = new Point(15, 48);
            txtIdLibro.Name = "txtIdLibro";
            txtIdLibro.ReadOnly = true;
            txtIdLibro.Size = new Size(100, 23);
            txtIdLibro.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F);
            lblNombre.Location = new Point(15, 80);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9F);
            txtNombre.Location = new Point(15, 98);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(305, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Font = new Font("Segoe UI", 9F);
            lblGenero.Location = new Point(15, 130);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(48, 15);
            lblGenero.TabIndex = 4;
            lblGenero.Text = "Género:";
            // 
            // txtGenero
            // 
            txtGenero.Font = new Font("Segoe UI", 9F);
            txtGenero.Location = new Point(15, 148);
            txtGenero.Name = "txtGenero";
            txtGenero.Size = new Size(305, 23);
            txtGenero.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F);
            lblEstado.Location = new Point(15, 180);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Segoe UI", 9F);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Disponible", "No Disponible" });
            cmbEstado.Location = new Point(15, 198);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(150, 23);
            cmbEstado.TabIndex = 7;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F);
            lblCantidad.Location = new Point(180, 180);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 8;
            lblCantidad.Text = "Cantidad:";
            // 
            // numCantidad
            // 
            numCantidad.Font = new Font("Segoe UI", 9F);
            numCantidad.Location = new Point(180, 198);
            numCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(140, 23);
            numCantidad.TabIndex = 9;
            // 
            // lblFechaPublicacion
            // 
            lblFechaPublicacion.AutoSize = true;
            lblFechaPublicacion.Font = new Font("Segoe UI", 9F);
            lblFechaPublicacion.Location = new Point(15, 230);
            lblFechaPublicacion.Name = "lblFechaPublicacion";
            lblFechaPublicacion.Size = new Size(106, 15);
            lblFechaPublicacion.TabIndex = 10;
            lblFechaPublicacion.Text = "Fecha Publicación:";
            // 
            // dtpFechaPublicacion
            // 
            dtpFechaPublicacion.Font = new Font("Segoe UI", 9F);
            dtpFechaPublicacion.Format = DateTimePickerFormat.Short;
            dtpFechaPublicacion.Location = new Point(15, 248);
            dtpFechaPublicacion.Name = "dtpFechaPublicacion";
            dtpFechaPublicacion.Size = new Size(305, 23);
            dtpFechaPublicacion.TabIndex = 11;
            // 
            // lblSinopsis
            // 
            lblSinopsis.AutoSize = true;
            lblSinopsis.Font = new Font("Segoe UI", 9F);
            lblSinopsis.Location = new Point(15, 280);
            lblSinopsis.Name = "lblSinopsis";
            lblSinopsis.Size = new Size(53, 15);
            lblSinopsis.TabIndex = 12;
            lblSinopsis.Text = "Sinopsis:";
            // 
            // txtSinopsis
            // 
            txtSinopsis.Font = new Font("Segoe UI", 9F);
            txtSinopsis.Location = new Point(15, 298);
            txtSinopsis.Multiline = true;
            txtSinopsis.Name = "txtSinopsis";
            txtSinopsis.ScrollBars = ScrollBars.Vertical;
            txtSinopsis.Size = new Size(305, 105);
            txtSinopsis.TabIndex = 13;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(52, 152, 219);
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(740, 510);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 35);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "agregar";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 204, 113);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(850, 510);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(114, 35);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Guardar ";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(241, 196, 15);
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(970, 510);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(110, 35);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(231, 76, 60);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(740, 555);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 35);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(860, 555);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 35);
            btnActualizar.TabIndex = 7;
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
            btnCerrar.Location = new Point(980, 555);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 35);
            btnCerrar.TabIndex = 8;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblEstadoOperacion
            // 
            lblEstadoOperacion.AutoSize = true;
            lblEstadoOperacion.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblEstadoOperacion.ForeColor = Color.FromArgb(52, 73, 94);
            lblEstadoOperacion.Location = new Point(20, 590);
            lblEstadoOperacion.Name = "lblEstadoOperacion";
            lblEstadoOperacion.Size = new Size(157, 15);
            lblEstadoOperacion.TabIndex = 9;
            lblEstadoOperacion.Text = "Seleccione un libro de la lista";
            // 
            // FormGestionLibros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 615);
            Controls.Add(lblEstadoOperacion);
            Controls.Add(btnCerrar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(btnNuevo);
            Controls.Add(groupBoxDatos);
            Controls.Add(dgvLibros);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormGestionLibros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Libros - Sistema Biblioteca";
            Load += FormGestionLibros_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            groupBoxDatos.ResumeLayout(false);
            groupBoxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.Label lblIdLibro;
        private System.Windows.Forms.TextBox txtIdLibro;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblFechaPublicacion;
        private System.Windows.Forms.DateTimePicker dtpFechaPublicacion;
        private System.Windows.Forms.Label lblSinopsis;
        private System.Windows.Forms.TextBox txtSinopsis;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblEstadoOperacion;
    }
}