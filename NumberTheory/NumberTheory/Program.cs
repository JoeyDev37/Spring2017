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
            Console.WriteLine(gcd(2345527849052734077, 2348570293847502555));
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

        //private static string inverse(int a, int b)
        //{
            
        //}
        //private static bool isPrime(int a)
        //{

        //}
        //private static int key(int val1, int val2)
        //{

        //}

        //private long[] ee(long a, long b)
        //{
        //    long d = gcd(a, b);
        //    long[] result;
        //    result = ee(b, a);
        //    result =
        //}
    }
}
