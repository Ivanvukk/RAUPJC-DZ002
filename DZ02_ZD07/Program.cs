using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DZ02_ZD07
{
    class Program
    {
        static void Main(string[] args)
        {

            //Task<int> factorialDigitSum;

           

            Console.Write(FactorialDigitSum(4).Result);
            Console.ReadLine();

        }

        static async Task<int> FactorialDigitSum(int n)
        {
            Task<int> tFac = Task.Run(() => Factorial(n));
            await tFac;
            Task<int> tSum = Task.Run(() => DigitSum(tFac.Result));
            await tSum;

            return tSum.Result;

        }

        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result = result * i;
            }
            return result;
        }

        static int DigitSum(int n)
        {
            int sum = 0;

            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

    }
}
