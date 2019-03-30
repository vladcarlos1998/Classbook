using lab3.obiecte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.validator
{
    public class StudentValidation : IValidator<Student>
    {
        public void Validate(Student e)
        {
            if (e.Id == null)
            {
                throw new ValidationException("Student id e null");
            }
            if (e.Id == "")
            {
                throw new ValidationException("Student id is missing");
            }
            if (e.nume == null)
            {
                throw new ValidationException("Student nume e null");
            }
            if (e.nume == "")
            {
                throw new ValidationException("Student id is missing");
            }
            if (e.grupa == null)
            {
                throw new ValidationException("Student grupa e null");
            }
            if (e.grupa == "")
            {
                throw new ValidationException("Student grupa is missing");
            }
            if (e.email == null)
            {
                throw new ValidationException("Student email e null");
            }
            if (e.email == "")
            {
                throw new ValidationException("Student email is missing");
            }
        }
    }
}
