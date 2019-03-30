using lab3.obiecte;
using lab3.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.service
{
    class NotaService
    {
        private IRepository<string, Student> repoS;
        private IRepository<string, Teme> repoT;
        private NoteRepository repo;
        public int saptamana_curenta { get; set; }

        public NotaService(IRepository<string, Student> repoS, IRepository<string, Teme> repoT, NoteRepository repo)
        {
            this.repoS = repoS;
            this.repoT = repoT;
            this.repo = repo;
        }

        public void add(string idStudent, string idTeme, double nota, string feedback, string cadru_didactic)
        {
            if (this.findOne(idStudent, idTeme) == default(Nota))
            {
                if (this.repoS.findOne(idStudent) != default(Student) && this.repoT.findOne(idTeme) != default(Teme))
                {
                    Nota n = new Nota(idStudent, idTeme, nota, feedback, cadru_didactic);
                    double nr = this.nota_max(nota, idTeme, this.saptamana_curenta);
                    if (nr > 0)
                    {
                        n.nota = nr;
                    }
                    this.repo.add(n);
                }
            }
        }

        public void rem(string idS, string idT)
        {
            this.repo.rem(idS, idT);
        }

        public void upd(string idStudent, string idTeme, double nota, string feedback, string cadru_didactic)
        {
            Nota n = new Nota(idStudent, idTeme, nota, feedback, cadru_didactic);
            this.repo.upd(n);
        }

        public Nota findOne(string idS, string idT)
        {
            return this.repo.findOne(idS, idT);
        }

        public List<Nota> findAll()
        {
            return this.repo.findAll().ToList();
        }

        public int size()
        {
            return this.repo.size();
        }

        public double nota_max(Double nota, String numar_nota, int diferenta_saptamana)
        {
            if (diferenta_saptamana > this.repoT.findOne(numar_nota).dead_line)
            {
                int n = diferenta_saptamana - this.repoT.findOne(numar_nota).dead_line;
                if (nota - n * 2 <= 2)
                {
                    return 2;
                }
                else
                {
                    return nota - n * 2;
                }
            }
            return nota;
        }

        public List<Nota> filterN()
        {
            return (from x in this.repo.findAll().ToList()
                    orderby x.nota descending,
                    x.cadru_didactic ascending
                    select x).ToList();
        }

        public List<KeyValuePair<int, int>> filterNo()
        {
            List<KeyValuePair<int, int>> rez = new List<KeyValuePair<int, int>>();

            rez = (from x in this.repo.findAll().ToList()
                   group x by x.nota into G
                   select new KeyValuePair<int, int> (Convert.ToInt32(G.Key), G.Count())).ToList();
            return rez;
        }

        public List<Nota> filterNaS(string idS)
        {
            return (from x in this.repo.findAll().ToList()
                    where x.idStudent == idS
                    select x).ToList();
        }

        public List<Nota> filterNaT(string idT)
        {
            return (from x in this.repo.findAll().ToList()
                    where x.idTeme == idT
                    select x).ToList();
        }

        public List<Nota> filterNaG(string idT, string grupa)
        {
            return (from x in this.filterNaT(idT)
                    where this.repoS.findOne(x.idStudent).grupa == grupa
                    select x).ToList();
        }

        public List<Nota> filterNaOG(string grupa)
        {
            return (from x in this.repo.findAll().ToList()
                    where this.repoS.findOne(x.idStudent).grupa == grupa
                    orderby x.idStudent
                    select x).ToList();
        }

        public int findOneNaOG(string idS, string idT, string grupa)
        {
            int rez = 0;
            this.filterNaOG(grupa).ForEach(x =>
            {
                if (x.idStudent == idS && x.idTeme == idT)
                {
                    rez = 1;
                }
            });
            return rez;
        }
    }
}
