using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ02_ZD04
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567")
            };

            var ivan = new Student("Ivan", jmbag: "001234567");


            bool anyIvanExists = list.Exists(s => s == ivan);

            /*var list = new List<Student>()
            {
                new Student("Ivan", jmbag: "001234567"),
                new Student("Ivan", jmbag: "001234567")
            };

            // 1 :) 
            var distinctStudents = list.Distinct().Count();*/


            Console.ReadLine();
        }
    }
}
