namespace FrbaHotel.AbmReserva
{
    partial class ModificarReserva
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupRegimenesDelHotel = new System.Windows.Forms.GroupBox();
            this.regimenesDisponiblesGrid = new System.Windows.Forms.DataGridView();
            this.groupHabitacionesDisponibles = new System.Windows.Forms.GroupBox();
            this.habitacionesDisponiblesGrid = new System.Windows.Forms.DataGridView();
            this.calendarioHasta = new System.Windows.Forms.DateTimePicker();
            this.calendarioDesde = new System.Windows.Forms.DateTimePicker();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.labelRegimen = new System.Windows.Forms.Label();
            this.comboBoxRegimen = new System.Windows.Forms.ComboBox();
            this.labelHotel = new System.Windows.Forms.Label();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.labelTipoHabitacion = new System.Windows.Forms.Label();
            this.comboBoxTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buscarHabitacionesButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRegimenActual = new System.Windows.Forms.Label();
            this.labelHotelActual = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonModificarReserva = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupRegimenesDelHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regimenesDisponiblesGrid)).BeginInit();
            this.groupHabitacionesDisponibles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.habitacionesDisponiblesGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupRegimenesDelHotel);
            this.groupBox3.Controls.Add(this.groupHabitacionesDisponibles);
            this.groupBox3.Controls.Add(this.calendarioHasta);
            this.groupBox3.Controls.Add(this.calendarioDesde);
            this.groupBox3.Controls.Add(this.limpiarButton);
            this.groupBox3.Controls.Add(this.labelRegimen);
            this.groupBox3.Controls.Add(this.comboBoxRegimen);
            this.groupBox3.Controls.Add(this.labelHotel);
            this.groupBox3.Controls.Add(this.comboBoxHotel);
            this.groupBox3.Controls.Add(this.labelTipoHabitacion);
            this.groupBox3.Controls.Add(this.comboBoxTipoHabitacion);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.buscarHabitacionesButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(849, 489);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modificar reserva";
            // 
            // groupRegimenesDelHotel
            // 
            this.groupRegimenesDelHotel.Controls.Add(this.regimenesDisponiblesGrid);
            this.groupRegimenesDelHotel.Location = new System.Drawing.Point(15, 247);
            this.groupRegimenesDelHotel.Name = "groupRegimenesDelHotel";
            this.groupRegimenesDelHotel.Size = new System.Drawing.Size(232, 198);
            this.groupRegimenesDelHotel.TabIndex = 70;
            this.groupRegimenesDelHotel.TabStop = false;
            this.groupRegimenesDelHotel.Text = "Regimenes del hotel";
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
            this.regimenesDisponiblesGrid.Location = new System.Drawing.Point(12, 19);
            this.regimenesDisponiblesGrid.Name = "regimenesDisponiblesGrid";
            this.regimenesDisponiblesGrid.ReadOnly = true;
            this.regimenesDisponiblesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.regimenesDisponiblesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.regimenesDisponiblesGrid.Size = new System.Drawing.Size(207, 170);
            this.regimenesDisponiblesGrid.TabIndex = 36;
            // 
            // groupHabitacionesDisponibles
            // 
            this.groupHabitacionesDisponibles.Controls.Add(this.habitacionesDisponiblesGrid);
            this.groupHabitacionesDisponibles.Location = new System.Drawing.Point(253, 247);
            this.groupHabitacionesDisponibles.Name = "groupHabitacionesDisponibles";
            this.groupHabitacionesDisponibles.Size = new System.Drawing.Size(463, 203);
            this.groupHabitacionesDisponibles.TabIndex = 69;
            this.groupHabitacionesDisponibles.TabStop = false;
            this.groupHabitacionesDisponibles.Text = "Habitaciones disponibles";
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
            this.habitacionesDisponiblesGrid.Location = new System.Drawing.Point(6, 19);
            this.habitacionesDisponiblesGrid.Name = "habitacionesDisponiblesGrid";
            this.habitacionesDisponiblesGrid.ReadOnly = true;
            this.habitacionesDisponiblesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.habitacionesDisponiblesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.habitacionesDisponiblesGrid.Size = new System.Drawing.Size(451, 175);
            this.habitacionesDisponiblesGrid.TabIndex = 34;
            // 
            // calendarioHasta
            // 
            this.calendarioHasta.Location = new System.Drawing.Point(422, 135);
            this.calendarioHasta.Name = "calendarioHasta";
            this.calendarioHasta.Size = new System.Drawing.Size(200, 20);
            this.calendarioHasta.TabIndex = 68;
            // 
            // calendarioDesde
            // 
            this.calendarioDesde.Location = new System.Drawing.Point(101, 135);
            this.calendarioDesde.Name = "calendarioDesde";
            this.calendarioDesde.Size = new System.Drawing.Size(200, 20);
            this.calendarioDesde.TabIndex = 67;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(358, 206);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(192, 23);
            this.limpiarButton.TabIndex = 66;
            this.limpiarButton.Text = "Limpiar filtros";
            // 
            // labelRegimen
            // 
            this.labelRegimen.AutoSize = true;
            this.labelRegimen.Location = new System.Drawing.Point(40, 79);
            this.labelRegimen.Name = "labelRegimen";
            this.labelRegimen.Size = new System.Drawing.Size(52, 13);
            this.labelRegimen.TabIndex = 65;
            this.labelRegimen.Text = "Regimen:";
            // 
            // comboBoxRegimen
            // 
            this.comboBoxRegimen.Location = new System.Drawing.Point(88, 76);
            this.comboBoxRegimen.Name = "comboBoxRegimen";
            this.comboBoxRegimen.Size = new System.Drawing.Size(174, 21);
            this.comboBoxRegimen.TabIndex = 64;
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Location = new System.Drawing.Point(40, 34);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(35, 13);
            this.labelHotel.TabIndex = 63;
            this.labelHotel.Text = "Hotel:";
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.Location = new System.Drawing.Point(88, 31);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(174, 21);
            this.comboBoxHotel.TabIndex = 62;
            // 
            // labelTipoHabitacion
            // 
            this.labelTipoHabitacion.AutoSize = true;
            this.labelTipoHabitacion.Location = new System.Drawing.Point(371, 40);
            this.labelTipoHabitacion.Name = "labelTipoHabitacion";
            this.labelTipoHabitacion.Size = new System.Drawing.Size(37, 13);
            this.labelTipoHabitacion.TabIndex = 61;
            this.labelTipoHabitacion.Text = "Tipo : ";
            // 
            // comboBoxTipoHabitacion
            // 
            this.comboBoxTipoHabitacion.Location = new System.Drawing.Point(422, 34);
            this.comboBoxTipoHabitacion.Name = "comboBoxTipoHabitacion";
            this.comboBoxTipoHabitacion.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTipoHabitacion.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Fecha Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Fecha Desde:";
            // 
            // buscarHabitacionesButton
            // 
            this.buscarHabitacionesButton.Location = new System.Drawing.Point(101, 206);
            this.buscarHabitacionesButton.Name = "buscarHabitacionesButton";
            this.buscarHabitacionesButton.Size = new System.Drawing.Size(192, 23);
            this.buscarHabitacionesButton.TabIndex = 57;
            this.buscarHabitacionesButton.Text = "Buscar habitaciones disponibles";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelRegimenActual);
            this.groupBox1.Controls.Add(this.labelHotelActual);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(868, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 489);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserva Actual";
            // 
            // labelRegimenActual
            // 
            this.labelRegimenActual.AutoSize = true;
            this.labelRegimenActual.Location = new System.Drawing.Point(50, 76);
            this.labelRegimenActual.Name = "labelRegimenActual";
            this.labelRegimenActual.Size = new System.Drawing.Size(52, 13);
            this.labelRegimenActual.TabIndex = 65;
            this.labelRegimenActual.Text = "Regimen:";
            // 
            // labelHotelActual
            // 
            this.labelHotelActual.AutoSize = true;
            this.labelHotelActual.Location = new System.Drawing.Point(50, 34);
            this.labelHotelActual.Name = "labelHotelActual";
            this.labelHotelActual.Size = new System.Drawing.Size(35, 13);
            this.labelHotelActual.TabIndex = 64;
            this.labelHotelActual.Text = "Hotel:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(291, 174);
            this.dataGridView1.TabIndex = 35;
            // 
            // button1
            // 
            this.buttonModificarReserva.Location = new System.Drawing.Point(563, 526);
            this.buttonModificarReserva.Name = "button1";
            this.buttonModificarReserva.Size = new System.Drawing.Size(192, 23);
            this.buttonModificarReserva.TabIndex = 72;
            this.buttonModificarReserva.Text = "Modificar reserva";
            // 
            // ModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 589);
            this.Controls.Add(this.buttonModificarReserva);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "ModificarReserva";
            this.Text = "ModificarReserva";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupRegimenesDelHotel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.regimenesDisponiblesGrid)).EndInit();
            this.groupHabitacionesDisponibles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.habitacionesDisponiblesGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupRegimenesDelHotel;
        private System.Windows.Forms.DataGridView regimenesDisponiblesGrid;
        private System.Windows.Forms.GroupBox groupHabitacionesDisponibles;
        private System.Windows.Forms.DataGridView habitacionesDisponiblesGrid;
        private System.Windows.Forms.DateTimePicker calendarioHasta;
        private System.Windows.Forms.DateTimePicker calendarioDesde;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label labelRegimen;
        private System.Windows.Forms.ComboBox comboBoxRegimen;
        private System.Windows.Forms.Label labelHotel;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.Label labelTipoHabitacion;
        private System.Windows.Forms.ComboBox comboBoxTipoHabitacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buscarHabitacionesButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelHotelActual;
        private System.Windows.Forms.Label labelRegimenActual;
        private System.Windows.Forms.Button buttonModificarReserva;

    }
}