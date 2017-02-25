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
            //var sr = new StringReader("8 13\n" +
            //                          "0 1 0.1\n" +
            //                          "1 2 0.2\n" +
            //                          "2 3 0.1\n" +
            //                          "0 5 0.8\n" +
            //                          "1 6 0.6\n" +
            //                          "3 6 0.1\n" +
            //                          "0 4 0.4\n" +
            //                          "1 5 0.6\n" +
            //                          "2 6 0.2\n" +
            //                          "3 7 0.4\n" +
            //                          "4 5 0.5\n" +
            //                          "6 5 0.1\n" +
            //                          "6 7 0.1\n" +
            //                          "0 0\n");
            //Console.SetIn(sr);

            //string startup;

            //startup = Console.ReadLine();
            //while (startup != "0 0")
            //{
            //    string[] tokens = startup.Split(' ');

            //    numIntersections = int.Parse(tokens[0]);
            //    numEdges = int.Parse(tokens[1]);

            //    Graph g = new Graph(numIntersections);

            //    for (int i = 0; i < numEdges; i++)
            //    {
            //        string info = Console.ReadLine();
            //        string[] infoTokens = info.Split(' ');
            //        int intersection1; 
            //        int.TryParse(infoTokens[0], out intersection1);
            //        int intersection2;
            //        int.TryParse(infoTokens[1], out intersection2);
            //        float weight;
            //        float.TryParse(infoTokens[2], out weight);

            //        g.addEdge(intersection1, intersection2, weight);
            //    }
            //    Console.WriteLine(g.findBestPath());

            //    startup = Console.ReadLine();
            //}

            PriorityQueue pq = new PriorityQueue(6);
            pq.insertOrChange(1, 10);
            pq.insertOrChange(2, 7);
            pq.insertOrChange(3, 6);
            pq.insertOrChange(4, 10);
            pq.insertOrChange(5, 17);
            pq.insertOrChange(6, 15);
            pq.popMax();
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

                while(!PQ.isEmpty())
                {
                    int u = PQ.popMax();

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
        Tuple<int, float>[] pq;
        int currentSize = 0;

        public PriorityQueue(int size)
        {
            pq = new Tuple<int, float>[size + 1];
        }

        public void insertOrChange(int name, float dist)
        {
            currentSize++;
            int currentPosition = currentSize;
            pq[currentPosition] = new Tuple<int, float>(name, dist);
            int parent = currentPosition / 2;

            if (currentPosition == 1)
                return;

            while (pq[currentPosition].Item2 > pq[parent].Item2)
            {
                swap(currentPosition, parent);
                currentPosition = currentPosition / 2;
                parent = currentPosition / 2;

                if (currentPosition == 1)
                    return;
            }
            
        }

        public bool isEmpty()
        {
            if (pq[1] == null)
                return true;
            else
                return false;
        }

        public int popMax()
        {
            int root = 1;
            int result = pq[root].Item1; //Save the value of the root
            pq[root] = pq[currentSize]; //Put the last item at the root
            pq[currentSize] = null; //Remove the last item

            int currentPosition = root;
            int leftChild = currentPosition * 2;
            int rightChild = currentPosition * 2 + 1;

            while (pq[currentPosition].Item2 < pq[leftChild].Item2 || pq[currentPosition].Item2 < pq[rightChild].Item2)
            {
                if(pq[currentPosition].Item2 < pq[leftChild].Item2 && pq[currentPosition].Item2 < pq[rightChild].Item2)
                {
                    if (pq[leftChild].Item2 > pq[rightChild].Item2)
                    {
                        swap(currentPosition, leftChild);
                        currentPosition = leftChild;
                        leftChild = currentPosition * 2;
                        rightChild = currentPosition * 2 + 1;
                    }
                        
                    else
                    {
                        swap(currentPosition, rightChild);
                        currentPosition = rightChild;
                        leftChild = currentPosition * 2;
                        rightChild = currentPosition * 2 + 1;
                    }  
                }
                else
                {
                    if(pq[currentPosition].Item2 < pq[leftChild].Item2)
                    {
                        swap(currentPosition, leftChild);
                        currentPosition = leftChild;
                        leftChild = currentPosition * 2;
                        rightChild = currentPosition * 2 + 1;
                    }
                    else   
                    {
                        swap(currentPosition, rightChild);
                        currentPosition = rightChild;
                        leftChild = currentPosition * 2;
                        rightChild = currentPosition * 2 + 1;
                    }
                }
            }
            
            currentSize--;

            return result;
        }

        private void swap(int index1, int index2)
        {
            Tuple<int, float> temp = pq[index1];
            pq[index1] = pq[index2];
            pq[index2] = temp;
        }
    }


}
