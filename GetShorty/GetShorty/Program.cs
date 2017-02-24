using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetShorty
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(3);

            g.addEdge(0, 1, 0.9f);
            g.addEdge(1, 2, 0.9f);
            g.addEdge(0, 2, 0.8f);

            g.printGraph();

            Console.Read();
        }

        class Graph
        {
            LinkedList<Tuple<int, float>>[] adjacencyList;

            public Graph(int intersections)
            {
                adjacencyList = new LinkedList<Tuple<int, float>>[intersections];
            }

            public void addEdge(int x, int y, float f)
            {
                if(adjacencyList[x] == null)
                    adjacencyList[x] = new LinkedList<Tuple<int, float>>();

                if (adjacencyList[y] == null)
                    adjacencyList[y] = new LinkedList<Tuple<int, float>>();

                Tuple<int, float> intersection1 = new Tuple<int, float>(y, f);
                adjacencyList[x].AddLast(intersection1);

                Tuple<int, float> intersection2 = new Tuple<int, float>(x, f);
                adjacencyList[y].AddLast(intersection2);
            }

            public void printGraph()
            {
                int count = 0;
                foreach (LinkedList<Tuple<int, float>> intersection in adjacencyList)
                {
                    Console.Write("[" + count + "]");
                    foreach (Tuple<int, float> edge in intersection)
                    {
                        Console.Write(" --> " + " <" + edge.Item1 + ", " + edge.Item2 + "> ");
                    }
                    Console.WriteLine();
                    count++;
                }
            }

            public void findBestPath()
            {
                int[] prev;
                int[] weight;

                for(int i = 0; i < adjacencyList.Count(); i++)
                {
                    //prev[i] = -1;
                    //weight[i] = null;
                }
            }
        }

    }

    class Intersection
    {
        public bool visited;
        public int number;

        public Intersection(bool visited, int number)
        {
            this.visited = visited;
            this.number = number;
        }
    }

}
