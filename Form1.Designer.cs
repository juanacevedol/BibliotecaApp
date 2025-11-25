namespace BibliotecaApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvDatos = new DataGridView();
            btnCargar = new Button();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            cmbTablas = new ComboBox();
            lblEstado = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.BackgroundColor = Color.Snow;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(360, 93);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Size = new Size(506, 342);
            dgvDatos.TabIndex = 0;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(385, 471);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(96, 32);
            btnCargar.TabIndex = 1;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnGuardar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(520, 471);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(81, 32);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(641, 471);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(87, 32);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(767, 471);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(86, 32);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // cmbTablas
            // 
            cmbTablas.FormattingEnabled = true;
            cmbTablas.Location = new Point(23, 129);
            cmbTablas.Name = "cmbTablas";
            cmbTablas.Size = new Size(204, 23);
            cmbTablas.TabIndex = 5;
            cmbTablas.SelectedIndexChanged += cmbTablas_SelectedIndexChanged;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(23, 93);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(40, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(448, 32);
            label1.Name = "label1";
            label1.Size = new Size(319, 30);
            label1.TabIndex = 7;
            label1.Text = "Prueba conexion base de datos";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(911, 564);
            Controls.Add(label1);
            Controls.Add(lblEstado);
            Controls.Add(cmbTablas);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(btnCargar);
            Controls.Add(dgvDatos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDatos;
        private Button btnCargar;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private ComboBox cmbTablas;
        private Label lblEstado;
        private Label label1;
    }
}
