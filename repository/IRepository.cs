using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.repository
{
    public interface IRepository<ID, E>
    {
        void add(E e);
        void rem(ID id);
        E upd(E e);
        E findOne(ID id);
        IEnumerable<E> findAll();
        int size();
    }
}
