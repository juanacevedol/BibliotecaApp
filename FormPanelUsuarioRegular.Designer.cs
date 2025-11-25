namespace BibliotecaApp
{
    partial class FormPanelUsuarioRegular
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
            btnCerrarSesion = new Button();
            panelBusqueda = new Panel();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            groupBoxFiltros = new GroupBox();
            lblFiltroGenero = new Label();
            cmbFiltroGenero = new ComboBox();
            lblFiltroEstado = new Label();
            cmbFiltroEstado = new ComboBox();
            btnLimpiarFiltros = new Button();
            dgvInventario = new DataGridView();
            panelAcciones = new Panel();
            btnPrestarLibro = new Button();
            btnDevolverLibro = new Button();
            btnRecomendaciones = new Button();
            btnMisPrestamos = new Button();
            lblInfoRegistros = new Label();
            panelHeader.SuspendLayout();
            panelBusqueda.SuspendLayout();
            groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            panelAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(121, 85, 72);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblUsuarioActual);
            panelHeader.Controls.Add(btnCerrarSesion);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1300, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(293, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Biblioteca";
            // 
            // lblUsuarioActual
            // 
            lblUsuarioActual.AutoSize = true;
            lblUsuarioActual.Font = new Font("Segoe UI", 11F);
            lblUsuarioActual.ForeColor = Color.White;
            lblUsuarioActual.Location = new Point(950, 30);
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(116, 20);
            lblUsuarioActual.TabIndex = 1;
            lblUsuarioActual.Text = "Usuario: [Name]";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(1130, 20);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(140, 40);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = Color.White;
            panelBusqueda.Controls.Add(lblBuscar);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Location = new Point(30, 100);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(1240, 69);
            panelBusqueda.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F);
            lblBuscar.ForeColor = Color.Gray;
            lblBuscar.Location = new Point(15, 8);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(49, 19);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 12F);
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Location = new Point(15, 30);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(1210, 29);
            txtBuscar.TabIndex = 1;
            txtBuscar.Text = "🔍 Buscar por nombre...";
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            txtBuscar.Enter += txtBuscar_Enter;
            txtBuscar.Leave += txtBuscar_Leave;
            // 
            // groupBoxFiltros
            // 
            groupBoxFiltros.BackColor = Color.White;
            groupBoxFiltros.Controls.Add(lblFiltroGenero);
            groupBoxFiltros.Controls.Add(cmbFiltroGenero);
            groupBoxFiltros.Controls.Add(lblFiltroEstado);
            groupBoxFiltros.Controls.Add(cmbFiltroEstado);
            groupBoxFiltros.Controls.Add(btnLimpiarFiltros);
            groupBoxFiltros.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFiltros.Location = new Point(30, 175);
            groupBoxFiltros.Name = "groupBoxFiltros";
            groupBoxFiltros.Size = new Size(1240, 90);
            groupBoxFiltros.TabIndex = 2;
            groupBoxFiltros.TabStop = false;
            groupBoxFiltros.Text = "Filtros de Búsqueda";
            // 
            // lblFiltroGenero
            // 
            lblFiltroGenero.AutoSize = true;
            lblFiltroGenero.Font = new Font("Segoe UI", 9F);
            lblFiltroGenero.Location = new Point(20, 30);
            lblFiltroGenero.Name = "lblFiltroGenero";
            lblFiltroGenero.Size = new Size(99, 15);
            lblFiltroGenero.TabIndex = 0;
            lblFiltroGenero.Text = "Filtro por Género:";
            // 
            // cmbFiltroGenero
            // 
            cmbFiltroGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroGenero.Font = new Font("Segoe UI", 9F);
            cmbFiltroGenero.FormattingEnabled = true;
            cmbFiltroGenero.Items.AddRange(new object[] { "Todos", "Ficción", "No Ficción", "Ciencia", "Historia", "Biografía", "Tecnología", "Literatura", "Poesía", "Drama", "Infantil", "Juvenil" });
            cmbFiltroGenero.Location = new Point(20, 50);
            cmbFiltroGenero.Name = "cmbFiltroGenero";
            cmbFiltroGenero.Size = new Size(250, 23);
            cmbFiltroGenero.TabIndex = 1;
            cmbFiltroGenero.SelectedIndexChanged += Filtros_Changed;
            // 
            // lblFiltroEstado
            // 
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Font = new Font("Segoe UI", 9F);
            lblFiltroEstado.Location = new Point(290, 30);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new Size(96, 15);
            lblFiltroEstado.TabIndex = 2;
            lblFiltroEstado.Text = "Filtro por Estado:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.Font = new Font("Segoe UI", 9F);
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Disponible", "Prestado", "No Disponible" });
            cmbFiltroEstado.Location = new Point(290, 50);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(250, 23);
            cmbFiltroEstado.TabIndex = 3;
            cmbFiltroEstado.SelectedIndexChanged += Filtros_Changed;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(149, 165, 166);
            btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = Color.White;
            btnLimpiarFiltros.Location = new Point(1070, 45);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(150, 30);
            btnLimpiarFiltros.TabIndex = 6;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.BackgroundColor = Color.Tan;
            dgvInventario.BorderStyle = BorderStyle.None;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Location = new Point(30, 285);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.RowHeadersWidth = 51;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(1240, 450);
            dgvInventario.TabIndex = 3;
            // 
            // panelAcciones
            // 
            panelAcciones.BackColor = Color.FromArgb(236, 240, 241);
            panelAcciones.Controls.Add(btnPrestarLibro);
            panelAcciones.Controls.Add(btnDevolverLibro);
            panelAcciones.Controls.Add(btnRecomendaciones);
            panelAcciones.Controls.Add(btnMisPrestamos);
            panelAcciones.Controls.Add(lblInfoRegistros);
            panelAcciones.Dock = DockStyle.Bottom;
            panelAcciones.Location = new Point(0, 750);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Size = new Size(1300, 80);
            panelAcciones.TabIndex = 4;
            // 
            // btnPrestarLibro
            // 
            btnPrestarLibro.BackColor = Color.FromArgb(46, 204, 113);
            btnPrestarLibro.FlatAppearance.BorderSize = 0;
            btnPrestarLibro.FlatStyle = FlatStyle.Flat;
            btnPrestarLibro.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrestarLibro.ForeColor = Color.White;
            btnPrestarLibro.Location = new Point(535, 20);
            btnPrestarLibro.Name = "btnPrestarLibro";
            btnPrestarLibro.Size = new Size(150, 45);
            btnPrestarLibro.TabIndex = 0;
            btnPrestarLibro.Text = "📚 Prestar Libro";
            btnPrestarLibro.UseVisualStyleBackColor = false;
            btnPrestarLibro.Click += btnPrestarLibro_Click;
            // 
            // btnDevolverLibro
            // 
            btnDevolverLibro.BackColor = Color.FromArgb(52, 152, 219);
            btnDevolverLibro.FlatAppearance.BorderSize = 0;
            btnDevolverLibro.FlatStyle = FlatStyle.Flat;
            btnDevolverLibro.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDevolverLibro.ForeColor = Color.White;
            btnDevolverLibro.Location = new Point(701, 20);
            btnDevolverLibro.Name = "btnDevolverLibro";
            btnDevolverLibro.Size = new Size(160, 45);
            btnDevolverLibro.TabIndex = 1;
            btnDevolverLibro.Text = "↩️ Devolver Libro";
            btnDevolverLibro.UseVisualStyleBackColor = false;
            btnDevolverLibro.Click += btnDevolverLibro_Click;
            // 
            // btnRecomendaciones
            // 
            btnRecomendaciones.BackColor = Color.FromArgb(230, 126, 34);
            btnRecomendaciones.FlatAppearance.BorderSize = 0;
            btnRecomendaciones.FlatStyle = FlatStyle.Flat;
            btnRecomendaciones.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRecomendaciones.ForeColor = Color.White;
            btnRecomendaciones.Location = new Point(871, 20);
            btnRecomendaciones.Name = "btnRecomendaciones";
            btnRecomendaciones.Size = new Size(195, 45);
            btnRecomendaciones.TabIndex = 2;
            btnRecomendaciones.Text = "💡 Recomendaciones";
            btnRecomendaciones.UseVisualStyleBackColor = false;
            btnRecomendaciones.Click += btnRecomendaciones_Click;
            // 
            // btnMisPrestamos
            // 
            btnMisPrestamos.BackColor = Color.FromArgb(155, 89, 182);
            btnMisPrestamos.FlatAppearance.BorderSize = 0;
            btnMisPrestamos.FlatStyle = FlatStyle.Flat;
            btnMisPrestamos.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMisPrestamos.ForeColor = Color.White;
            btnMisPrestamos.Location = new Point(1072, 20);
            btnMisPrestamos.Name = "btnMisPrestamos";
            btnMisPrestamos.Size = new Size(198, 45);
            btnMisPrestamos.TabIndex = 3;
            btnMisPrestamos.Text = "📋 Mis Préstamos";
            btnMisPrestamos.UseVisualStyleBackColor = false;
            btnMisPrestamos.Click += btnMisPrestamos_Click;
            // 
            // lblInfoRegistros
            // 
            lblInfoRegistros.AutoSize = true;
            lblInfoRegistros.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfoRegistros.ForeColor = Color.FromArgb(52, 73, 94);
            lblInfoRegistros.Location = new Point(30, 32);
            lblInfoRegistros.Name = "lblInfoRegistros";
            lblInfoRegistros.Size = new Size(174, 19);
            lblInfoRegistros.TabIndex = 4;
            lblInfoRegistros.Text = "Libros en el inventario: 0";
            // 
            // FormPanelUsuarioRegular
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1300, 830);
            Controls.Add(panelAcciones);
            Controls.Add(dgvInventario);
            Controls.Add(groupBoxFiltros);
            Controls.Add(panelBusqueda);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormPanelUsuarioRegular";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Biblioteca - Panel de Usuario";
            Load += FormPanelUsuarioRegular_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            groupBoxFiltros.ResumeLayout(false);
            groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label lblFiltroGenero;
        private System.Windows.Forms.ComboBox cmbFiltroGenero;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnPrestarLibro;
        private System.Windows.Forms.Button btnDevolverLibro;
        private System.Windows.Forms.Button btnRecomendaciones; // ← DECLARACIÓN DEL NUEVO BOTÓN
        private System.Windows.Forms.Button btnMisPrestamos;
        private System.Windows.Forms.Label lblInfoRegistros;
    }
}