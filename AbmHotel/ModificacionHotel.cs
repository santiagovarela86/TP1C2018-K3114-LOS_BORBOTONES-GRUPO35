using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class ModificacionHotel
      : Form

    {
        private Hotel hotel;
        private TextBox nombreText;
        private Label nombreLabel;
        private Label telefonoLabel;
        private TextBox telefonoText;
        private Label calleLabel;
        private TextBox calleText;
        private Label estrellasLabel;
        private ComboBox estrellasComboBox;
        private Label ciudadLabel;
        private TextBox ciudadText;
        private Label numeroCalleLabel;
        private TextBox numeroCalleText;
        private Label paisLabel;
        private TextBox paisText;
        private Label regimenesLabel;
        private TextBox regimenesText;
        private Label creacionLabel;
        private TextBox creacionText;
        private GroupBox groupBox1;
        private Button crearHotel;


        public ModificacionHotel(Hotel hotel)
        {
            this.hotel = hotel;
            InitializeComponent();
            initModificacionHotel();
        }

        private void initModificacionHotel() {
            this.nombreText.Text = hotel.getNombre();
            this.paisText.Text = hotel.getDireccion().getPais();
            this.ciudadText.Text = hotel.getDireccion().getCiudad();
            this.telefonoText.Text = hotel.getTelefono();
            this.estrellasComboBox.SelectedItem = hotel.getCategoria().getEstrellas();
            this.calleText.Text = hotel.getDireccion().getCalle();
            this.numeroCalleText.Text = hotel.getDireccion().getNumeroCalle().ToString();

        }
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
            this.nombreText = new System.Windows.Forms.TextBox();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.telefonoLabel = new System.Windows.Forms.Label();
            this.telefonoText = new System.Windows.Forms.TextBox();
            this.calleLabel = new System.Windows.Forms.Label();
            this.calleText = new System.Windows.Forms.TextBox();
            this.estrellasLabel = new System.Windows.Forms.Label();
            this.estrellasComboBox = new System.Windows.Forms.ComboBox();
            this.ciudadLabel = new System.Windows.Forms.Label();
            this.ciudadText = new System.Windows.Forms.TextBox();
            this.numeroCalleLabel = new System.Windows.Forms.Label();
            this.numeroCalleText = new System.Windows.Forms.TextBox();
            this.paisLabel = new System.Windows.Forms.Label();
            this.paisText = new System.Windows.Forms.TextBox();
            this.regimenesLabel = new System.Windows.Forms.Label();
            this.regimenesText = new System.Windows.Forms.TextBox();
            this.creacionLabel = new System.Windows.Forms.Label();
            this.creacionText = new System.Windows.Forms.TextBox();
            this.crearHotel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.telefonoLabel);
            this.groupBox1.Controls.Add(this.telefonoText);
            this.groupBox1.Controls.Add(this.calleLabel);
            this.groupBox1.Controls.Add(this.calleText);
            this.groupBox1.Controls.Add(this.estrellasLabel);
            this.groupBox1.Controls.Add(this.estrellasComboBox);
            this.groupBox1.Controls.Add(this.ciudadLabel);
            this.groupBox1.Controls.Add(this.ciudadText);
            this.groupBox1.Controls.Add(this.numeroCalleLabel);
            this.groupBox1.Controls.Add(this.numeroCalleText);
            this.groupBox1.Controls.Add(this.paisLabel);
            this.groupBox1.Controls.Add(this.paisText);
            this.groupBox1.Controls.Add(this.regimenesLabel);
            this.groupBox1.Controls.Add(this.regimenesText);
            this.groupBox1.Controls.Add(this.creacionLabel);
            this.groupBox1.Controls.Add(this.creacionText);
            this.groupBox1.Controls.Add(this.nombreLabel);
            this.groupBox1.Controls.Add(this.nombreText);
            this.groupBox1.Controls.Add(this.crearHotel);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 407);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear Hotel";
            // 
            // telefonoLabel
            // 
            this.telefonoLabel.AutoSize = true;
            this.telefonoLabel.Location = new System.Drawing.Point(23, 221);
            this.telefonoLabel.Name = "telefonoLabel";
            this.telefonoLabel.Size = new System.Drawing.Size(52, 13);
            this.telefonoLabel.TabIndex = 15;
            this.telefonoLabel.Text = "Telefono:";
            // 
            // telefonoText
            // 
            this.telefonoText.Location = new System.Drawing.Point(86, 218);
            this.telefonoText.Name = "telefonoText";
            this.telefonoText.Size = new System.Drawing.Size(117, 20);
            this.telefonoText.TabIndex = 14;
            // 
            // calleLabel
            // 
            this.calleLabel.AutoSize = true;
            this.calleLabel.Location = new System.Drawing.Point(23, 161);
            this.calleLabel.Name = "calleLabel";
            this.calleLabel.Size = new System.Drawing.Size(33, 13);
            this.calleLabel.TabIndex = 13;
            this.calleLabel.Text = "Calle:";
            // 
            // calleText
            // 
            this.calleText.Location = new System.Drawing.Point(86, 158);
            this.calleText.Name = "calleText";
            this.calleText.Size = new System.Drawing.Size(117, 20);
            this.calleText.TabIndex = 12;
            // 
            // estrellasLabel
            // 
            this.estrellasLabel.AutoSize = true;
            this.estrellasLabel.Location = new System.Drawing.Point(485, 44);
            this.estrellasLabel.Name = "estrellasLabel";
            this.estrellasLabel.Size = new System.Drawing.Size(49, 13);
            this.estrellasLabel.TabIndex = 11;
            this.estrellasLabel.Text = "Estrellas:";
            // 
            // estrellasComboBox
            // 
            this.estrellasComboBox.Items.AddRange(new object[] {
            1,
            2,
            3,
            4,
            5});
            this.estrellasComboBox.Location = new System.Drawing.Point(548, 41);
            this.estrellasComboBox.Name = "estrellasComboBox";
            this.estrellasComboBox.Size = new System.Drawing.Size(117, 21);
            this.estrellasComboBox.TabIndex = 10;
            // 
            // ciudadLabel
            // 
            this.ciudadLabel.AutoSize = true;
            this.ciudadLabel.Location = new System.Drawing.Point(244, 97);
            this.ciudadLabel.Name = "ciudadLabel";
            this.ciudadLabel.Size = new System.Drawing.Size(43, 13);
            this.ciudadLabel.TabIndex = 9;
            this.ciudadLabel.Text = "Ciudad:";
            // 
            // ciudadText
            // 
            this.ciudadText.Location = new System.Drawing.Point(307, 94);
            this.ciudadText.Name = "ciudadText";
            this.ciudadText.Size = new System.Drawing.Size(117, 20);
            this.ciudadText.TabIndex = 8;
            // 
            // numeroCalleLabel
            // 
            this.numeroCalleLabel.AutoSize = true;
            this.numeroCalleLabel.Location = new System.Drawing.Point(244, 157);
            this.numeroCalleLabel.Name = "numeroCalleLabel";
            this.numeroCalleLabel.Size = new System.Drawing.Size(72, 13);
            this.numeroCalleLabel.TabIndex = 13;
            this.numeroCalleLabel.Text = "Numero calle:";
            // 
            // numeroCalleText
            // 
            this.numeroCalleText.Location = new System.Drawing.Point(322, 154);
            this.numeroCalleText.Name = "numeroCalleText";
            this.numeroCalleText.Size = new System.Drawing.Size(117, 20);
            this.numeroCalleText.TabIndex = 12;
            // 
            // paisLabel
            // 
            this.paisLabel.AutoSize = true;
            this.paisLabel.Location = new System.Drawing.Point(23, 97);
            this.paisLabel.Name = "paisLabel";
            this.paisLabel.Size = new System.Drawing.Size(30, 13);
            this.paisLabel.TabIndex = 7;
            this.paisLabel.Text = "Pais:";
            // 
            // paisText
            // 
            this.paisText.Location = new System.Drawing.Point(86, 94);
            this.paisText.Name = "paisText";
            this.paisText.Size = new System.Drawing.Size(117, 20);
            this.paisText.TabIndex = 6;
            // 
            // regimenesLabel
            // 
            this.regimenesLabel.AutoSize = true;
            this.regimenesLabel.Location = new System.Drawing.Point(244, 217);
            this.regimenesLabel.Name = "regimenesLabel";
            this.regimenesLabel.Size = new System.Drawing.Size(55, 13);
            this.regimenesLabel.TabIndex = 5;
            this.regimenesLabel.Text = "Regimen: ";
            // 
            // regimenesText
            // 
            this.regimenesText.Location = new System.Drawing.Point(307, 214);
            this.regimenesText.Name = "regimenesText";
            this.regimenesText.Size = new System.Drawing.Size(117, 20);
            this.regimenesText.TabIndex = 4;
            // 
            // creacionLabel
            // 
            this.creacionLabel.AutoSize = true;
            this.creacionLabel.Location = new System.Drawing.Point(244, 44);
            this.creacionLabel.Name = "creacionLabel";
            this.creacionLabel.Size = new System.Drawing.Size(60, 13);
            this.creacionLabel.TabIndex = 3;
            this.creacionLabel.Text = "F. creacion";
            // 
            // creacionText
            // 
            this.creacionText.Location = new System.Drawing.Point(307, 41);
            this.creacionText.Name = "creacionText";
            this.creacionText.Size = new System.Drawing.Size(117, 20);
            this.creacionText.TabIndex = 2;
            // 
            // crearHotel
            // 
            this.crearHotel.Location = new System.Drawing.Point(289, 332);
            this.crearHotel.Name = "crearHotel";
            this.crearHotel.Size = new System.Drawing.Size(161, 23);
            this.crearHotel.TabIndex = 0;
            this.crearHotel.Text = "Crear";
            this.crearHotel.Click += new System.EventHandler(this.modificarHotel_Click);
            // 
            // ModificacionHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 395);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificacionHotel";
            this.Text = "Creacion de Hoteles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void modificarHotel_Click(object sender, EventArgs e)
        {
            RepositorioHotel repoHotel = new RepositorioHotel();
            repoHotel.update(hotel);

        }


    }

}
