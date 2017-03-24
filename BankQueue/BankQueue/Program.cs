using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankQueue
{
    class Program
    {
        private static SortedDictionary<int, SortedList<int, int>> people = new SortedDictionary<int, SortedList<int, int>>();
        private static int targetTime;
        private static int currentTime = 0;
        private static int totalMoney;
        static void Main(string[] args)
        {
            var sr = new StringReader("4 4\n" +
                                      "5 0\n" +
                                      "25 1\n" +
                                      "10 2\n" +
                                      "15 2\n");
            Console.SetIn(sr);

            string startupInfo = Console.ReadLine();
            string[] startupTokens = startupInfo.Split(' ');
            targetTime = int.Parse(startupTokens[1]);
             
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                string[] tokens = s.Split(' ');
                int time = int.Parse(tokens[1]);
                int money = int.Parse(tokens[0]);

                if (people.ContainsKey(time))
                {
                    people[time].Add(-money, money);
                }
                else
                {
                    SortedList<int, int> list = new SortedList<int, int>();
                    list.Add(-money, money);
                    people.Add(time, list);
                }
            }

            FindTotal();
            Console.WriteLine(totalMoney);
            Console.Read();
        }

        private static void FindTotal()
        {
            while(currentTime != targetTime)
            {
                foreach (KeyValuePair<int, SortedList<int, int>> entry in people)
                {
                    if (entry.Key < currentTime)
                        continue;
                    else
                    {
                        if(entry.Value.Count == 1)
                        {
                            totalMoney += entry.Value.First().Value;
                            people.Remove(entry.Key);
                            break;
                        }
                        else
                        {
                            totalMoney += entry.Value.First().Value;
                            entry.Value.RemoveAt(0);
                            break;
                        }
                    }
                }
                currentTime++;
            }
        }
    }

    //class Person
    //{
    //    public int money;
    //    public int time;

    //    public Person(int money, int time)
    //    {
    //        this.money = money;
    //        this.time = time;
    //    }
    //}
}
