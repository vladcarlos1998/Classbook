using lab3.obiecte;
using lab3.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.service
{
    public class TemeService
    {
        private IRepository<string, Teme> repo;
        public int saptamana_curenta { get; set; }

        public TemeService(IRepository<string, Teme> repo)
        {
            this.repo = repo;
        }

        public void add(string id, string descriere, int dead_line, int primire)
        {
            Teme t = new Teme(id, descriere, dead_line, primire);
            this.repo.add(t);
            this.updDead_line(id);
            this.updPrimire(id);
        }

        public void rem(string id)
        {
            this.repo.rem(id);
        }

        public void upd(string id, string descriere, int dead_line, int primire)
        {
            Teme t = new Teme(id, descriere, dead_line, primire);
            this.repo.upd(t);
        }

        public Teme findOne(string id)
        {
            return this.repo.findOne(id);
        }

        public List<Teme> findAll()
        {
            return this.repo.findAll().ToList();
        }

        public int size()
        {
            return this.repo.size();
        }

        public void updDead_line(String id)
        {
            Teme t = this.findOne(id);
            if (t.dead_line > this.saptamana_curenta)
            {
                this.upd(t.Id, t.descriere, this.saptamana_curenta, t.primire);
            }
        }

        public void updPrimire(String id)
        {
            Teme t = this.findOne(id);
            if (t.primire > t.dead_line)
            {
                this.upd(t.Id, t.descriere, t.dead_line, t.dead_line - 1);
            }
        }

        public List<Teme> filterT()
        {
            return (from x in this.repo.findAll().ToList()
                    orderby x.primire ascending,
                    x.dead_line ascending
                    select x).ToList();
        }

        public List<KeyValuePair<int, int>> filterD(int start, int end)
        {
            List<KeyValuePair<int, int>> rez = new List<KeyValuePair<int, int>>();

            rez = (from x in this.repo.findAll().ToList()
                   where x.dead_line >= start && x.dead_line <= end
                   group x by x.dead_line into G
                   select new KeyValuePair<int, int>(G.Key, G.Count())).ToList();
            return rez;
        }
    }
}
