using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNamespace
{
    


    public class GetAllCroatianUniversities
    {
        readonly List<University> _inMemoryTodoDatabase = new List<University>();

        //PREČUDNO!!! sve studente u listi prebriše s onima iz zadnjeg sveucilista
        public List<University> Fillup()
        {
            var univ = new University();
            var univ2 = new University();
            var univ3 = new University();
            var univ4 = new University();

            var stud1 = new Student("IvanZG", "00");
            var stud2 = new Student("MarkoZG", "01");
            var stud3 = new Student("AlenZG", "02");
            var stud4 = new Student("MatejZG", "03");
            var stud5 = new Student("MarinaOS", "34");

            Student[] students = new Student[5];

            students[0] = stud1;
            students[1] = stud2;
            students[2] = stud3;
            students[3] = stud4;

            univ.Name = "Zagreb";
            univ.Students = students;
            _inMemoryTodoDatabase.Add(univ);
            univ2.Name = "Split";
            univ2.Students = students;
            _inMemoryTodoDatabase.Add(univ2);
            univ3.Name = "Zadar";
            univ3.Students = students;
            _inMemoryTodoDatabase.Add(univ3);
            univ4.Name = "Osijek";
            students[4] = stud5;
            univ4.Students = students;
            _inMemoryTodoDatabase.Add(univ4);
            _inMemoryTodoDatabase[0].Students[0].Name = "IvanZG";
            _inMemoryTodoDatabase[0].Students[1].Name = "MarkoZG";
            _inMemoryTodoDatabase[0].Students[2].Name = "AlenZG";
            _inMemoryTodoDatabase[0].Students[3].Name = "MatejZG";
            _inMemoryTodoDatabase[1].Students[0].Name = "IvanST";
            _inMemoryTodoDatabase[1].Students[1].Name = "MarkoST";
            _inMemoryTodoDatabase[1].Students[2].Name = "AlenST";
            _inMemoryTodoDatabase[1].Students[3].Name = "MatejST";
            _inMemoryTodoDatabase[2].Students[0].Name = "IvanZG";
            _inMemoryTodoDatabase[2].Students[1].Name = "MarkoZD";
            _inMemoryTodoDatabase[2].Students[2].Name = "AlenZD";
            _inMemoryTodoDatabase[2].Students[3].Name = "MatejZD";
            _inMemoryTodoDatabase[3].Students[0].Name = "IvanOS";
            _inMemoryTodoDatabase[3].Students[1].Name = "MarkoOS";
            _inMemoryTodoDatabase[3].Students[2].Name = "AlenOS";
            _inMemoryTodoDatabase[3].Students[3].Name = "MatejOS";
            _inMemoryTodoDatabase[3].Students[4].Name = "MarinaOS";

            _inMemoryTodoDatabase[0].Students[0].Jmbag = "00";
            _inMemoryTodoDatabase[0].Students[1].Jmbag = "01";
            _inMemoryTodoDatabase[0].Students[2].Jmbag = "02";
            _inMemoryTodoDatabase[0].Students[3].Jmbag = "03";
            _inMemoryTodoDatabase[1].Students[0].Jmbag = "10";
            _inMemoryTodoDatabase[1].Students[1].Jmbag = "11";
            _inMemoryTodoDatabase[1].Students[2].Jmbag = "12";
            _inMemoryTodoDatabase[1].Students[3].Jmbag = "13";
            _inMemoryTodoDatabase[2].Students[0].Jmbag = "20";
            _inMemoryTodoDatabase[2].Students[1].Jmbag = "21";
            _inMemoryTodoDatabase[2].Students[2].Jmbag = "22";
            _inMemoryTodoDatabase[2].Students[3].Jmbag = "23";
            _inMemoryTodoDatabase[3].Students[0].Jmbag = "30";
            _inMemoryTodoDatabase[3].Students[1].Jmbag = "31";
            _inMemoryTodoDatabase[3].Students[2].Jmbag = "32";
            _inMemoryTodoDatabase[3].Students[3].Jmbag = "33";
            _inMemoryTodoDatabase[3].Students[4].Jmbag = "34";
         /*  stud1.Name = "IvanST";
            stud1.Jmbag = "10";
            stud2.Name = "MarkoST";
            stud2.Jmbag = "11";
            stud3.Name = "AlenST";
            stud3.Jmbag = "12";
            stud4.Name = "MatejST";
            stud4.Jmbag = "13";

            stud1.Name = "IvanZG";
            stud1.Jmbag = "00";
            stud2.Name = "MarkoZD";
            stud2.Jmbag = "21";
            stud3.Name = "AlenZD";
            stud3.Jmbag = "22";
            stud4.Name = "MatejZD";
            stud4.Jmbag = "23";

            students[0] = stud1;
            students[1] = stud2;
            students[2] = stud3;
            students[3] = stud4;

            univ3.Name = "Zadar";
            univ3.Students = students;
            _inMemoryTodoDatabase.Add(univ3);

            stud1.Name = "IvanOS";
            stud1.Jmbag = "30";
            stud2.Name = "MarkoOS";
            stud2.Jmbag = "31";
            stud3.Name = "AlenOS";
            stud3.Jmbag = "32";
            stud4.Name = "MatejOS";
            stud4.Jmbag = "33";*/


            return _inMemoryTodoDatabase;
        }
    }
}

