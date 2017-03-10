using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetShorty
{
    class Program
    {
        public static int numIntersections;
        public static int numEdges;
        static void Main(string[] args)
        {
            string startup;

            startup = Console.ReadLine();
            while (startup != "0 0")
            {
                string[] tokens = startup.Split(' ');

                numIntersections = int.Parse(tokens[0]);
                numEdges = int.Parse(tokens[1]);

                Graph g = new Graph(numIntersections);

                for (int i = 0; i < numEdges; i++)
                {
                    string info = Console.ReadLine();
                    string[] infoTokens = info.Split(' ');
                    int intersection1;
                    int.TryParse(infoTokens[0], out intersection1);
                    int intersection2;
                    int.TryParse(infoTokens[1], out intersection2);
                    float weight;
                    float.TryParse(infoTokens[2], out weight);

                    g.addEdge(intersection1, intersection2, weight);
                }
                Console.WriteLine(g.findBestPath());

                startup = Console.ReadLine();
            }
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

            //public void printGraph()
            //{
            //    int count = 0;
            //    foreach (LinkedList<Tuple<int, float>> intersection in adjacencyList)
            //    {
            //        Console.Write("[" + count + "]");
            //        foreach (Tuple<int, float> edge in intersection)
            //        {
            //            Console.Write(" --> " + " <" + edge.Item1 + ", " + edge.Item2 + "> ");
            //        }
            //        Console.WriteLine();
            //        count++;
            //    }
            //}

            public string findBestPath()
            {
                int[] prev = new int[adjacencyList.Count()];
                float[] dist = new float[adjacencyList.Count()];

                for(int i = 0; i < numIntersections; i++)
                {
                    dist[i] = -1;
                    //prev[i] = -1;
                }

                dist[0] = 1;

                PriorityQueue PQ = new PriorityQueue(numIntersections);
                PQ.insertOrChange(0, 1);

                while(!PQ.IsEmpty())
                {
                    int u = PQ.PopMax();

                    foreach(Tuple<int, float> intersection in adjacencyList[u])
                    {
                        int v = intersection.Item1; //name
                        float w = intersection.Item2; //weight
                        if(dist[v] < dist[u] * w)
                        {
                            dist[v] = dist[u] * w;
                            prev[v] = u;
                            PQ.insertOrChange(v, dist[v]);
                        }
                    }
                }

                return Math.Round((Decimal)dist[numIntersections - 1], 4, MidpointRounding.AwayFromZero).ToString("F4");

            }
        }

    }

    //class PriorityQueue
    //{
    //    private int maxSize;
    //    private int currentSize;
    //    private float?[] pq;

    //    public PriorityQueue(int size)
    //    {
    //        this.maxSize = size;
    //        pq = new float?[size];
    //    }

    //    public void insertOrChange(int name, float dist)
    //    {
    //        if (pq[name] == null)
    //            currentSize++;

    //        pq[name] = dist;
    //    }

    //    public bool isEmpty()
    //    {
    //        if (currentSize == 0)
    //            return true;
    //        else
    //            return false;
    //    }

    //    public int popMax()
    //    {
    //        int max = -1;
    //        int intersection = -1;
    //        for(int i = 0; i < maxSize; i++)
    //        {
    //            if (pq[i] > max)
    //                intersection = i;
    //        }

    //        pq[intersection] = null;
    //        currentSize--;

    //        return intersection;
    //    }
    //}

    class PriorityQueue
    {
        private Tuple<int, float>[] heapArray;
        private int maxSize;
        private int currentSize;
        public PriorityQueue(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            currentSize = 0;
            heapArray = new Tuple<int, float>[maxSize];
        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }
        public bool insertOrChange(int name, float dist)
        {
            if (currentSize == maxSize)
                return false;
            Tuple<int, float> newTuple = new Tuple<int, float>(name, dist);
            heapArray[currentSize] = newTuple;
            BubbleUp(currentSize++);
            return true;
        }
        public void BubbleUp(int index)
        {
            int parent = (index - 1) / 2;
            Tuple<int, float> bottom = heapArray[index];
            while (index > 0 && heapArray[parent].Item2 < bottom.Item2)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public int PopMax() // Remove maximum value node
        {
            Tuple<int, float> root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            SinkDown(0);
            return root.Item1;
        }
        public void SinkDown(int index)
        {
            int largerChild;
            Tuple<int, float> top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if (rightChild < currentSize && heapArray[leftChild].Item2 < heapArray[rightChild].Item2)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (top.Item2 >= heapArray[largerChild].Item2)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
    }
}
