using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ02_ZD03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new[] { 10, 24, 24, 2, 3, 3, 6, 5, 0 };

            string[] strings = integers.GroupBy(element => element)
                                        .OrderBy(element => element.Count())   
                                        .Select(element => string.Format("Broj {0} ponavlja se {1} puta.", element.Key, element.Count()))
                                        .ToArray();
                          
            Console.ReadLine();   
                
        }
    }
}