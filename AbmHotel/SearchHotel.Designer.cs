﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    partial class SearchHotel
    {
        private TextBox nombreText;
        private Label nombreLabel;

        private Label estrellasLabel;
        private ComboBox estrellasComboBox;
        private Label ciudadLabel;
        private TextBox ciudadText;
        private Label paisLabel;
        private TextBox paisText;

        private GroupBox groupBox1;
        private Button buscarHotel;

        private DataGrid registroHoteles;
        private Button buttonBbuscarHoteles;


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
            this.nombreText = new System.Windows.Forms.TextBox();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.estrellasLabel = new System.Windows.Forms.Label();
            this.buttonBbuscarHoteles = new System.Windows.Forms.Button();
            this.estrellasComboBox = new System.Windows.Forms.ComboBox();
            this.ciudadLabel = new System.Windows.Forms.Label();
            this.ciudadText = new System.Windows.Forms.TextBox();
            this.paisLabel = new System.Windows.Forms.Label();
            this.paisText = new System.Windows.Forms.TextBox();
            this.buscarHotel = new System.Windows.Forms.Button();
            this.registroHoteles = new System.Windows.Forms.DataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registroHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(86, 38);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(100, 20);
            this.nombreText.TabIndex = 0;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(22, 41);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(44, 13);
            this.nombreLabel.TabIndex = 1;
            this.nombreLabel.Text = "Nombre";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.estrellasLabel);
            this.groupBox1.Controls.Add(this.buttonBbuscarHoteles);
            this.groupBox1.Controls.Add(this.estrellasComboBox);
            this.groupBox1.Controls.Add(this.ciudadLabel);
            this.groupBox1.Controls.Add(this.ciudadText);
            this.groupBox1.Controls.Add(this.paisLabel);
            this.groupBox1.Controls.Add(this.paisText);
            this.groupBox1.Controls.Add(this.nombreLabel);
            this.groupBox1.Controls.Add(this.nombreText);
            this.groupBox1.Controls.Add(this.buscarHotel);
            this.groupBox1.Controls.Add(this.registroHoteles);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 524);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Hotel";
            // 
            // estrellasLabel
            // 
            this.estrellasLabel.AutoSize = true;
            this.estrellasLabel.Location = new System.Drawing.Point(358, 41);
            this.estrellasLabel.Name = "estrellasLabel";
            this.estrellasLabel.Size = new System.Drawing.Size(49, 13);
            this.estrellasLabel.TabIndex = 11;
            this.estrellasLabel.Text = "Estrellas:";
            // 
            // buttonBbuscarHoteles
            // 
            this.buttonBbuscarHoteles.Location = new System.Drawing.Point(201, 484);
            this.buttonBbuscarHoteles.Name = "buttonBbuscarHoteles";
            this.buttonBbuscarHoteles.Size = new System.Drawing.Size(161, 23);
            this.buttonBbuscarHoteles.TabIndex = 0;
            this.buttonBbuscarHoteles.Text = "Buscar";
            this.buttonBbuscarHoteles.Click += new System.EventHandler(this.button_buscarHoteles);
            // 
            // estrellasComboBox
            // 
            this.estrellasComboBox.Items.AddRange(new object[] {
            1,
            2,
            3,
            4,
            5});
            this.estrellasComboBox.Location = new System.Drawing.Point(421, 38);
            this.estrellasComboBox.Name = "estrellasComboBox";
            this.estrellasComboBox.Size = new System.Drawing.Size(117, 21);
            this.estrellasComboBox.TabIndex = 10;
            // 
            // ciudadLabel
            // 
            this.ciudadLabel.AutoSize = true;
            this.ciudadLabel.Location = new System.Drawing.Point(358, 111);
            this.ciudadLabel.Name = "ciudadLabel";
            this.ciudadLabel.Size = new System.Drawing.Size(43, 13);
            this.ciudadLabel.TabIndex = 9;
            this.ciudadLabel.Text = "Ciudad:";
            // 
            // ciudadText
            // 
            this.ciudadText.Location = new System.Drawing.Point(421, 108);
            this.ciudadText.Name = "ciudadText";
            this.ciudadText.Size = new System.Drawing.Size(117, 20);
            this.ciudadText.TabIndex = 8;
            // 
            // paisLabel
            // 
            this.paisLabel.AutoSize = true;
            this.paisLabel.Location = new System.Drawing.Point(23, 108);
            this.paisLabel.Name = "paisLabel";
            this.paisLabel.Size = new System.Drawing.Size(30, 13);
            this.paisLabel.TabIndex = 7;
            this.paisLabel.Text = "Pais:";
            // 
            // paisText
            // 
            this.paisText.Location = new System.Drawing.Point(86, 105);
            this.paisText.Name = "paisText";
            this.paisText.Size = new System.Drawing.Size(117, 20);
            this.paisText.TabIndex = 6;
            // 
            // buscarHotel
            // 
            this.buscarHotel.Location = new System.Drawing.Point(201, 156);
            this.buscarHotel.Name = "buscarHotel";
            this.buscarHotel.Size = new System.Drawing.Size(161, 23);
            this.buscarHotel.TabIndex = 0;
            this.buscarHotel.Text = "Buscar";
            // 
            // registroHoteles
            // 
            this.registroHoteles.DataMember = "";
            this.registroHoteles.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.registroHoteles.Location = new System.Drawing.Point(26, 203);
            this.registroHoteles.Name = "registroHoteles";
            this.registroHoteles.Size = new System.Drawing.Size(513, 257);
            this.registroHoteles.TabIndex = 0;
            // 
            // SearchHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 561);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchHotel";
            this.Text = "Busqueda de Hoteles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registroHoteles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


    }
}
