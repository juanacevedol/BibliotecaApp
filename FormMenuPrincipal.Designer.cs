namespace BibliotecaApp
{
    partial class FormMenuPrincipal
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
            lblBienvenida = new Label();
            lblRol = new Label();
            btnCerrarSesion = new Button();
            panelMenu = new Panel();
            btnPrestamo = new Button();
            btnDevolucion = new Button();
            btnGestionLibros = new Button();
            btnGestionUsuarios = new Button();
            btnVerLogs = new Button();
            panelHeader.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(121, 85, 72);
            panelHeader.Controls.Add(lblBienvenida);
            panelHeader.Controls.Add(lblRol);
            panelHeader.Controls.Add(btnCerrarSesion);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(20, 15);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(235, 30);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido, [Usuario]";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 10F);
            lblRol.ForeColor = Color.FromArgb(189, 195, 199);
            lblRol.Location = new Point(25, 50);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(62, 19);
            lblRol.TabIndex = 1;
            lblRol.Text = "Rol: [Rol]";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(231, 76, 60);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(640, 20);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(140, 40);
            btnCerrarSesion.TabIndex = 2;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(236, 240, 241);
            panelMenu.Controls.Add(btnPrestamo);
            panelMenu.Controls.Add(btnDevolucion);
            panelMenu.Controls.Add(btnGestionLibros);
            panelMenu.Controls.Add(btnGestionUsuarios);
            panelMenu.Controls.Add(btnVerLogs);
            panelMenu.Dock = DockStyle.Fill;
            panelMenu.Location = new Point(0, 80);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(800, 470);
            panelMenu.TabIndex = 1;
            // 
            // btnPrestamo
            // 
            btnPrestamo.BackColor = Color.FromArgb(52, 152, 219);
            btnPrestamo.FlatAppearance.BorderSize = 0;
            btnPrestamo.FlatStyle = FlatStyle.Flat;
            btnPrestamo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPrestamo.ForeColor = Color.White;
            btnPrestamo.Location = new Point(100, 50);
            btnPrestamo.Name = "btnPrestamo";
            btnPrestamo.Size = new Size(250, 70);
            btnPrestamo.TabIndex = 0;
            btnPrestamo.Text = "📚 PRÉSTAMO DE LIBROS";
            btnPrestamo.UseVisualStyleBackColor = false;
            btnPrestamo.Click += btnPrestamo_Click;
            // 
            // btnDevolucion
            // 
            btnDevolucion.BackColor = Color.FromArgb(46, 204, 113);
            btnDevolucion.FlatAppearance.BorderSize = 0;
            btnDevolucion.FlatStyle = FlatStyle.Flat;
            btnDevolucion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDevolucion.ForeColor = Color.White;
            btnDevolucion.Location = new Point(450, 50);
            btnDevolucion.Name = "btnDevolucion";
            btnDevolucion.Size = new Size(250, 70);
            btnDevolucion.TabIndex = 1;
            btnDevolucion.Text = "📖 DEVOLUCIÓN DE LIBROS";
            btnDevolucion.UseVisualStyleBackColor = false;
            btnDevolucion.Click += btnDevolucion_Click;
            // 
            // btnGestionLibros
            // 
            btnGestionLibros.BackColor = Color.FromArgb(155, 89, 182);
            btnGestionLibros.FlatAppearance.BorderSize = 0;
            btnGestionLibros.FlatStyle = FlatStyle.Flat;
            btnGestionLibros.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGestionLibros.ForeColor = Color.White;
            btnGestionLibros.Location = new Point(100, 160);
            btnGestionLibros.Name = "btnGestionLibros";
            btnGestionLibros.Size = new Size(250, 70);
            btnGestionLibros.TabIndex = 2;
            btnGestionLibros.Text = "📚 GESTIÓN DE LIBROS";
            btnGestionLibros.UseVisualStyleBackColor = false;
            btnGestionLibros.Click += btnGestionLibros_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.BackColor = Color.FromArgb(230, 126, 34);
            btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            btnGestionUsuarios.FlatStyle = FlatStyle.Flat;
            btnGestionUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGestionUsuarios.ForeColor = Color.White;
            btnGestionUsuarios.Location = new Point(450, 160);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(250, 70);
            btnGestionUsuarios.TabIndex = 3;
            btnGestionUsuarios.Text = "👥 GESTIÓN DE USUARIOS";
            btnGestionUsuarios.UseVisualStyleBackColor = false;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnVerLogs
            // 
            btnVerLogs.BackColor = Color.FromArgb(52, 73, 94);
            btnVerLogs.FlatAppearance.BorderSize = 0;
            btnVerLogs.FlatStyle = FlatStyle.Flat;
            btnVerLogs.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnVerLogs.ForeColor = Color.White;
            btnVerLogs.Location = new Point(275, 270);
            btnVerLogs.Name = "btnVerLogs";
            btnVerLogs.Size = new Size(250, 70);
            btnVerLogs.TabIndex = 4;
            btnVerLogs.Text = "📋 VER HISTORIAL (LOGS)";
            btnVerLogs.UseVisualStyleBackColor = false;
            btnVerLogs.Click += btnVerLogs_Click;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(panelMenu);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú Principal - Sistema Biblioteca";
            FormClosing += FormMenuPrincipal_FormClosing;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnPrestamo;
        private System.Windows.Forms.Button btnDevolucion;
        private System.Windows.Forms.Button btnGestionLibros;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnVerLogs;
    }
}