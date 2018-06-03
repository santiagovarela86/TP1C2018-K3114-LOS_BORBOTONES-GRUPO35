namespace FrbaHotel
{
    partial class FuncionesAdicionales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ABMUsuario = new System.Windows.Forms.Button();
            this.ABMCliente = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ABMRol = new System.Windows.Forms.Button();
            this.ABMHotel = new System.Windows.Forms.Button();
            this.ABMHabitacion = new System.Windows.Forms.Button();
            this.RegistrarEstadía = new System.Windows.Forms.Button();
            this.RegistrarConsumible = new System.Windows.Forms.Button();
            this.FacturarEstadía = new System.Windows.Forms.Button();
            this.GenerarListadoEstadístico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ABMUsuario
            // 
            this.ABMUsuario.Location = new System.Drawing.Point(138, 12);
            this.ABMUsuario.Name = "ABMUsuario";
            this.ABMUsuario.Size = new System.Drawing.Size(120, 41);
            this.ABMUsuario.TabIndex = 1;
            this.ABMUsuario.Text = "ABM Usuario";
            this.ABMUsuario.UseVisualStyleBackColor = true;
            // 
            // ABMCliente
            // 
            this.ABMCliente.Location = new System.Drawing.Point(264, 12);
            this.ABMCliente.Name = "ABMCliente";
            this.ABMCliente.Size = new System.Drawing.Size(120, 41);
            this.ABMCliente.TabIndex = 2;
            this.ABMCliente.Text = "ABM Clientes";
            this.ABMCliente.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(264, 106);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 41);
            this.button4.TabIndex = 9;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ABMRol
            // 
            this.ABMRol.Location = new System.Drawing.Point(12, 12);
            this.ABMRol.Name = "ABMRol";
            this.ABMRol.Size = new System.Drawing.Size(120, 41);
            this.ABMRol.TabIndex = 0;
            this.ABMRol.Text = "ABM Rol";
            this.ABMRol.UseVisualStyleBackColor = true;
            // 
            // ABMHotel
            // 
            this.ABMHotel.Location = new System.Drawing.Point(390, 12);
            this.ABMHotel.Name = "ABMHotel";
            this.ABMHotel.Size = new System.Drawing.Size(120, 41);
            this.ABMHotel.TabIndex = 3;
            this.ABMHotel.Text = "ABM Hotel";
            this.ABMHotel.UseVisualStyleBackColor = true;
            // 
            // ABMHabitacion
            // 
            this.ABMHabitacion.Location = new System.Drawing.Point(516, 12);
            this.ABMHabitacion.Name = "ABMHabitacion";
            this.ABMHabitacion.Size = new System.Drawing.Size(120, 41);
            this.ABMHabitacion.TabIndex = 4;
            this.ABMHabitacion.Text = "ABM Habitacion";
            this.ABMHabitacion.UseVisualStyleBackColor = true;
            // 
            // RegistrarEstadía
            // 
            this.RegistrarEstadía.Location = new System.Drawing.Point(73, 59);
            this.RegistrarEstadía.Name = "RegistrarEstadía";
            this.RegistrarEstadía.Size = new System.Drawing.Size(120, 41);
            this.RegistrarEstadía.TabIndex = 5;
            this.RegistrarEstadía.Text = "Registrar Estadía";
            this.RegistrarEstadía.UseVisualStyleBackColor = true;
            // 
            // RegistrarConsumible
            // 
            this.RegistrarConsumible.Location = new System.Drawing.Point(199, 59);
            this.RegistrarConsumible.Name = "RegistrarConsumible";
            this.RegistrarConsumible.Size = new System.Drawing.Size(120, 41);
            this.RegistrarConsumible.TabIndex = 6;
            this.RegistrarConsumible.Text = "Registrar Consumibles";
            this.RegistrarConsumible.UseVisualStyleBackColor = true;
            // 
            // FacturarEstadía
            // 
            this.FacturarEstadía.Location = new System.Drawing.Point(325, 59);
            this.FacturarEstadía.Name = "FacturarEstadía";
            this.FacturarEstadía.Size = new System.Drawing.Size(120, 41);
            this.FacturarEstadía.TabIndex = 7;
            this.FacturarEstadía.Text = "Facturar Estadía";
            this.FacturarEstadía.UseVisualStyleBackColor = true;
            // 
            // GenerarListadoEstadístico
            // 
            this.GenerarListadoEstadístico.Location = new System.Drawing.Point(450, 59);
            this.GenerarListadoEstadístico.Name = "GenerarListadoEstadístico";
            this.GenerarListadoEstadístico.Size = new System.Drawing.Size(120, 41);
            this.GenerarListadoEstadístico.TabIndex = 8;
            this.GenerarListadoEstadístico.Text = "Listado Estadístico";
            this.GenerarListadoEstadístico.UseVisualStyleBackColor = true;
            // 
            // FuncionesAdicionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 154);
            this.Controls.Add(this.GenerarListadoEstadístico);
            this.Controls.Add(this.FacturarEstadía);
            this.Controls.Add(this.RegistrarConsumible);
            this.Controls.Add(this.RegistrarEstadía);
            this.Controls.Add(this.ABMHabitacion);
            this.Controls.Add(this.ABMHotel);
            this.Controls.Add(this.ABMRol);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ABMCliente);
            this.Controls.Add(this.ABMUsuario);
            this.Name = "FuncionesAdicionales";
            this.Text = "Gestión de Datos TP 2018 1C - LOS_BORBOTONES - FUNCIONES ADICIONALES";
            this.Load += new System.EventHandler(this.FuncionesAdicionales_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ABMUsuario;
        private System.Windows.Forms.Button ABMCliente;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button ABMRol;
        private System.Windows.Forms.Button ABMHotel;
        private System.Windows.Forms.Button ABMHabitacion;
        private System.Windows.Forms.Button RegistrarEstadía;
        private System.Windows.Forms.Button RegistrarConsumible;
        private System.Windows.Forms.Button FacturarEstadía;
        private System.Windows.Forms.Button GenerarListadoEstadístico;
    }
}