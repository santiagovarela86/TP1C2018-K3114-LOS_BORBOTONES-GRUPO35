using System;

using System.Windows.Forms;
using System.Drawing;
using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;

namespace FrbaHotel.AbmHotel
{
    public partial class DropHotel
       : Form

    {

        public DropHotel(Hotel hotel)
        {
            InitializeComponent();
            this.hotelBaja = hotel;
        }
        private Hotel hotelBaja;
        private GroupBox groupBox1;
        private MonthCalendar calendarioDesde;
        private MonthCalendar calendarioHasta;
        private Button bajaHotel;
        private Label descripcionBajaLabel;
        private TextBox descripcionBajaText;
        private Label label2;
        private Label label1;


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

        //CIERRO LA VENTANA CON ESCAPE
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.descripcionBajaLabel = new System.Windows.Forms.Label();
            this.descripcionBajaText = new System.Windows.Forms.TextBox();
            this.bajaHotel = new System.Windows.Forms.Button();
            this.calendarioDesde = new System.Windows.Forms.MonthCalendar();
            this.calendarioHasta = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.descripcionBajaLabel);
            this.groupBox1.Controls.Add(this.descripcionBajaText);
            this.groupBox1.Controls.Add(this.bajaHotel);
            this.groupBox1.Controls.Add(this.calendarioDesde);
            this.groupBox1.Controls.Add(this.calendarioHasta);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Baja Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fecha Desde:";
            // 
            // descripcionBajaLabel
            // 
            this.descripcionBajaLabel.AutoSize = true;
            this.descripcionBajaLabel.Location = new System.Drawing.Point(23, 39);
            this.descripcionBajaLabel.Name = "descripcionBajaLabel";
            this.descripcionBajaLabel.Size = new System.Drawing.Size(66, 13);
            this.descripcionBajaLabel.TabIndex = 15;
            this.descripcionBajaLabel.Text = "Descripcion:";
            // 
            // descripcionBajaText
            // 
            this.descripcionBajaText.Location = new System.Drawing.Point(95, 36);
            this.descripcionBajaText.Name = "descripcionBajaText";
            this.descripcionBajaText.Size = new System.Drawing.Size(435, 20);
            this.descripcionBajaText.TabIndex = 14;
            // 
            // bajaHotel
            // 
            this.bajaHotel.Location = new System.Drawing.Point(246, 271);
            this.bajaHotel.Name = "bajaHotel";
            this.bajaHotel.Size = new System.Drawing.Size(75, 23);
            this.bajaHotel.TabIndex = 0;
            this.bajaHotel.Text = "Baja";
            this.bajaHotel.Click += new System.EventHandler(this.bajaHotel_Click);
            // 
            // calendarioDesde
            // 
            this.calendarioDesde.Location = new System.Drawing.Point(26, 97);
            this.calendarioDesde.Name = "calendarioDesde";
            this.calendarioDesde.TabIndex = 12;
            // 
            // calendarioHasta
            // 
            this.calendarioHasta.Location = new System.Drawing.Point(292, 97);
            this.calendarioHasta.Name = "calendarioHasta";
            this.calendarioHasta.TabIndex = 13;
            // 
            // DropHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 334);
            this.Controls.Add(this.groupBox1);
            this.Name = "DropHotel";
            this.Text = "Baja temporal de Hoteles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void bajaHotel_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = calendarioDesde.SelectionStart;
            DateTime fechaHasta = calendarioHasta.SelectionStart;

            if (fechaDesde > fechaHasta)
            {
                MessageBox.Show("La fecha desde no puede ser superior a la fecha hasta", "Gestion de Datos TP 2018 1C - LOS_BORBOTONES");

            }
            else
            {
                CierreTemporal cierreTemporal = new CierreTemporal(0, fechaDesde, fechaHasta, descripcionBajaText.Text, hotelBaja);
                RepositorioHotel repoHotel = new RepositorioHotel();
                repoHotel.crearBajaTemporal(cierreTemporal);
            }
        }



    }

}
