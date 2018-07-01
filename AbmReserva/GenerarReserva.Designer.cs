using System;
namespace FrbaHotel.AbmReserva
{
    public partial class GenerarReserva
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buscarHabitacionesButton = new System.Windows.Forms.Button();
            this.labelTipoHabitacion = new System.Windows.Forms.Label();
            this.comboBoxTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.labelHotel = new System.Windows.Forms.Label();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.labelRegimen = new System.Windows.Forms.Label();
            this.comboBoxRegimen = new System.Windows.Forms.ComboBox();
            this.habitacionesDisponiblesGrid = new System.Windows.Forms.DataGridView();
            this.reservarHabitacionButton = new System.Windows.Forms.Button();
            this.regimenesDisponiblesGrid = new System.Windows.Forms.DataGridView();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.calendarioDesde = new System.Windows.Forms.DateTimePicker();
            this.calendarioHasta = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.habitacionesDisponiblesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regimenesDisponiblesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Fecha Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fecha Desde:";
            // 
            // buscarHabitacionesButton
            // 
            this.buscarHabitacionesButton.Location = new System.Drawing.Point(98, 210);
            this.buscarHabitacionesButton.Name = "buscarHabitacionesButton";
            this.buscarHabitacionesButton.Size = new System.Drawing.Size(192, 23);
            this.buscarHabitacionesButton.TabIndex = 18;
            this.buscarHabitacionesButton.Text = "Buscar habitaciones disponibles";
            this.buscarHabitacionesButton.Click += new System.EventHandler(this.buscarHabitaciones_Click);
            // 
            // labelTipoHabitacion
            // 
            this.labelTipoHabitacion.AutoSize = true;
            this.labelTipoHabitacion.Location = new System.Drawing.Point(368, 44);
            this.labelTipoHabitacion.Name = "labelTipoHabitacion";
            this.labelTipoHabitacion.Size = new System.Drawing.Size(37, 13);
            this.labelTipoHabitacion.TabIndex = 24;
            this.labelTipoHabitacion.Text = "Tipo : ";
            // 
            // comboBoxTipoHabitacion
            // 
            this.comboBoxTipoHabitacion.Location = new System.Drawing.Point(419, 38);
            this.comboBoxTipoHabitacion.Name = "comboBoxTipoHabitacion";
            this.comboBoxTipoHabitacion.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTipoHabitacion.TabIndex = 23;
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Location = new System.Drawing.Point(37, 38);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(35, 13);
            this.labelHotel.TabIndex = 31;
            this.labelHotel.Text = "Hotel:";
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.Location = new System.Drawing.Point(85, 35);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(174, 21);
            this.comboBoxHotel.TabIndex = 30;
            this.comboBoxHotel.SelectedValueChanged += new System.EventHandler(this.eventHandlerHotelComboBox);
            // 
            // labelRegimen
            // 
            this.labelRegimen.AutoSize = true;
            this.labelRegimen.Location = new System.Drawing.Point(37, 83);
            this.labelRegimen.Name = "labelRegimen";
            this.labelRegimen.Size = new System.Drawing.Size(52, 13);
            this.labelRegimen.TabIndex = 33;
            this.labelRegimen.Text = "Regimen:";
            // 
            // comboBoxRegimen
            // 
            this.comboBoxRegimen.Location = new System.Drawing.Point(85, 80);
            this.comboBoxRegimen.Name = "comboBoxRegimen";
            this.comboBoxRegimen.Size = new System.Drawing.Size(174, 21);
            this.comboBoxRegimen.TabIndex = 32;
            // 
            // habitacionesDisponiblesGrid
            // 
            this.habitacionesDisponiblesGrid.AllowUserToAddRows = false;
            this.habitacionesDisponiblesGrid.AllowUserToDeleteRows = false;
            this.habitacionesDisponiblesGrid.AllowUserToOrderColumns = true;
            this.habitacionesDisponiblesGrid.AllowUserToResizeRows = false;
            this.habitacionesDisponiblesGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.habitacionesDisponiblesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.habitacionesDisponiblesGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.habitacionesDisponiblesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.habitacionesDisponiblesGrid.Location = new System.Drawing.Point(261, 251);
            this.habitacionesDisponiblesGrid.Name = "habitacionesDisponiblesGrid";
            this.habitacionesDisponiblesGrid.ReadOnly = true;
            this.habitacionesDisponiblesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.habitacionesDisponiblesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.habitacionesDisponiblesGrid.Size = new System.Drawing.Size(452, 194);
            this.habitacionesDisponiblesGrid.TabIndex = 34;
            this.habitacionesDisponiblesGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.habitaciones_cellClick);
            // 
            // reservarHabitacionButton
            // 
            this.reservarHabitacionButton.Enabled = false;
            this.reservarHabitacionButton.Location = new System.Drawing.Point(227, 481);
            this.reservarHabitacionButton.Name = "reservarHabitacionButton";
            this.reservarHabitacionButton.Size = new System.Drawing.Size(192, 23);
            this.reservarHabitacionButton.TabIndex = 35;
            this.reservarHabitacionButton.Text = "Reservar";
            this.reservarHabitacionButton.Click += new System.EventHandler(this.reservarHabitacion);
            // 
            // regimenesDisponiblesGrid
            // 
            this.regimenesDisponiblesGrid.AllowUserToAddRows = false;
            this.regimenesDisponiblesGrid.AllowUserToDeleteRows = false;
            this.regimenesDisponiblesGrid.AllowUserToOrderColumns = true;
            this.regimenesDisponiblesGrid.AllowUserToResizeRows = false;
            this.regimenesDisponiblesGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.regimenesDisponiblesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.regimenesDisponiblesGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.regimenesDisponiblesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.regimenesDisponiblesGrid.Location = new System.Drawing.Point(24, 251);
            this.regimenesDisponiblesGrid.Name = "regimenesDisponiblesGrid";
            this.regimenesDisponiblesGrid.ReadOnly = true;
            this.regimenesDisponiblesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.regimenesDisponiblesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.regimenesDisponiblesGrid.Size = new System.Drawing.Size(143, 194);
            this.regimenesDisponiblesGrid.TabIndex = 36;
            this.regimenesDisponiblesGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.regimenesDisponiblesGrid_CellContentClick);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(355, 210);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(192, 23);
            this.limpiarButton.TabIndex = 37;
            this.limpiarButton.Text = "Limpiar filtros";
            this.limpiarButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // calendarioDesde
            // 
            this.calendarioDesde.Location = new System.Drawing.Point(98, 139);
            this.calendarioDesde.Name = "calendarioDesde";
            this.calendarioDesde.Size = new System.Drawing.Size(200, 20);
            this.calendarioDesde.TabIndex = 39;
            // 
            // calendarioHasta
            // 
            this.calendarioHasta.Location = new System.Drawing.Point(419, 139);
            this.calendarioHasta.Name = "calendarioHasta";
            this.calendarioHasta.Size = new System.Drawing.Size(200, 20);
            this.calendarioHasta.TabIndex = 40;
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 536);
            this.Controls.Add(this.calendarioHasta);
            this.Controls.Add(this.calendarioDesde);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.regimenesDisponiblesGrid);
            this.Controls.Add(this.reservarHabitacionButton);
            this.Controls.Add(this.habitacionesDisponiblesGrid);
            this.Controls.Add(this.labelRegimen);
            this.Controls.Add(this.comboBoxRegimen);
            this.Controls.Add(this.labelHotel);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.labelTipoHabitacion);
            this.Controls.Add(this.comboBoxTipoHabitacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buscarHabitacionesButton);
            this.Name = "GenerarReserva";
            this.Text = "GenerarReserva";
            ((System.ComponentModel.ISupportInitialize)(this.habitacionesDisponiblesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regimenesDisponiblesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buscarHabitacionesButton;
        private System.Windows.Forms.Label labelTipoHabitacion;
        private System.Windows.Forms.ComboBox comboBoxTipoHabitacion;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.Label labelRegimen;
        private System.Windows.Forms.ComboBox comboBoxRegimen;
        private System.Windows.Forms.DataGridView habitacionesDisponiblesGrid;
        private System.Windows.Forms.Button reservarHabitacionButton;
        private System.Windows.Forms.DataGridView regimenesDisponiblesGrid;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.DateTimePicker calendarioDesde;
        private System.Windows.Forms.DateTimePicker calendarioHasta;
    }
}