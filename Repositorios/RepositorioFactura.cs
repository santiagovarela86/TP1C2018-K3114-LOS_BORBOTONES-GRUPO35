using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Repositorios
{
    class RepositorioFactura : Repositorio<Factura>
    {
        override public List<Factura> getAll()
        {
            throw new NotImplementedException();
        }
        override public Factura getById(int idFactura)
        {
            throw new NotImplementedException();
        }
        
        override public int create(Factura factura)
        {
            if (this.exists(factura))
            {
                //Error
            }
            else
            {
                //Creo un nuevo registro
            }

            throw new System.NotImplementedException();
        }

        override public void update(Factura factura)
        {
            if (this.exists(factura))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(Factura factura)
        {
            if (this.exists(factura))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }

        override public void bajaLogica(Factura factura)
        {
            throw new NotImplementedException();
        }

        override public Boolean exists(Factura factura)
        {
            throw new NotImplementedException();
        }

        public int facturar(List<Estadia> estadias, List<Consumible> consumiblesXEstadia, String tipoPago)
        {
            int idFactura = 0;
            int resultado = 0;
            int numeroFactura = 0;
            RepositorioEstadia repoEstadia = new RepositorioEstadia();
            RepositorioReserva repoReserva = new RepositorioReserva();
            RepositorioItemFactura repoItemFactura = new RepositorioItemFactura();
            Estadia estadia=null;
            Reserva reserva = null;
            
            //suponemos que hay solo 1 estadia por estrategia enunciado, pero lo dejo aca como para hacer mas si necesito.
            estadia=estadias.First();

            //traigo la reserva y comparo los dias que sean los mismos los de la reserva que los que tuve efectivamente la estadia
            reserva = repoReserva.getIdByIdEstadia(estadia.getIdEstadia());

            List<ItemFactura> itemsFactura = new List<ItemFactura>();
            float total = 0;
            int puntos = 0;

            //traigo el numero de factura asi le sumo 1 que sera el nuevo.(SI NO ES AUTOINCREMENTAL)

            //traigo el total
            //hago for each de los consumibles y sumo total y puntos
            //consigo los dias que estuvo y el precio de habitaciones para sumar total y puntos

            //sumo los puntos

            float cant = 1;//pongo cant siempre en 1 ya que no marco mas que 1 solo consumible
            float monto = 0;//va a ser siempre el precio del cons ya que no marco mas que 1 solo consumible
            DateTime fecha = new DateTime();
            int idItemFactura = 0;
            int idConsumible = 0;
            fecha = DateTime.Today;               
                        
            Factura factura = new Factura(idFactura,estadia,reserva,numeroFactura,fecha,total,puntos,tipoPago,itemsFactura);
            idFactura = this.create(factura);
            if(idFactura!=0)
            {
                if( reserva.getDiasAlojados()==estadia.getCantidadNoches())
                {
                    //se quedo toda la estadia
                    ItemFactura itemFactura = null;

                    foreach (Consumible item in consumiblesXEstadia)
                    {
                        idConsumible = item.getIdConsumible();
                        monto = item.getPrecio();
                        itemFactura = new ItemFactura(idItemFactura,idConsumible,cant,monto,fecha,idFactura);
                       // itemsFactura.Add(itemFactura);
                        //creo uno a uno los items factura
                        repoItemFactura.create(itemFactura);
                    }

                
                }
                else
                {
                    //no se quedo toda la estadia hago un metodo especial en itemFactura
                }
                //hacer update de la estadia avisando que ya facture
                repoEstadia.facturado(estadia.getIdEstadia());
            }
            
            return resultado;
        }
    }
}
