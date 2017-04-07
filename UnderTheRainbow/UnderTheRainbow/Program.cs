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
        private static int totalRows;
        private static int[] doorsToClose;
        private static int[ , ] values;
        private static int total = 0;
        
        static void Main(string[] args)
        {
            var sr = new StringReader("6 4\n" +
                                      "3 1\n" +
                                      "2 1\n" +
                                      "1 2\n" +
                                      "1 3\n" +
                                      "3 3\n" +
                                      "0 0\n");
            Console.SetIn(sr);

            string startup = Console.ReadLine();
            string[] startupTokens = startup.Split(' ');

            int totalRows = int.Parse(startupTokens[0]);
            int doorsToClose = int.Parse(startupTokens[1]);

            values = new int[totalRows, 2];

            for (int i = 0; i < totalRows; i++)
            {
                string s = Console.ReadLine();
                string[] tokens = s.Split(' ');
                values[i, 0] = int.Parse(tokens[0]);
                values[i, 1] = int.Parse(tokens[1]);
            }

            Console.WriteLine(maxValue(0, -1, doorsToClose));

            Console.Read();
        }
        private static int maxValue(int r, int unclosedRoom, int k)
        {
            if(r == totalRows - 1)
            {
                return total;
            }
            if(unclosedRoom == -1)
            {
                total = values[r, 0] + values[r, 1] + maxValue(r + 1, -1, k);
            }
            if(unclosedRoom == 0)
            {

            }
            if(unclosedRoom == 1)
            {

            }
        }
    }

    
}
