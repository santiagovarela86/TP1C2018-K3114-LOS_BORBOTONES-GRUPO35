using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Factura
    {
        private int idFactura = 0;
        private Estadia estadia = null;
        private Reserva reserva = null;
        private int numeroFactura = 0;
        private DateTime fechaFacturacion = new DateTime();
        private float total = 0;
        private int puntos = 0;
        private String tipoPago = "";
        private List<ItemFactura> itemsFactura = new List<ItemFactura>();

        public Factura(int idFactura, Estadia estadia, Reserva reserva, int numeroFactura, DateTime fechaFacturacion,
            float total, int puntos, String tipoPago, List<ItemFactura> itemsFactura)
        {
            this.idFactura = idFactura;
            this.estadia = estadia;
            this.reserva = reserva;
            this.numeroFactura = numeroFactura;
            this.fechaFacturacion = fechaFacturacion;
            this.total = total;
            this.puntos = puntos;
            this.tipoPago = tipoPago;
            this.itemsFactura = itemsFactura;
        }

        public int getIdFactura()
        {
            return idFactura;
        }

        public Estadia getEstadia()
        {
            return estadia;
        }

        public Reserva getReserva()
        {
            return reserva;
        }

        public int getNumeroFactura()
        {
            return numeroFactura;
        }

        public DateTime getFechaFacturacion()
        {
            return fechaFacturacion;
        }

        public float getTotal()
        {
            return total;
        }

        public int getPuntos()
        {
            return idFactura;
        }

        public String getTipoPago()
        {
            return tipoPago;
        }

        public List<ItemFactura> getItemsFactura()
        {
            return itemsFactura;
        }

        public Boolean esNuevo()
        {
            return idFactura.Equals(0);
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
        public int IdFactura { get { return this.getIdFactura(); } }
        public Estadia Estadia { get { return this.getEstadia(); } }
        public Reserva Reserva { get { return this.getReserva(); } }
        public int NumeroFactura { get { return this.getNumeroFactura(); } }
        public DateTime FechaFacturacion { get { return this.getFechaFacturacion(); } }
        public float Total { get { return this.getTotal(); } }
        public int Puntos { get { return this.getPuntos(); } }
        public String TipoPago { get { return this.getTipoPago(); } }
        public List<ItemFactura> ItemsFactura { get { return this.getItemsFactura(); } }
    }
}
