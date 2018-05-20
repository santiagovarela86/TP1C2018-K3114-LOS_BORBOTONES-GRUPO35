using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Repositorios
{
    abstract class Repositorio<T>
    {
        abstract public T getById(int id);
        abstract public List<T> getAll();
    }
}
