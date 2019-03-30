using lab3.obiecte;
using lab3.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.repository
{
    public class AbstractCRUDRepo<ID, E> : IRepository<ID, E> where E : HasID<ID>
    {
        public AbstractCRUDRepo(IValidator<E> validator)
        {
            this.validator = validator;
        }

        IDictionary<ID, E> elemente = new Dictionary<ID, E>();
        public IValidator<E> validator { get; set; }

        public virtual void add(E e)
        {
            this.validator.Validate(e);
            this.elemente[e.Id] = e;
        }

        public virtual void rem(ID id)
        {
            this.elemente.Remove(id);
        }

        public virtual E upd(E e)
        {
            bool exista = this.elemente.TryGetValue(e.Id, out E e1);
            if (exista)
            {
                this.elemente[e.Id] = e;
                return e;
            }
            return default(E);
        }

        public E findOne(ID id)
        {
            this.elemente.TryGetValue(id, out E e);
            return e;
        }

        public IEnumerable<E> findAll()
        {
            return this.elemente.Values.ToList();
        }

        public int size()
        {
            return this.elemente.Count;
        }
    }
}
