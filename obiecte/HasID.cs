using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.obiecte
{
    public interface HasID<ID>
    {
        ID Id { get; set; }
    }
}
