namespace FrbaHotel.AbmHabitacion
{
    partial class CrearHabitacion
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
            this.labelNumero = new System.Windows.Forms.Label();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.labelPiso = new System.Windows.Forms.Label();
            this.textPiso = new System.Windows.Forms.TextBox();
            this.labelHotel = new System.Windows.Forms.Label();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.comboBoxUbicacion = new System.Windows.Forms.ComboBox();
            this.labelTipoHabitacion = new System.Windows.Forms.Label();
            this.comboBoxTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.buttonCrearHabitacion = new System.Windows.Forms.Button();
            this.checkBoxActiva = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(10, 37);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(44, 13);
            this.labelNumero.TabIndex = 3;
            this.labelNumero.Text = "Numero";
            // 
            // textNumero
            // 
            this.textNumero.Location = new System.Drawing.Point(61, 34);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(100, 20);
            this.textNumero.TabIndex = 2;
            // 
            // labelPiso
            // 
            this.labelPiso.AutoSize = true;
            this.labelPiso.Location = new System.Drawing.Point(217, 37);
            this.labelPiso.Name = "labelPiso";
            this.labelPiso.Size = new System.Drawing.Size(27, 13);
            this.labelPiso.TabIndex = 5;
            this.labelPiso.Text = "Piso";
            // 
            // textPiso
            // 
            this.textPiso.Location = new System.Drawing.Point(292, 34);
            this.textPiso.Name = "textPiso";
            this.textPiso.Size = new System.Drawing.Size(100, 20);
            this.textPiso.TabIndex = 4;

            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Location = new System.Drawing.Point(13, 164);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(35, 13);
            this.labelHotel.TabIndex = 13;
            this.labelHotel.Text = "Hotel:";
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.Location = new System.Drawing.Point(61, 161);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(134, 21);
            this.comboBoxHotel.TabIndex = 12;
            // 
            // labelUbicacion
            // 
            this.labelUbicacion.AutoSize = true;
            this.labelUbicacion.Location = new System.Drawing.Point(217, 164);
            this.labelUbicacion.Name = "labelUbicacion";
            this.labelUbicacion.Size = new System.Drawing.Size(58, 13);
            this.labelUbicacion.TabIndex = 15;
            this.labelUbicacion.Text = "Ubicacion:";
            // 
            // comboBoxUbicacion
            // 
            this.comboBoxUbicacion.Location = new System.Drawing.Point(292, 161);
            this.comboBoxUbicacion.Name = "comboBoxUbicacion";
            this.comboBoxUbicacion.Size = new System.Drawing.Size(100, 21);
            this.comboBoxUbicacion.TabIndex = 14;
            // 
            // labelTipoHabitacion
            // 
            this.labelTipoHabitacion.AutoSize = true;
            this.labelTipoHabitacion.Location = new System.Drawing.Point(10, 100);
            this.labelTipoHabitacion.Name = "labelTipoHabitacion";
            this.labelTipoHabitacion.Size = new System.Drawing.Size(37, 13);
            this.labelTipoHabitacion.TabIndex = 17;
            this.labelTipoHabitacion.Text = "Tipo : ";
            // 
            // comboBoxTipoHabitacion
            // 
            this.comboBoxTipoHabitacion.Location = new System.Drawing.Point(61, 94);
            this.comboBoxTipoHabitacion.Name = "comboBoxTipoHabitacion";
            this.comboBoxTipoHabitacion.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTipoHabitacion.TabIndex = 16;
            // 
            // buttonCrearHabitacion
            // 
            this.buttonCrearHabitacion.Location = new System.Drawing.Point(164, 259);
            this.buttonCrearHabitacion.Name = "buttonCrearHabitacion";
            this.buttonCrearHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonCrearHabitacion.TabIndex = 18;
            this.buttonCrearHabitacion.Text = "Crear Habitacion";
            this.buttonCrearHabitacion.UseVisualStyleBackColor = true;
            this.buttonCrearHabitacion.Click += new System.EventHandler(this.buttonCrearHabitacion_Click);
            // 
            // checkBoxActiva
            // 
            this.checkBoxActiva.AutoSize = true;
            this.checkBoxActiva.Location = new System.Drawing.Point(16, 226);
            this.checkBoxActiva.Name = "checkBoxActiva";
            this.checkBoxActiva.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActiva.TabIndex = 19;
            this.checkBoxActiva.Text = "Activa";
            this.checkBoxActiva.UseVisualStyleBackColor = true;
            // 
            // CrearHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 309);
            this.Controls.Add(this.checkBoxActiva);
            this.Controls.Add(this.buttonCrearHabitacion);
            this.Controls.Add(this.labelTipoHabitacion);
            this.Controls.Add(this.comboBoxTipoHabitacion);
            this.Controls.Add(this.labelUbicacion);
            this.Controls.Add(this.comboBoxUbicacion);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.labelPiso);
            this.Controls.Add(this.textPiso);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.textNumero);
            this.Name = "CrearHabitacion";
            this.Text = "CrearHabitacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.Label labelPiso;
        private System.Windows.Forms.TextBox textPiso;
        private System.Windows.Forms.Label labelUbicacion;
        private System.Windows.Forms.ComboBox comboBoxUbicacion;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.Label labelTipoHabitacion;
        private System.Windows.Forms.ComboBox comboBoxTipoHabitacion;
        private System.Windows.Forms.Button buttonCrearHabitacion;
        private System.Windows.Forms.CheckBox checkBoxActiva;


    }
}