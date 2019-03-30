using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.obiecte
{
    public class Nota
    {
        public Nota(string idStudent, string idTeme, double nota, string feedback, string cadru_didactic)
        {
            this.idStudent = idStudent;
            this.idTeme = idTeme;
            this.nota = nota;
            this.feedback = feedback;
            this.cadru_didactic = cadru_didactic;
        }

        public string idStudent { get; set; }
        public string idTeme { get; set; }
        public double nota { get; set; }
        public string feedback { get; set; }
        public string cadru_didactic { get; set; }

        public override bool Equals(object obj)
        {
            var nota = obj as Nota;
            return nota != null &&
                   idStudent == nota.idStudent &&
                   idTeme == nota.idTeme &&
                   this.nota == nota.nota &&
                   feedback == nota.feedback &&
                   cadru_didactic == nota.cadru_didactic;
        }

        public override int GetHashCode()
        {
            var hashCode = 680367543;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idStudent);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(idTeme);
            hashCode = hashCode * -1521134295 + nota.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(feedback);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(cadru_didactic);
            return hashCode;
        }

        public override string ToString()
        {
            return this.idStudent + " " + this.idTeme + " " + this.nota.ToString() + " " + this.feedback + " " + this.cadru_didactic;
        }

        public bool EqualsID(object obj)
        {
            var nota = obj as Nota;
            return nota != null &&
                   idStudent == nota.idStudent &&
                   idTeme == nota.idTeme;
        }
    }
}
