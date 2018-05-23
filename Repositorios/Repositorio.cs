using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Repositorios
{
    public abstract class Repositorio<T>
    {
        public abstract T getById(int id);
        public abstract List<T> getAll();
        public abstract void save(T t);
    }
}
