﻿namespace FrbaHotel.AbmReserva
{
    partial class CancelarReserva
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
            this.labelMotivo = new System.Windows.Forms.Label();
            this.textMotivo = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMotivo
            // 
            this.labelMotivo.AutoSize = true;
            this.labelMotivo.Location = new System.Drawing.Point(120, 22);
            this.labelMotivo.Name = "labelMotivo";
            this.labelMotivo.Size = new System.Drawing.Size(42, 13);
            this.labelMotivo.TabIndex = 8;
            this.labelMotivo.Text = "Motivo:";
            // 
            // textMotivo
            // 
            this.textMotivo.Location = new System.Drawing.Point(21, 49);
            this.textMotivo.Multiline = true;
            this.textMotivo.Name = "textMotivo";
            this.textMotivo.Size = new System.Drawing.Size(238, 183);
            this.textMotivo.TabIndex = 9;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(102, 252);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 13;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // CancelarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 300);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelMotivo);
            this.Controls.Add(this.textMotivo);
            this.Name = "CancelarReserva";
            this.Text = "CancelarReserva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMotivo;
        private System.Windows.Forms.TextBox textMotivo;
        private System.Windows.Forms.Button buttonCancelar;
    }
}