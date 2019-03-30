using lab3.obiecte;
using lab3.repository;
using lab3.service;
using lab3.ui;
using lab3.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            main_ui();
            return;
        }

        public static void main_ui()
        {
            //Student s1 = new Student("1", "a", "1", "a@yahoo.com");
            //Student s2 = new Student("2", "b", "1", "b@yahoo.com");
            IValidator<Student> validatorS = new StudentValidation();
            //IRepository<string, Student> repoS = new AbstractCRUDRepo<string, Student>(validatorS);
            IRepository<string, Student> repoS = new StudentRepoFile(validatorS, "C:\\Users\\HP\\Desktop\\MAP\\lab3\\lab3\\data\\Student.txt");

            //repoS.add(s1);
            //repoS.add(s2);

            StudentService serS = new StudentService(repoS);

            /*serS.add("1", "a", "1", "a@yahoo.com");
            serS.add("2", "b", "1", "b@yahoo.com");

            serS.findAll().ForEach(Console.WriteLine);*/

            //Teme t1 = new Teme("1", "des1", 3, 3);
            //Teme t2 = new Teme("2", "des2", 5, 3);
            //Teme t3 = new Teme("3", "des3", 2, 3);
            IValidator<Teme> validatorT = new TemeValidator();
            /*IRepository<string, Teme> repoT = new AbstractCRUDRepo<string, Teme>(validatorT);*/
            IRepository<string, Teme> repoT = new TemeRepoFile(validatorT, "C:\\Users\\HP\\Desktop\\MAP\\lab3\\lab3\\data\\Teme.txt");

            //repoT.add(t1);
            //repoT.add(t2);
            //repoT.add(t3);

            TemeService serT = new TemeService(repoT);

            /*serT.add("1", "des1", 3, 3);
            serT.add("2", "des2", 5, 3);
            serT.add("3", "des3", 2, 3);

            serT.findAll().ForEach(Console.WriteLine);*/

            //Nota n1 = new Nota("1", "3", 5, "feed1", "A");
            //Nota n2 = new Nota("2", "2", 2, "feed2", "A");
            //NoteRepository repoN = new NoteRepository();
            NoteRepository repoN = new NoteRepoFile("C:\\Users\\HP\\Desktop\\MAP\\lab3\\lab3\\data\\Note.txt");

            //repoN.add(n1);
            //repoN.add(n2);

            NotaService serN = new NotaService(repoS, repoT, repoN);

            /*serN.add("1", "3", 5, "feed1", "A");
            serN.add("2", "2", 2, "feed2", "A");

            serN.findAll().ForEach(Console.WriteLine);*/

            UI ui = new UI(serS, serT, serN);
            ui.run();
        }
    }
}
