using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ02_ZD08
{
    class Program
    {
        static void Main(string[] args)
        { // Main method is the only method that
          // can’t be marked with async.
          // What we are doing here is just a way for us to simulate
          // async-friendly environment you usually have with 
          // other .NET application types (like web apps, win apps etc.) 
          // Ignore main method, you can just focus on LetsSayUserClickedAButtonOnGuiMethod() as a 
          // first method in call hierarchy. 
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static int GetTheMagicNumber()
        {
            return IKnowIGuyWhoKnowsAGuy().Result;
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            Task<int> t1 = Task.Run(() => IKnowWhoKnowsThis(10));
            Task<int> t2 = Task.Run(() => IKnowWhoKnowsThis(5));
            await Task.WhenAll(t1, t2);

            return t1.Result + t2.Result;
        }

        static async Task<int> IKnowWhoKnowsThis(int n)
        {
            Task<int> t3 = Task.Run(() => FactorialDigitSum(n));
            await t3;

            return t3.Result;
        }

        //------------FactorialDigitSum---------------
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
