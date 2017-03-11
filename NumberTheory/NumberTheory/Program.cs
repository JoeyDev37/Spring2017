using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s;
            //while((s = Console.ReadLine()) != null)
            //{
            //    string[] tokens = s.Split(' ');

            //}
            Console.WriteLine(isPrime(13));
            Console.Read();
        }

        private static long gcd(long a, long b)
        {
            if (b == 0)
                return a;
            else
                return gcd(b, a % b);
        }
        private static long exp(long a, long b, long c)
        {
            double result = Math.Pow(a, b) % c; ;
            return (long)result; 
        }

        private static string inverse(long a, long N)
        {
            long[] result = ee(a, N);
            if (result[2] == 1)
                return (result[0] % N).ToString();
            else
                return "none";
        }
        private static string isPrime(long N)
        {
            if (N == 1)
            { // 1 isn't prime
                return "no";
            }
            for (int i = 0; i < 5; i++)
            {
                // choose a random integer between 1 and p-1 ( inclusive )
                long a = rand() % (p - 1) + 1;
                // modulo is the function we developed above for modular exponentiation.
                if (modulo(a, p - 1, p) != 1)
                {
                    return false; /* p is definitely composite */
                }
            }
            return true; /* p is probably prime */
        }
        //private static int key(int val1, int val2)
        //{

        //}

        private static long[] ee(long a, long b)
        {
            long[] result = new long[3];
            if (b == 0)
            {
                result[0] = 1;
                result[1] = 0;
                result[2] = a;
                return result;
            }
            else
            {
                long[] result2 = ee(b, a % b);
                result[0] = result2[1];
                result[1] = result2[0] - (a / b) * result2[1];
                result[2] = result2[2];
                return result;
            }
        }  
    }

    
}
