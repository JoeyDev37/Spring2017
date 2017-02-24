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

        }

        class Graph
        {
            LinkedList<Tuple<int, float>>[] adjacencyList;

            public Graph(int intersections)
            {
                adjacencyList = new LinkedList<Tuple<int, float>>[intersections];
            }

            public void addIntersections(int val)
            {

            }

            public void addEdge(int x, int y, float f)
            {

            }
        }

    }
}
