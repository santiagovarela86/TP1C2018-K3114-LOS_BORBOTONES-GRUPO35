using System.Windows.Forms;
namespace FrbaHotel.AbmHabitacion
{
    partial class ABMHabitacion
    {
        private GroupBox groupBox1;
        private Button buttonCrearHabitacion ;
        private Button buttonModificarHabitacion;
        private Button buttonBajaHabitacion;


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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCrearHabitacion = new System.Windows.Forms.Button();
            this.buttonModificarHabitacion = new System.Windows.Forms.Button();
            this.buttonBajaHabitacion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCrearHabitacion);
            this.groupBox1.Controls.Add(this.buttonModificarHabitacion);
            this.groupBox1.Controls.Add(this.buttonBajaHabitacion);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonCrearHabitacion
            // 
            this.buttonCrearHabitacion.Location = new System.Drawing.Point(54, 46);
            this.buttonCrearHabitacion.Name = "buttonCrearHabitacion";
            this.buttonCrearHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonCrearHabitacion.TabIndex = 0;
            this.buttonCrearHabitacion.Text = "Crear Habitacion";
            this.buttonCrearHabitacion.UseVisualStyleBackColor = true;
            this.buttonCrearHabitacion.Click += new System.EventHandler(this.buttonCrearHabitacion_Click);
            // 
            // buttonModificarHabitacion
            // 
            this.buttonModificarHabitacion.Location = new System.Drawing.Point(179, 46);
            this.buttonModificarHabitacion.Name = "buttonModificarHabitacion";
            this.buttonModificarHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonModificarHabitacion.TabIndex = 1;
            this.buttonModificarHabitacion.Text = "Modificar Habitacion";
            this.buttonModificarHabitacion.UseVisualStyleBackColor = true;
            // 
            // buttonBajaHabitacion
            // 
            this.buttonBajaHabitacion.Location = new System.Drawing.Point(299, 46);
            this.buttonBajaHabitacion.Name = "buttonBajaHabitacion";
            this.buttonBajaHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonBajaHabitacion.TabIndex = 2;
            this.buttonBajaHabitacion.Text = "Baja Habitacion";
            this.buttonBajaHabitacion.UseVisualStyleBackColor = true;
            this.buttonBajaHabitacion.Click += new System.EventHandler(this.buttonBajaHabitacion_Click);
            // 
            // ABMHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 160);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABMHabitacion";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

    }
}