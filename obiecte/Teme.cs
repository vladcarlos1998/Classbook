using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.obiecte
{
    public class Teme : HasID<string>, IComparable<Teme>
    {
        public Teme(string id, string descriere, int dead_line, int primire)
        {
            Id = id;
            this.descriere = descriere;
            this.dead_line = dead_line;
            this.primire = primire;
        }

        public string Id { get; set; }
        public string descriere { get; set; }
        public int dead_line { get; set; }
        public int primire { get; set; }

        public int CompareTo(Teme other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override bool Equals(object obj)
        {
            var teme = obj as Teme;
            return teme != null &&
                   Id == teme.Id &&
                   descriere == teme.descriere &&
                   dead_line == teme.dead_line &&
                   primire == teme.primire;
        }

        public override int GetHashCode()
        {
            var hashCode = -97835880;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(descriere);
            hashCode = hashCode * -1521134295 + dead_line.GetHashCode();
            hashCode = hashCode * -1521134295 + primire.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return this.Id + " " + this.descriere + " " + this.dead_line + " " + this.primire;
        }

        public void updDead_line(int curent)
        {
            if(this.dead_line > curent)
            {
                this.dead_line = curent + 1;
            }
        }
    }
}
