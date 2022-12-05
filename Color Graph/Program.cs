using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Color_Graph
{
    public enum EColor
    {
        Red,
        lightBlue,
        Gray,
        DarkBlue,
        Yellow,
        Orange,
        Purple,
        Green
    }
    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }
    public class Node : IComparable<Node>
    {
        // data
        public EColor nState;

        // list of edges
        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(EColor nState)
        {
            this.nState = nState;
            this.minCostToStart = int.MaxValue;
        }

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }

    static internal class Program
    {
        static int[,] colorsMatrix = new int[,]
        //-1 means not avaliable
        {             //red   light-blue  gray  dark-blue yellow orange purple green
        /*red */        {-1,  -1,         5,    1,         -1,    -1,    -1,    -1},
        /*light blue*/  {-1,  -1,         0,    1,         -1,    -1,    -1,    -1},
        /*gray*/        {-1,   0,        -1,   -1,         -1,     1,    -1,    -1},
        /*dark blue*/   {-1,   1,        -1,   -1,          8,    -1,    -1,    -1},
        /*yellow*/      {-1,  -1,        -1,   -1,         -1,    -1,    -1,     6},
        /*orange*/      {-1,  -1,        -1,   -1,         -1,    -1,     1,    -1},
        /*purple*/      {-1,  -1,        -1,   -1,          1,    -1,    -1,    -1},
        /*green*/       {-1,  -1,        -1,   -1,         -1,    -1,    -1,    -1},
        };

        static int[][] colorList = new int[][]
        {
            /*red 0*/new int[] {(int)EColor.Gray,(int)EColor.DarkBlue},
            /*light-blue 1*/new int[] {(int)EColor.Gray,(int)EColor.DarkBlue},
            /*gray 2*/new int[] {(int)EColor.lightBlue},
            /*dark blue 3*/new int[]{ (int)EColor.lightBlue,(int)EColor.Yellow},
            /*yellow 4*/new int[]{(int)EColor.Green},
            /*orange 5*/new int[]{(int)EColor.Purple},
            /*purple 6*/new int[]{(int)EColor.Yellow},
            /*green 7*/null
        };

        static int[][] colorCost = new int[][]
        {
            /*red*/new int[] {5, 1},
            /*light-blue*/new int[] {0, 1},
            /*gray*/new int[] {0},
            /*dark blue*/new int[]{1, 8},
            /*yellow*/new int[]{6},
            /*orange*/new int[]{1},
            /*purple*/new int[]{1},
            /*green*/null
        };
        static string currentColor = "Red";
        public static List<Node> colors = new List<Node>();

        static void Main(string[] args)
        {
            Node node;

            //int nextColor = 1;
            node = new Node(EColor.Red);//0
            colors.Add(node);

            node = new Node(EColor.lightBlue);//1
            colors.Add(node);

            node = new Node(EColor.Gray);//2
            colors.Add(node);

            node = new Node(EColor.DarkBlue);//3
            colors.Add(node);

            node = new Node(EColor.Yellow);//4
            colors.Add(node);

            node = new Node(EColor.Orange);//5
            colors.Add(node);

            node = new Node(EColor.Purple);//6
            colors.Add(node);

            node = new Node(EColor.Green);//7
            colors.Add(node);

            colors[0].AddEdge(1, colors[3]);
            colors[0].AddEdge(5, colors[2]);
            colors[0].edges.Sort();

            colors[1].AddEdge(0, colors[2]);
            colors[1].AddEdge(1, colors[3]);
            colors[1].edges.Sort();

            colors[2].AddEdge(0, colors[1]);
            colors[2].AddEdge(1, colors[5]);
            colors[2].edges.Sort();

            colors[3].AddEdge(1, colors[1]);
            colors[3].AddEdge(8, colors[4]);
            colors[3].edges.Sort();

            colors[4].AddEdge(6, colors[7]);
            colors[4].edges.Sort();

            colors[5].AddEdge(1, colors[6]);
            colors[5].edges.Sort();

            colors[6].AddEdge(1, colors[4]);
            colors[6].edges.Sort();

            DFS(EColor.Red);
        }

        static void DFS(EColor eState)
        {
            bool[] visited = new bool[colorList.Length];

            DFSUtil(eState, visited);
        }

        static void DFSUtil(EColor v, bool[] visited)
        {
            visited[(int)v] = true;

            Console.WriteLine(v.ToString() + "");

            int[] thisStateList = colorList[(int)v];

            if (thisStateList != null)
            {
                foreach (int n in thisStateList)
                {
                    if (!visited[n])
                    {
                        DFSUtil((EColor)n, visited);
                    }
                }
            }
        }

    }
}

