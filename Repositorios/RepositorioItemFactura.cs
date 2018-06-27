using FrbaHotel.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Repositorios
{
    class RepositorioItemFactura : Repositorio<ItemFactura>
    {

        override public int create(ItemFactura itemFactura)
        {
            if (this.exists(itemFactura))
            {
                //Error
            }
            else
            {
                //Creo un nuevo registro
            }

            throw new System.NotImplementedException();
        }

        override public void update(ItemFactura itemFactura)
        {
            if (this.exists(itemFactura))
            {
                //Actualizo el registro
            }
            else
            {
                //Error
            }
        }

        override public void delete(ItemFactura itemFactura)
        {
            if (this.exists(itemFactura))
            {
                //Borro el registro
            }
            else
            {
                //Error
            }
        }

        override public void bajaLogica(ItemFactura itemFactura)
        {
            throw new NotImplementedException();
        }
        override public List<ItemFactura> getAll()
        {
            throw new NotImplementedException();
        }
        override public ItemFactura getById(int idItemFactura)
        {
            throw new NotImplementedException();
        }
        override public Boolean exists(ItemFactura itemFactura)
        {
            throw new NotImplementedException();
        }

    }
}
