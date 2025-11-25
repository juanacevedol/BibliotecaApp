namespace BibliotecaApp
{
    partial class FormRecomendaciones
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
            lblSubtitulo = new Label();
            lblUsuarioActual = new Label();
            panelContenido = new Panel();
            dgvRecomendaciones = new DataGridView();
            panelAcciones = new Panel();
            btnActualizar = new Button();
            btnCerrar = new Button();
            lblInfo = new Label();
            panelHeader.SuspendLayout();
            panelContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecomendaciones).BeginInit();
            panelAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(121, 85, 72);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblSubtitulo);
            panelHeader.Controls.Add(lblUsuarioActual);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 90);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(30, 50);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(386, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "📚 Recomendaciones para Ti";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.FromArgb(230, 230, 230);
            lblSubtitulo.Location = new Point(0, 0);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(322, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Libros seleccionados especialmente para tus gustos";
            // 
            // lblUsuarioActual
            // 
            lblUsuarioActual.AutoSize = true;
            lblUsuarioActual.Font = new Font("Segoe UI", 10F);
            lblUsuarioActual.ForeColor = Color.White;
            lblUsuarioActual.Location = new Point(790, 35);
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(107, 19);
            lblUsuarioActual.TabIndex = 2;
            lblUsuarioActual.Text = "Usuario: [Name]";
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(dgvRecomendaciones);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 90);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(20);
            panelContenido.Size = new Size(1000, 450);
            panelContenido.TabIndex = 1;
            // 
            // dgvRecomendaciones
            // 
            dgvRecomendaciones.AllowUserToAddRows = false;
            dgvRecomendaciones.AllowUserToDeleteRows = false;
            dgvRecomendaciones.BackgroundColor = Color.Tan;
            dgvRecomendaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecomendaciones.Dock = DockStyle.Fill;
            dgvRecomendaciones.Location = new Point(20, 20);
            dgvRecomendaciones.MultiSelect = false;
            dgvRecomendaciones.Name = "dgvRecomendaciones";
            dgvRecomendaciones.ReadOnly = true;
            dgvRecomendaciones.RowHeadersWidth = 51;
            dgvRecomendaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecomendaciones.Size = new Size(960, 410);
            dgvRecomendaciones.TabIndex = 0;
            dgvRecomendaciones.SelectionChanged += dgvRecomendaciones_SelectionChanged;
            // 
            // panelAcciones
            // 
            panelAcciones.BackColor = Color.FromArgb(236, 240, 241);
            panelAcciones.Controls.Add(btnActualizar);
            panelAcciones.Controls.Add(btnCerrar);
            panelAcciones.Controls.Add(lblInfo);
            panelAcciones.Dock = DockStyle.Bottom;
            panelAcciones.Location = new Point(0, 540);
            panelAcciones.Name = "panelAcciones";
            panelAcciones.Size = new Size(1000, 80);
            panelAcciones.TabIndex = 2;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(52, 152, 219);
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.Location = new Point(760, 20);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 40);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(127, 140, 141);
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(880, 20);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(100, 40);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(52, 73, 94);
            lblInfo.Location = new Point(30, 32);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(180, 19);
            lblInfo.TabIndex = 4;
            lblInfo.Text = "Total recomendaciones: 0";
            // 
            // FormRecomendaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 620);
            Controls.Add(panelContenido);
            Controls.Add(panelAcciones);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormRecomendaciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recomendaciones de Libros - Sistema Biblioteca";
            Load += FormRecomendaciones_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecomendaciones).EndInit();
            panelAcciones.ResumeLayout(false);
            panelAcciones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.DataGridView dgvRecomendaciones;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblInfo;
    }
}