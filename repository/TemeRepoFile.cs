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
    class TemeRepoFile : AbstractCRUDRepo<string, Teme>
    {
        public TemeRepoFile(IValidator<Teme> validator, string filename) : base(validator)
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
                    Teme teme = new Teme(linii[0], linii[1], int.Parse(linii[2]), int.Parse(linii[3]));
                    base.add(teme);
                }
            }
        }

        private void writeFile()
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var teme in base.findAll())
                {
                    string s = teme.Id + ',' + teme.descriere + ',' + teme.dead_line.ToString() + ',' + teme.primire.ToString();
                    sw.WriteLine(s);
                }
                sw.Flush();
            }
        }

        public override void add(Teme e)
        {
            base.add(e);
            this.writeFile();
        }

        public override void rem(string id)
        {
            base.rem(id);
            this.writeFile();
        }

        public override Teme upd(Teme e)
        {
            Teme t = base.upd(e);
            this.writeFile();
            return t;
        }
    }
}
