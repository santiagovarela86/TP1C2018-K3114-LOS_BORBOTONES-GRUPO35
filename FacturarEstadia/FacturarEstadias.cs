using FrbaHotel.Modelo;
using FrbaHotel.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.FacturarEstadia
{
    public partial class FacturarEstadias : Form
    {
        List<Estadia> estadias = new List<Estadia>();
        List<Consumible> consumiblesXEstadia = new List<Consumible>();
        public FacturarEstadias()
        {
            InitializeComponent();
        }
        private void ListadoFacturarEstadia_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dataGridView1.DataSource = new List<Estadia>();
            dataGridView2.DataSource = new List<Consumible>();

            comboBoxTipoPago.SelectedValue = "";

            List<String> tipoPago = new List<String>();
            tipoPago.Add("Efectivo");
            tipoPago.Add("VISA Credito");
            tipoPago.Add("American Express Credito");
            tipoPago.Add("Mastercard Credito");

            comboBoxTipoPago.ValueMember = "Value";
            comboBoxTipoPago.DisplayMember = "Key";
            comboBoxTipoPago.DataSource = tipoPago;
            comboBoxTipoPago.SelectedValue = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ListadoFacturarEstadia_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //traigo la estadia con sus items de factura si la estadia ya tiene checkout hecho.
            int idEstadia = 0;
            RepositorioEstadia repositorioEstadia = new RepositorioEstadia();
            RepositorioEstadoReserva repoEstadoReserva =new RepositorioEstadoReserva();

            Estadia estadia = null;
            EstadoReserva estadoReserva=null;

            if (textBox1.Text != "")
            {
                idEstadia = int.Parse(textBox1.Text);

                estadia = repositorioEstadia.getById(idEstadia);
                //buscar por estado reserva que este con check out ya realizado
                estadoReserva = repoEstadoReserva.getByIdEstadia(idEstadia);
             if (estadia.getCantidadNoches()==0 | estadoReserva.getTipoEstado().Equals("RCE") | estadia.getFacturada()==true)
             {
                 if(estadoReserva.getTipoEstado().Equals("RCE"))
                     MessageBox.Show("Todavia no se realizo el checkout de la estadia ingresada ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 if (estadia.getFacturada() == true)
                     MessageBox.Show("la estadia ingresada ya fue facturada ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 MessageBox.Show("La estadia ingresada no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }else
             {
                //lleno los datos de la estadia aca se puede ver la cantidad de noches que de verdad se alojo.
                 //List<Estadia> estadias = new List<Estadia>();
                estadias.Add(estadia);
                dataGridView1.DataSource = estadias;
                dataGridView1.ClearSelection();
                //lleno los consumibles por estadia en el datagrid2
                //List<Consumible> consumiblesXEstadia = new List<Consumible>();
                consumiblesXEstadia = repositorioEstadia.getConsumiblesXIdEstadia(estadia.getIdEstadia());
                dataGridView2.DataSource = consumiblesXEstadia;
                dataGridView2.ClearSelection();                
             }
            }else
            {
                MessageBox.Show("por favor ingresar id de estadia ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FACTURAR ESTADIA
            RepositorioFactura repoFact = new RepositorioFactura();
            int idFactura = 0;
            String tipoPago = "";
            String nombreTarjeta = "";
            String vencTarjeta = "";
            String nroTarjeta = "";
            String codSegTarjeta = "";

            if (comboBoxTipoPago.SelectedItem != null)
            {
                tipoPago = (String)comboBoxTipoPago.SelectedItem;
            }
            if(tipoPago.Equals("Efectivo"))
            {
                //es efectivo llamo aca no necesito los datos de tarjeta
                
            }else
            {
                //traigo los datos de la tarjeta
                nombreTarjeta = textBox2.Text;
                nroTarjeta = textBox3.Text;
                codSegTarjeta= textBox4.Text;
                vencTarjeta = textBox5.Text;
                if (vencTarjeta=="" |codSegTarjeta==""| nroTarjeta=="" | nombreTarjeta=="")
                {
                    MessageBox.Show("por favor completar todos los campos de informacion de tarjeta ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ListadoFacturarEstadia_Load(sender, e);    
                }else
                {
                    //tomo la informacion de la estadia, consumibles por estadia y datos de pago
                    idFactura= repoFact.facturar(estadias, consumiblesXEstadia, tipoPago);
                    if (idFactura==0)
                        MessageBox.Show("Error cargando algun item de la factura ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (idFactura == 2)
                        MessageBox.Show("Error cargando la factura ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (idFactura == 1)
                         MessageBox.Show("estadia facturada correctamente ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }    
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

    }
}

