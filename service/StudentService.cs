using lab3.obiecte;
using lab3.repository;
using lab3.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.service
{
    public class StudentService
    {
        private IRepository<string, Student> repo;

        public StudentService(IRepository<string, Student> repo)
        {
            this.repo = repo;
        }

        public void add(string id, string nume, string grupa, string email)
        {
            Student s = new Student(id, nume, grupa, email);
            this.repo.add(s);
        }

        public void rem(string id)
        {
            this.repo.rem(id);
        }

        public void upd(string id, string nume, string grupa, string email)
        {
            Student s = new Student(id, nume, grupa, email);
            this.repo.upd(s);
        }

        public Student findOne(string id)
        {
            return this.repo.findOne(id);
        }

        public List<Student> findAll()
        {
            return this.repo.findAll().ToList();
        }

        public int size()
        {
            return this.repo.size();
        }

        public List<Student> filterS()
        {
            return (from x in this.repo.findAll().ToList()
                    orderby x.grupa ascending,
                    x.nume ascending
                    select x).ToList();
        }

        public List<KeyValuePair<string, int>> filterG()
        {
            List<KeyValuePair<string, int>> rez = new List<KeyValuePair<string, int>>();

            rez = (from x in this.repo.findAll().ToList()
                   group x by x.grupa into G
                   select new KeyValuePair<string, int>(G.Key, G.Count())).ToList();
            return rez;
        }

        public List<Student> filterSG(string grupa)
        {
            return (from x in this.repo.findAll().ToList()
                    where x.grupa == grupa
                    orderby x.grupa ascending,
                    x.nume ascending
                    select x).ToList();
        }
    }
}
