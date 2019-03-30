using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.obiecte
{
    public class Compare :IComparer<Student>
    {
        int IComparer<Student>.Compare(Student x, Student y)
        {
            return int.Parse(x.Id).CompareTo(int.Parse(y.Id));
        }
    }
}
