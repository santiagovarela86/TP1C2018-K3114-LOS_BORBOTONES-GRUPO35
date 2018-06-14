using System.Windows.Forms;
namespace FrbaHotel.AbmHabitacion
{
    partial class ABMHabitacion
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAltaHabitacion = new System.Windows.Forms.Button();
            this.buttonModificarHabitacion = new System.Windows.Forms.Button();
            this.buttonBajaHabitacion = new System.Windows.Forms.Button();
            this.buttonBbuscarHoteles = new System.Windows.Forms.Button();
            this.registroHabitaciones = new System.Windows.Forms.DataGridView();
            this.checkBoxActiva = new System.Windows.Forms.CheckBox();
            this.labelTipoHabitacion = new System.Windows.Forms.Label();
            this.comboBoxTipoHabitacion = new System.Windows.Forms.ComboBox();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.comboBoxUbicacion = new System.Windows.Forms.ComboBox();
            this.labelHotel = new System.Windows.Forms.Label();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.labelPiso = new System.Windows.Forms.Label();
            this.textPiso = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registroHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxActiva);
            this.groupBox2.Controls.Add(this.buttonAltaHabitacion);
            this.groupBox2.Controls.Add(this.labelTipoHabitacion);
            this.groupBox2.Controls.Add(this.buttonModificarHabitacion);
            this.groupBox2.Controls.Add(this.comboBoxTipoHabitacion);
            this.groupBox2.Controls.Add(this.buttonBajaHabitacion);
            this.groupBox2.Controls.Add(this.labelHotel);
            this.groupBox2.Controls.Add(this.labelUbicacion);
            this.groupBox2.Controls.Add(this.comboBoxHotel);
            this.groupBox2.Controls.Add(this.buttonBbuscarHoteles);
            this.groupBox2.Controls.Add(this.comboBoxUbicacion);
            this.groupBox2.Controls.Add(this.registroHabitaciones);
            this.groupBox2.Controls.Add(this.textNumero);
            this.groupBox2.Controls.Add(this.labelNumero);
            this.groupBox2.Controls.Add(this.textPiso);
            this.groupBox2.Controls.Add(this.labelPiso);
            this.groupBox2.Location = new System.Drawing.Point(29, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 563);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Hotel";
            // 
            // buttonAltaHabitacion
            // 
            this.buttonAltaHabitacion.Location = new System.Drawing.Point(114, 516);
            this.buttonAltaHabitacion.Name = "buttonAltaHabitacion";
            this.buttonAltaHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonAltaHabitacion.TabIndex = 14;
            this.buttonAltaHabitacion.Text = "Crear Habitacion";
            this.buttonAltaHabitacion.UseVisualStyleBackColor = true;
            this.buttonAltaHabitacion.Click += new System.EventHandler(this.buttonCrearHabitacion_Click);
            // 
            // buttonModificarHabitacion
            // 
            this.buttonModificarHabitacion.Location = new System.Drawing.Point(239, 516);
            this.buttonModificarHabitacion.Name = "buttonModificarHabitacion";
            this.buttonModificarHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonModificarHabitacion.TabIndex = 15;
            this.buttonModificarHabitacion.Text = "Modificar Habitacion";
            this.buttonModificarHabitacion.UseVisualStyleBackColor = true;
            // 
            // buttonBajaHabitacion
            // 
            this.buttonBajaHabitacion.Location = new System.Drawing.Point(359, 516);
            this.buttonBajaHabitacion.Name = "buttonBajaHabitacion";
            this.buttonBajaHabitacion.Size = new System.Drawing.Size(75, 23);
            this.buttonBajaHabitacion.TabIndex = 16;
            this.buttonBajaHabitacion.Text = "Baja Habitacion";
            this.buttonBajaHabitacion.UseVisualStyleBackColor = true;
            this.buttonBajaHabitacion.Click += new System.EventHandler(this.buttonBajaHabitacion_Click);
            // 
            // buttonBbuscarHoteles
            // 
            this.buttonBbuscarHoteles.Location = new System.Drawing.Point(185, 158);
            this.buttonBbuscarHoteles.Name = "buttonBbuscarHoteles";
            this.buttonBbuscarHoteles.Size = new System.Drawing.Size(161, 23);
            this.buttonBbuscarHoteles.TabIndex = 0;
            this.buttonBbuscarHoteles.Text = "Buscar";
            this.buttonBbuscarHoteles.Click += new System.EventHandler(this.buttonBbuscarHoteles_Click);
            // 
            // registroHoteles
            // 
            this.registroHabitaciones.AllowUserToAddRows = false;
            this.registroHabitaciones.AllowUserToDeleteRows = false;
            this.registroHabitaciones.AllowUserToOrderColumns = true;
            this.registroHabitaciones.AllowUserToResizeRows = false;
            this.registroHabitaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.registroHabitaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.registroHabitaciones.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.registroHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registroHabitaciones.Location = new System.Drawing.Point(20, 200);
            this.registroHabitaciones.MultiSelect = false;
            this.registroHabitaciones.Name = "registroHoteles";
            this.registroHabitaciones.ReadOnly = true;
            this.registroHabitaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.registroHabitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.registroHabitaciones.Size = new System.Drawing.Size(513, 257);
            this.registroHabitaciones.TabIndex = 0;
            // 
            // checkBoxActiva
            // 
            this.checkBoxActiva.AutoSize = true;
            this.checkBoxActiva.Location = new System.Drawing.Point(437, 87);
            this.checkBoxActiva.Name = "checkBoxActiva";
            this.checkBoxActiva.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActiva.TabIndex = 32;
            this.checkBoxActiva.Text = "Activa";
            this.checkBoxActiva.UseVisualStyleBackColor = true;
            // 
            // labelTipoHabitacion
            // 
            this.labelTipoHabitacion.AutoSize = true;
            this.labelTipoHabitacion.Location = new System.Drawing.Point(228, 87);
            this.labelTipoHabitacion.Name = "labelTipoHabitacion";
            this.labelTipoHabitacion.Size = new System.Drawing.Size(37, 13);
            this.labelTipoHabitacion.TabIndex = 31;
            this.labelTipoHabitacion.Text = "Tipo : ";
            // 
            // comboBoxTipoHabitacion
            // 
            this.comboBoxTipoHabitacion.Location = new System.Drawing.Point(279, 81);
            this.comboBoxTipoHabitacion.Name = "comboBoxTipoHabitacion";
            this.comboBoxTipoHabitacion.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTipoHabitacion.TabIndex = 30;
            // 
            // labelUbicacion
            // 
            this.labelUbicacion.AutoSize = true;
            this.labelUbicacion.Location = new System.Drawing.Point(17, 81);
            this.labelUbicacion.Name = "labelUbicacion";
            this.labelUbicacion.Size = new System.Drawing.Size(58, 13);
            this.labelUbicacion.TabIndex = 29;
            this.labelUbicacion.Text = "Ubicacion:";
            // 
            // comboBoxUbicacion
            // 
            this.comboBoxUbicacion.Location = new System.Drawing.Point(92, 78);
            this.comboBoxUbicacion.Name = "comboBoxUbicacion";
            this.comboBoxUbicacion.Size = new System.Drawing.Size(100, 21);
            this.comboBoxUbicacion.TabIndex = 28;
            // 
            // labelHotel
            // 
            this.labelHotel.AutoSize = true;
            this.labelHotel.Location = new System.Drawing.Point(311, 36);
            this.labelHotel.Name = "labelHotel";
            this.labelHotel.Size = new System.Drawing.Size(35, 13);
            this.labelHotel.TabIndex = 27;
            this.labelHotel.Text = "Hotel:";
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.Location = new System.Drawing.Point(359, 33);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(174, 21);
            this.comboBoxHotel.TabIndex = 26;
            // 
            // labelPiso
            // 
            this.labelPiso.AutoSize = true;
            this.labelPiso.Location = new System.Drawing.Point(181, 33);
            this.labelPiso.Name = "labelPiso";
            this.labelPiso.Size = new System.Drawing.Size(27, 13);
            this.labelPiso.TabIndex = 23;
            this.labelPiso.Text = "Piso";
            // 
            // textPiso
            // 
            this.textPiso.Location = new System.Drawing.Point(214, 30);
            this.textPiso.Name = "textPiso";
            this.textPiso.Size = new System.Drawing.Size(78, 20);
            this.textPiso.TabIndex = 22;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(16, 33);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(44, 13);
            this.labelNumero.TabIndex = 21;
            this.labelNumero.Text = "Numero";
            // 
            // textNumero
            // 
            this.textNumero.Location = new System.Drawing.Point(67, 30);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(71, 20);
            this.textNumero.TabIndex = 20;
            // 
            // ABMHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 601);
            this.Controls.Add(this.groupBox2);
            this.Name = "ABMHabitacion";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registroHabitaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private Button buttonAltaHabitacion;
        private Button buttonModificarHabitacion;
        private Button buttonBajaHabitacion;
        private Button buttonBbuscarHoteles;
        private DataGridView registroHabitaciones;
        private CheckBox checkBoxActiva;
        private Label labelTipoHabitacion;
        private ComboBox comboBoxTipoHabitacion;
        private Label labelHotel;
        private Label labelUbicacion;
        private ComboBox comboBoxHotel;
        private ComboBox comboBoxUbicacion;
        private TextBox textNumero;
        private Label labelNumero;
        private TextBox textPiso;
        private Label labelPiso;

    }
}