using lab3.obiecte;
using lab3.validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.repository
{
    class StudentRepoFile : AbstractCRUDRepo<string, Student>
    {
        public StudentRepoFile(IValidator<Student> validator, string filename) : base(validator)
        {
            this.filename = filename;
            this.loadFile();
        }

        public string filename { get; set; }

        private void loadFile()
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] linii = line.Split(',');
                    Student student = new Student(linii[0], linii[1], linii[2], linii[3]);
                    base.add(student);
                }
            }
        }

        private void writeFile()
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var student in base.findAll())
                {
                    string s = student.Id + ',' + student.nume + ',' + student.grupa + ',' + student.email;
                    sw.WriteLine(s);
                }
                sw.Flush();
            }
        }

        public override void add(Student e)
        {
            base.add(e);
            this.writeFile();
        }

        public override void rem(string id)
        {
            base.rem(id);
            this.writeFile();
        }

        public override Student upd(Student e)
        {
            Student s = base.upd(e);
            this.writeFile();
            return s;
        }
    }
}
