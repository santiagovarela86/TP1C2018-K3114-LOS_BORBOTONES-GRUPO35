namespace FrbaHotel.AbmReserva
{
    partial class RecepcionABMReserva
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
            this.buttonModificarReserva = new System.Windows.Forms.Button();
            this.buttonGenerarReserva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.buttonModificarReserva.Location = new System.Drawing.Point(79, 96);
            this.buttonModificarReserva.Name = "button3";
            this.buttonModificarReserva.Size = new System.Drawing.Size(120, 41);
            this.buttonModificarReserva.TabIndex = 3;
            this.buttonModificarReserva.Text = "Editar una reserva...";
            this.buttonModificarReserva.UseVisualStyleBackColor = true;
            this.buttonModificarReserva.Click += new System.EventHandler(this.modificarReserva_click);
            // 
            // buttonGenerarReserva
            // 
            this.buttonGenerarReserva.Location = new System.Drawing.Point(79, 32);
            this.buttonGenerarReserva.Name = "buttonGenerarReserva";
            this.buttonGenerarReserva.Size = new System.Drawing.Size(120, 41);
            this.buttonGenerarReserva.TabIndex = 2;
            this.buttonGenerarReserva.Text = "Reservar...";
            this.buttonGenerarReserva.UseVisualStyleBackColor = true;
            this.buttonGenerarReserva.Click += new System.EventHandler(this.generarReserva_click);
            // 
            // RecepcionABMReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 160);
            this.Controls.Add(this.buttonModificarReserva);
            this.Controls.Add(this.buttonGenerarReserva);
            this.Name = "RecepcionABMReserva";
            this.Text = "RecepcionABMReserva";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonModificarReserva;
        private System.Windows.Forms.Button buttonGenerarReserva;
    }
}