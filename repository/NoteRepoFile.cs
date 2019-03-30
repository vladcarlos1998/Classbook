using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3.obiecte;

namespace lab3.repository
{
    class NoteRepoFile : NoteRepository
    {
        public NoteRepoFile(string filename) : base()
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
                    Nota nota = new Nota(linii[0], linii[1], double.Parse(linii[2]), linii[3], linii[4]);
                    base.add(nota);
                }
            }
        }

        private void writeFile()
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var nota in base.findAll())
                {
                    string s = nota.idStudent + ',' + nota.idTeme + ',' + nota.nota.ToString() + ',' + nota.feedback + ',' + nota.cadru_didactic;
                    sw.WriteLine(s);
                }
                sw.Flush();
            }
        }

        public override void add(Nota e)
        {
            base.add(e);
            this.writeFile();
        }

        public override void rem(string idS, string idT)
        {
            base.rem(idS, idT);
            this.writeFile();
        }

        public override Nota upd(Nota e)
        {
            Nota s = base.upd(e);
            this.writeFile();
            return s;
        }
    }
}
