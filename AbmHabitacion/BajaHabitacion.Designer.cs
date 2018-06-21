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
            this.habitacionLabel = new System.Windows.Forms.Label();
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
            this.habitacionLabel.AutoSize = true;
            this.habitacionLabel.Location = new System.Drawing.Point(26, 34);
            this.habitacionLabel.Name = "labelTipoHabitacion";
            this.habitacionLabel.Size = new System.Drawing.Size(37, 13);
            this.habitacionLabel.TabIndex = 22;

            // 
            // BajaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkBoxActiva);
            this.Controls.Add(this.buttonCrearHabitacion);
            this.Controls.Add(this.habitacionLabel);
            this.Name = "BajaHabitacion";
            this.Text = "BajaHabitacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxActiva;
        private System.Windows.Forms.Button buttonCrearHabitacion;
        private System.Windows.Forms.Label habitacionLabel;
    }
}