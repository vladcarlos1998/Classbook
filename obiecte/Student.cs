using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.obiecte
{
    public class Student : HasID<string>, IComparable<Student>
    {
        public Student(string id, string nume, string grupa, string email)
        {
            this.Id = id;
            this.nume = nume;
            this.grupa = grupa;
            this.email = email;
        }

        public string Id { get; set; }
        public string nume { get; set; }
        public string grupa { get; set; }
        public string email { get; set; }

        public int CompareTo(Student other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   Id == student.Id &&
                   nume == student.nume &&
                   grupa == student.grupa &&
                   email == student.email;
        }

        public override int GetHashCode()
        {
            var hashCode = -2109590583;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nume);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(grupa);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            return hashCode;
        }

        public override string ToString()
        {
            return Id + " " + this.nume + " " + this.grupa + " " + this.email;
        }
    }
}
