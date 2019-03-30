using lab3.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.ui
{
    class UI
    {
        public StudentService serS;
        public TemeService serT;
        public NotaService serN;

        public UI(StudentService serS, TemeService serT, NotaService serN)
        {
            this.serS = serS;
            this.serT = serT;
            this.serN = serN;
        }

        public void run()
        {
            ConsoleKeyInfo com, com2, com3, com4, comP;
            int curent;
            Console.WriteLine("Setati saptamana curenta: ");
            curent = int.Parse(Console.ReadLine());
            this.serN.saptamana_curenta = curent;
            this.serT.saptamana_curenta = curent;

            /*this.serS.add("1", "a", "1", "a@yahoo.com");
            this.serS.add("2", "b", "1", "b@yahoo.com");*/

            /*this.serT.add("1", "des1", 3, 3);
            this.serT.add("2", "des2", 5, 3);
            this.serT.add("3", "des3", 2, 3);*/

            /*this.serN.add("1", "3", 5, "feed1", "A");
            this.serN.add("2", "2", 2, "feed2", "A");*/

            while (true)
            {
                Console.WriteLine("****************");
                Console.WriteLine("* 1. Student   *");
                Console.WriteLine("* 2. Teme      *");
                Console.WriteLine("* 3. Note      *");
                Console.WriteLine("* 0. EXIT      *");
                Console.WriteLine("****************");
                Console.Write("Comanda: ");
                com = Console.ReadKey();
                Console.WriteLine();
                switch (com.KeyChar)
                {
                    case '1':
                        {
                            int ok = 1;
                            while (ok == 1)
                            {
                                Console.WriteLine("****************************");
                                Console.WriteLine("* 1. Adauga student        *");
                                Console.WriteLine("* 2. Sterge student        *");
                                Console.WriteLine("* 3. Modifica student      *");
                                Console.WriteLine("* 4. Find one              *");
                                Console.WriteLine("* 5. Find all              *");
                                Console.WriteLine("* 6. Size                  *");
                                Console.WriteLine("* 7. Nr. din fiecare grupa *");
                                Console.WriteLine("* 8. Note student          *");
                                Console.WriteLine("* 0. BACK                  *");
                                Console.WriteLine("****************************");
                                Console.Write("Comanda: ");
                                com2 = Console.ReadKey();
                                Console.WriteLine();
                                switch (com2.KeyChar)
                                {
                                    case '1':
                                        {
                                            String idStudent, nume, grupa, email;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            Console.WriteLine("Nume: ");
                                            nume = Console.ReadLine();
                                            Console.WriteLine("Grupa: ");
                                            grupa = Console.ReadLine();
                                            Console.WriteLine("Email: ");
                                            email = Console.ReadLine();
                                            this.serS.add(idStudent, nume, grupa, email);                                            
                                            break;
                                        }
                                    case '2':
                                        {
                                            String idStudent;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            this.serS.rem(idStudent);
                                            break;
                                        }
                                    case '3':
                                        {
                                            String idStudent, nume, grupa, email;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            Console.WriteLine("Nume: ");
                                            nume = Console.ReadLine();
                                            Console.WriteLine("Grupa: ");
                                            grupa = Console.ReadLine();
                                            Console.WriteLine("Email: ");
                                            email = Console.ReadLine();
                                            this.serS.upd(idStudent, nume, grupa, email);
                                            break;
                                        }
                                    case '4':
                                        {
                                            String idStudent;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            if (this.serS.findOne(idStudent) != null)
                                            {
                                                Console.WriteLine(this.serS.findOne(idStudent).ToString());
                                            }
                                            break;
                                        }
                                    case '5':
                                        {
                                            this.serS.filterS().ForEach(Console.WriteLine);
                                            break;
                                        }
                                    case '6':
                                        {
                                            Console.WriteLine(this.serS.size());
                                            break;
                                        }
                                    case '7':
                                        {
                                            this.serS.filterG().ForEach(x => {
                                                Console.WriteLine(">>     " + x.Key + "     " + x.Value.ToString());
                                            });
                                            break;
                                        }
                                    case '8':
                                        {
                                            String idStudent;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            this.serN.filterNaS(idStudent).ForEach(x => Console.WriteLine(">>    " + x.nota.ToString()));
                                            break;
                                        }
                                    case '0':
                                        {
                                            ok = 0;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Try again");
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case '2':
                        {
                            int ok = 1;
                            while (ok == 1)
                            {
                                Console.WriteLine("*********************************");
                                Console.WriteLine("* 1. Adauga tema                *");
                                Console.WriteLine("* 2. Sterge tema                *");
                                Console.WriteLine("* 3. Modifica tema              *");
                                Console.WriteLine("* 4. Modifica dead line tema    *");
                                Console.WriteLine("* 5. Find one                   *");
                                Console.WriteLine("* 6. Find all                   *");
                                Console.WriteLine("* 7. Size                       *");
                                Console.WriteLine("* 8. Dead line intre 2 perioade *");
                                Console.WriteLine("* 9. Note la o tema             *");
                                Console.WriteLine("* 0. BACK                       *");
                                Console.WriteLine("*********************************");
                                Console.Write("Comanda: ");
                                com3 = Console.ReadKey();
                                Console.WriteLine();
                                switch (com3.KeyChar)
                                {
                                    case '1':
                                        {
                                            String numar_tema, descriere;
                                            int dead_line, primire;
                                            Console.WriteLine("Numar tema: ");
                                            numar_tema = Console.ReadLine();
                                            Console.WriteLine("Descriere: ");
                                            descriere = Console.ReadLine();
                                            Console.WriteLine("Dead line: ");
                                            dead_line = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Primire: ");
                                            primire = int.Parse(Console.ReadLine());
                                            this.serT.add(numar_tema, descriere, dead_line, primire);
                                            break;
                                        }
                                    case '2':
                                        {
                                            String numar_tema;
                                            Console.WriteLine("Numar teme: ");
                                            numar_tema = Console.ReadLine();
                                            this.serT.rem(numar_tema);
                                            break;
                                        }
                                    case '3':
                                        {
                                            String numar_tema, descriere;
                                            int dead_line, primire;
                                            Console.WriteLine("Numar tema: ");
                                            numar_tema = Console.ReadLine();
                                            Console.WriteLine("Descriere: ");
                                            descriere = Console.ReadLine();
                                            Console.WriteLine("Dead line: ");
                                            dead_line = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Primire: ");
                                            primire = int.Parse(Console.ReadLine());
                                            this.serT.upd(numar_tema, descriere, dead_line, primire);
                                            break;
                                        }
                                    case '4':
                                        {
                                            String numar_tema;
                                            Console.WriteLine("Numar teme: ");
                                            numar_tema = Console.ReadLine();
                                            if (this.serT.findOne(numar_tema) != null)
                                            {
                                                this.serT.updDead_line(numar_tema);
                                            }
                                            break;
                                        }
                                    case '5':
                                        {
                                            String numar_tema;
                                            Console.WriteLine("Numar tema: ");
                                            numar_tema = Console.ReadLine();
                                            if (this.serT.findOne(numar_tema) != null)
                                            {
                                                Console.WriteLine(this.serT.findOne(numar_tema).ToString());
                                            }
                                            break;
                                        }
                                    case '6':
                                        {
                                            this.serT.filterT().ForEach(Console.WriteLine);
                                            break;
                                        }
                                    case '7':
                                        {
                                            Console.WriteLine(this.serT.size());
                                            break;
                                        }
                                    case '8':
                                        {
                                            int star, end;

                                            Console.WriteLine("Star: ");
                                            star = int.Parse(Console.ReadLine());
                                            Console.WriteLine("End: ");
                                            end = int.Parse(Console.ReadLine());

                                            this.serT.filterD(star, end).ForEach(x => {
                                                Console.WriteLine(">>     " + x.Key + "     " + x.Value.ToString());
                                            });
                                            break;
                                        }
                                    case '9':
                                        {
                                            String numar_tema;
                                            Console.WriteLine("Numar teme: ");
                                            numar_tema = Console.ReadLine();

                                            Console.WriteLine("********************");
                                            Console.WriteLine("* 1. Din total     *");
                                            Console.WriteLine("* 2. Dintr-o grupa *");
                                            Console.WriteLine("* 0. BACK          *");
                                            Console.WriteLine("********************");
                                            Console.Write("Comanda: ");
                                            comP = Console.ReadKey();
                                            Console.WriteLine();
                                            switch (comP.KeyChar)
                                            {
                                                case '1':
                                                    {
                                                        this.serN.filterNaT(numar_tema).ForEach(x => Console.WriteLine(">>    " + x.nota.ToString()));
                                                        break;
                                                    }
                                                case '2':
                                                    {
                                                        String grupa;
                                                        Console.WriteLine("Grupa: ");
                                                        grupa = Console.ReadLine();
                                                        this.serN.filterNaG(numar_tema, grupa).ForEach(x => Console.WriteLine(">>    " + x.nota.ToString()));
                                                        break;
                                                    }
                                                case '0':
                                                    {
                                                        ok = 0;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        Console.WriteLine("Try again");
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case '0':
                                        {
                                            ok = 0;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Try again");
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case '3':
                        {
                            int ok = 1;
                            while (ok == 1)
                            {
                                Console.WriteLine("************************");
                                Console.WriteLine("* 1. Adauga nota       *");
                                Console.WriteLine("* 2. Sterge nota       *");
                                Console.WriteLine("* 3. Modifica nota     *");
                                Console.WriteLine("* 4. Find one          *");
                                Console.WriteLine("* 5. Find all          *");
                                Console.WriteLine("* 6. Size              *");
                                Console.WriteLine("* 7. Nota maxima       *");
                                Console.WriteLine("* 8. Notelor rotunjite *");
                                Console.WriteLine("* 9. Grila note grupa  *");
                                Console.WriteLine("* 0. BACK              *");
                                Console.WriteLine("************************");
                                Console.Write("Comanda: ");
                                com4 = Console.ReadKey();
                                Console.WriteLine();
                                switch (com4.KeyChar)
                                {
                                    case '1':
                                        {
                                            String idStudent, numar_tema, feedback, cadru_didactic;
                                            double nota;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            Console.WriteLine("Numar tema: ");
                                            numar_tema = Console.ReadLine();
                                            Console.WriteLine("Nota: ");
                                            nota = double.Parse(Console.ReadLine());
                                            Console.WriteLine("Feedback: ");
                                            feedback = Console.ReadLine();
                                            Console.WriteLine("Cadru didactic: ");
                                            cadru_didactic = Console.ReadLine();
                                            this.serN.add(idStudent, numar_tema, nota, feedback, cadru_didactic);
                                            break;
                                        }
                                    case '2':
                                        {
                                            String idStudent, numar_tema;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            Console.WriteLine("Numar tema: ");
                                            numar_tema = Console.ReadLine();
                                            this.serN.rem(idStudent, numar_tema);
                                            break;
                                        }
                                    case '3':
                                        {
                                            String idStudent, numar_tema, feedback, cadru_didactic;
                                            double nota;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            Console.WriteLine("Numar tema: ");
                                            numar_tema = Console.ReadLine();
                                            Console.WriteLine("Nota: ");
                                            nota = double.Parse(Console.ReadLine());
                                            Console.WriteLine("Feedback: ");
                                            feedback = Console.ReadLine();
                                            Console.WriteLine("Cadru didactic: ");
                                            cadru_didactic = Console.ReadLine();
                                            this.serN.upd(idStudent, numar_tema, nota, feedback, cadru_didactic);
                                            break;
                                        }
                                    case '4':
                                        {
                                            String idStudent, numar_tema;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            Console.WriteLine("Numar tema: ");
                                            numar_tema = Console.ReadLine();
                                            if (this.serN.findOne(idStudent, numar_tema) != null)
                                            {
                                                Console.WriteLine(this.serN.findOne(idStudent, numar_tema).ToString());
                                            }
                                            break;
                                        }
                                    case '5':
                                        {
                                            this.serN.filterN().ForEach(Console.WriteLine);
                                            break;
                                        }
                                    case '6':
                                        {
                                            Console.Write("Size: ");
                                            Console.WriteLine(this.serN.size());
                                            break;
                                        }
                                    case '7':
                                        {
                                            String idStudent, numar_tema;
                                            Console.WriteLine("ID: ");
                                            idStudent = Console.ReadLine();
                                            Console.WriteLine("Numar tema: ");
                                            numar_tema = Console.ReadLine();
                                            Console.Write("Nota maxima e: ");
                                            Console.WriteLine(this.serN.nota_max(this.serN.findOne(idStudent, numar_tema).nota, numar_tema, this.serT.saptamana_curenta));
                                            break;
                                        }
                                    case '8':
                                        {
                                            this.serN.filterNo().ForEach(x =>
                                            {
                                                Console.WriteLine(">>     " + (x.Key - 1).ToString() + ".50 - " + x.Key.ToString() + ".50      " + x.Value);
                                            });
                                            break;
                                        }
                                    case '9':
                                        {
                                            string grupa;
                                            Console.WriteLine("Grupa: ");
                                            grupa = Console.ReadLine();
                                            string s = "Grupa " + grupa;
                                            this.serT.findAll().ForEach(x => s = s + "          Tema " + x.Id);
                                            s = s + "\n";
                                            this.serS.filterSG(grupa).ForEach(x =>
                                            {
                                                s = s + x.nume + "  ";
                                                this.serT.findAll().ForEach(y =>
                                                {
                                                    if(this.serN.findOneNaOG(x.Id, y.Id, grupa) == 1)
                                                    {
                                                        s = s + "              " + this.serN.findOne(x.Id, y.Id).nota.ToString();
                                                    }
                                                    else
                                                    {
                                                        s = s + "              0";
                                                    }
                                                });
                                                s = s + "\n";
                                            });
                                            Console.WriteLine(s);
                                            break;
                                        }
                                    case '0':
                                        {
                                            ok = 0;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Try again");
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case '0':
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Try again");
                            break;
                        }
                }
            }
        }
    }
}
