namespace FrbaHotel.AbmHabitacion
{
    partial class BajaHabitacion
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
            this.checkBoxActiva = new System.Windows.Forms.CheckBox();
            this.buttonCrearHabitacion = new System.Windows.Forms.Button();
            this.labelTipoHabitacion = new System.Windows.Forms.Label();
            this.comboBoxHabitacion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkBoxActiva
            // 
            this.checkBoxActiva.AutoSize = true;
            this.checkBoxActiva.Location = new System.Drawing.Point(29, 71);
            this.checkBoxActiva.Name = "checkBoxActiva";
            this.checkBoxActiva.Size = new System.Drawing.Size(59, 17);
            this.checkBoxActiva.TabIndex = 24;
            this.checkBoxActiva.Text = "Activar";
            this.checkBoxActiva.UseVisualStyleBackColor = true;
            // 
            // buttonCrearHabitacion
            // 
            this.buttonCrearHabitacion.Location = new System.Drawing.Point(77, 131);
            this.buttonCrearHabitacion.Name = "buttonCrearHabitacion";
            this.buttonCrearHabitacion.Size = new System.Drawing.Size(130, 23);
            this.buttonCrearHabitacion.TabIndex = 23;
            this.buttonCrearHabitacion.Text = "Activar/Desactivar Habitacion";
            this.buttonCrearHabitacion.UseVisualStyleBackColor = true;
            this.buttonCrearHabitacion.Click += new System.EventHandler(this.buttonActivarDesactivarHabitacion_Click);
            // 
            // labelTipoHabitacion
            // 
            this.labelTipoHabitacion.AutoSize = true;
            this.labelTipoHabitacion.Location = new System.Drawing.Point(26, 34);
            this.labelTipoHabitacion.Name = "labelTipoHabitacion";
            this.labelTipoHabitacion.Size = new System.Drawing.Size(37, 13);
            this.labelTipoHabitacion.TabIndex = 22;
            this.labelTipoHabitacion.Text = "Tipo : ";
            // 
            // comboBoxHabitacion
            // 
            this.comboBoxHabitacion.Location = new System.Drawing.Point(77, 28);
            this.comboBoxHabitacion.Name = "comboBoxHabitacion";
            this.comboBoxHabitacion.Size = new System.Drawing.Size(195, 21);
            this.comboBoxHabitacion.TabIndex = 21;
            // 
            // BajaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkBoxActiva);
            this.Controls.Add(this.buttonCrearHabitacion);
            this.Controls.Add(this.labelTipoHabitacion);
            this.Controls.Add(this.comboBoxHabitacion);
            this.Name = "BajaHabitacion";
            this.Text = "BajaHabitacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxActiva;
        private System.Windows.Forms.Button buttonCrearHabitacion;
        private System.Windows.Forms.Label labelTipoHabitacion;
        private System.Windows.Forms.ComboBox comboBoxHabitacion;
    }
}