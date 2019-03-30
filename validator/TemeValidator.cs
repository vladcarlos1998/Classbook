using lab3.obiecte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.validator
{
    public class TemeValidator : IValidator<Teme>
    {
        public void Validate(Teme e)
        {
            if (e.Id == null)
            {
                throw new ValidationException("Tema numar e null");
            }
            if (e.Id == "")
            {
                throw new ValidationException("Tema numar is missing");
            }
            if (e.descriere == null)
            {
                throw new ValidationException("Tema descriere e null");
            }
            if (e.descriere == "")
            {
                throw new ValidationException("Tema descriere is missing");
            }
            if (e.dead_line <= 0 || e.dead_line > 14)
            {
                throw new ValidationException("Tema dead line invlid");
            }
            if (e.primire <= 0 || e.primire > 14)
            {
                throw new ValidationException("Tema primire invalid");
            }
        }
    }
}
