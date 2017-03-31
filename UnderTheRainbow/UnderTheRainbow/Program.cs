using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderTheRainbow
{
    class Program
    {
        private static int[] hotels;
        static void Main(string[] args)
        {
            var sr = new StringReader("3\n" +
                                      "0\n" +
                                      "350\n" +
                                      "450\n" +
                                      "825\n");
            Console.SetIn(sr);

            int totalStops = int.Parse(Console.ReadLine()) + 1;
            hotels = new int[totalStops];

            for(int i = 0; i < totalStops; i++)
            {
                hotels[i] = int.Parse(Console.ReadLine());
            }

            Console.Read();
        }

        public static void penalty(int hotel)
        {

        }
    }
}
