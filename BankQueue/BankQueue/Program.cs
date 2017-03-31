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
        private static int totalMoney;
        private static int[] schedule;
        private static List<Person> people = new List<Person>();
        private static int time;
        private static int money;
        static void Main(string[] args)
        {
            Console.ReadLine();

            schedule = new int[47];
             
            string s;
            while ((s = Console.ReadLine()) != null)
            {
                string[] tokens = s.Split(' ');
                time = int.Parse(tokens[1]);
                money = int.Parse(tokens[0]);
                Person p = new Person(money, time);

                people.Add(p);
            }

            people.Sort();

            foreach(Person p in people)
            {
                for (int i = p.time; i >= 0; i--)
                {
                    if (schedule[i] < p.money)
                    {
                        schedule[i] = p.money;
                        break;
                    }
                }
            }

            for(int i = 0; i < schedule.Count(); i++)
            {
                totalMoney += schedule[i];
            }

            Console.WriteLine(totalMoney);
        }
    }

    class Person : IComparable<Person>
    {
        public int money;
        public int time;

        public Person(int money, int time)
        {
            this.money = money;
            this.time = time;
        }

        public int CompareTo(Person other)
        {
            if (other.money < money)
                return -1;
            else if (other.money > money)
                return 1;
            else
                return 0;
        }
    }
}
