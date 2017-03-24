using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sr = new StringReader("gcd 6 15\n" +
            //                          "gcd 2 13\n" +
            //                          "exp 6 5 7\n" +
            //                          "inverse 7 13\n" +
            //                          "inverse 6 9\n" +
            //                          "isprime 13\n" +
            //                          "isprime 10\n" +
            //                          "key 2 7\n" +
            //                          "key 5 3\n");
            //Console.SetIn(sr);

            string s;
            while ((s = Console.ReadLine()) != null)
            {
                string[] tokens = s.Split(' ');
                if (tokens[0] == "gcd")
                {
                    long a = long.Parse(tokens[1]);
                    long b = long.Parse(tokens[2]);
                    Console.WriteLine(gcd(a, b));
                    continue;
                }
                if (tokens[0] == "exp")
                {
                    long a = long.Parse(tokens[1]);
                    long b = long.Parse(tokens[2]);
                    long c = long.Parse(tokens[3]);
                    Console.WriteLine(modexp(a, b, c));
                    continue;
                }
                if (tokens[0] == "inverse")
                {
                    long a = long.Parse(tokens[1]);
                    long b = long.Parse(tokens[2]);
                    Console.WriteLine(inverse(a, b));
                    continue;
                }
                if (tokens[0] == "isprime")
                {
                    long a = long.Parse(tokens[1]);
                    Console.WriteLine(isPrime(a));
                    continue;
                }
                if (tokens[0] == "key")
                {
                    long a = long.Parse(tokens[1]);
                    long b = long.Parse(tokens[2]);
                    Console.WriteLine(key(a, b));
                    continue;
                }
            }

            //Console.WriteLine(key(3, 11));
            //Console.Read();
        }

        private static long gcd(long a, long b)
        {
            if (b == 0)
                return a;
            else
                return gcd(b, a % b);
        }
        private static long modexp(long x, long y, long N)
        {
            long result = 1;

            while (y > 0)
            {
                if ((y & 1) == 1)
                {
                    // multiply in this bit's contribution while using modulus to keep result small
                    result = (result * x) % N;
                }
                // move to the next bit of the exponent, square (and mod) the base accordingly
                y >>= 1;
                x = (x * x) % N;
            }

            return result;
        }

        private static string inverse(long a, long N)
        {
            long answer;
            long[] result = ee(a, N);
            if (result[2] == 1)
            {
                answer = long.Parse((result[0] % N).ToString());
                if (answer < 0)
                    return (answer + N).ToString();
                else
                    return (result[0] % N).ToString();
            }
            else
                return "none";
        }
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
                result[1] = (result2[0] - (a / b) * result2[1]);
                result[2] = result2[2];
                return result;
            }
        }
        /* Fermat's test for checking primality, the more iterations the more is accuracy */
        private static string isPrime(long n)
        {
            if (n == 1)
            { // 1 isn't prime
                return "no";
            }
            for (int i = 0; i < 2; i++)
            {
                // choose a random integer between 1 and p-1 ( inclusive )
                Random random = new Random();
                long a = LongRandom(1, n - 2, random);
                // modulo is the function we developed above for modular exponentiation.
                if (modexp(a, n - 1, n) != 1)
                {
                    return "no"; /* p is definitely composite */
                }
            }
            return "yes"; /* p is probably prime */
        }

        private static long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        private static string key(long a, long b)
        {
            long modulus = checked(a * b);
            long phi = checked((a - 1) * (b - 1));
            long publicExponent = 0;
            long privateExponent = 0;
            for (int i = 2; i < phi; i++)
            {
                if (gcd(i, phi) == 1)
                {
                    publicExponent = i;
                    break;
                }
            }
            long inv = (long.Parse(inverse(publicExponent, phi)));

            privateExponent = inv;
            
            return modulus.ToString()  + " " + publicExponent.ToString() + " " + privateExponent.ToString();
        }

         
    }

    
}
