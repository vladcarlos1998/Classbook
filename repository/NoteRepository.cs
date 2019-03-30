using lab3.obiecte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.repository
{
    public class NoteRepository
    {
        public NoteRepository()
        {
        }

        List<Nota> elemente = new List<Nota>();

        public virtual void add(Nota e)
        {
            this.elemente.Add(e);
        }

        public virtual void rem(string idStudent, string idTema)
        {
            this.elemente.Remove(this.findOne(idStudent, idTema));
        }

        public virtual Nota upd(Nota nota)
        {
            foreach (Nota n in this.elemente)
            {
                if (n.idStudent == nota.idStudent && n.idTeme == nota.idTeme)
                {
                    n.nota = nota.nota;
                    n.feedback = nota.feedback;
                    n.cadru_didactic = nota.cadru_didactic;
                    return n;
                }
            }
            return default(Nota);
        }

        public Nota findOne(string idStudent, string idTema)
        {
            foreach(Nota n in this.elemente)
            {
                if(n.idStudent == idStudent && n.idTeme == idTema)
                {
                    return n;
                }
            }
            return default(Nota);
        }

        public IEnumerable<Nota> findAll()
        {
            return this.elemente.ToList();
        }

        public int size()
        {
            return this.elemente.Count;
        }
    }
}
