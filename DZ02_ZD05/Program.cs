using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyNamespace;


namespace DZ02_ZD05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GetAllCroatianUniversities All = new GetAllCroatianUniversities();

            List<University> universities = All.Fillup();

            Student[] allCroatianStudents = universities.SelectMany(x => x.Students)
                                                        .Distinct()
                                                        .ToArray();


            Student[] croatianStudentsOnMultipleUniversities = universities.SelectMany(x => x.Students)
                                                                           .ToArray()
                                                                           .GroupBy(y => y)
                                                                           .Where(y => y.Count() > 1)
                                                                           .Select(y => y.Key)
                                                                           .ToArray();
            //Student[] studentsOnMaleOnlyUniversities;
            //Neće :/
         
            







            Console.ReadLine();
        }
    }
}
