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
            /*gray 2*/new int[] {(int)EColor.lightBlue,(int)EColor.Orange},
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
            /*gray*/new int[] {0,1},
            /*dark blue*/new int[]{1, 8},
            /*yellow*/new int[]{6},
            /*orange*/new int[]{1},
            /*purple*/new int[]{1},
            /*green*/null
        };
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

            colors[(int)EColor.Red].AddEdge(1, colors[(int)EColor.DarkBlue]);
            colors[(int)EColor.Red].AddEdge(5, colors[(int)EColor.Gray]);
            colors[(int)EColor.Red].edges.Sort();

            colors[(int)EColor.lightBlue].AddEdge(0, colors[(int)EColor.Gray]);
            colors[(int)EColor.lightBlue].AddEdge(1, colors[(int)EColor.DarkBlue]);
            colors[(int)EColor.lightBlue].edges.Sort();

            colors[(int)EColor.Gray].AddEdge(0, colors[(int)EColor.lightBlue]);
            colors[(int)EColor.Gray].AddEdge(1, colors[(int)EColor.Orange]);
            colors[(int)EColor.Gray].edges.Sort();

            colors[(int)EColor.DarkBlue].AddEdge(1, colors[(int)EColor.lightBlue]);
            colors[(int)EColor.DarkBlue].AddEdge(8, colors[(int)EColor.Yellow]);
            colors[(int)EColor.DarkBlue].edges.Sort();

            colors[(int)EColor.Yellow].AddEdge(6, colors[7]);
            colors[(int)EColor.Yellow].edges.Sort();

            colors[(int)EColor.Orange].AddEdge(1, colors[(int)EColor.Purple]);
            colors[(int)EColor.Orange].edges.Sort();

            colors[(int)EColor.Purple].AddEdge(1, colors[(int)EColor.Yellow]);
            colors[(int)EColor.Purple].edges.Sort();

            Console.WriteLine("Depth First Search");
            DFS(EColor.Red);

            Console.WriteLine("Get Shortest Path Dijkstra");
            foreach (Node color in GetShortestPathDijkstra())
            {
                
                Console.WriteLine(color.nState.ToString());
            }
        }

        static void DFS(EColor eState)
        {
            bool[] visited = new bool[colorList.Length];

            DFSUtil(eState, visited);
        }

        static void DFSUtil(EColor v, bool[] visited)
        {
            visited[(int)v] = true;

            Console.WriteLine(v.ToString());

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
        /****************************************************************************************
       The Dijkstra algorithm was discovered in 1959 by Edsger Dijkstra.
       This is how it works:

       1. From the start node, add all connected nodes to a priority queue.
       2. Sort the priority queue by lowest cost and make the first node the current node.
          For every child node, select the shortest path to start.
          When all edges have been investigated from a node, that node is "Visited" 
          and you don´t need to go there again.
       3. Add each child node connected to the current node to the priority queue.
       4. Go to step 2 until the queue is empty.
       5. Recursively create a list of each node that defines the shortest path 
          from end to start.
       6. Reverse the list and you have found the shortest path

       In other words, recursively for every child of a node, measure its distance to the start. 
       Store the distance and what node led to the shortest path to start. When you reach the end 
       node, recursively go back to the start the shortest way, reverse that list and you have the 
       shortest path.
       ******************************************************************************************/

        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(colors[(int)EColor.Green]);
            BuildShortestPath(shortestPath, colors[(int)EColor.Green]);
            shortestPath.Reverse();
            return (shortestPath);
        }

        static private void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }


        static private int NodeOrderBy(Node n)
        {
            return n.minCostToStart;
        }

        static private void DijkstraSearch()
        {
            Node start = colors[(int)EColor.Red];

            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(start);

            //Func<Node, int> nodeOrderBy = new Func<Node, int>(NodeOrderBy);
            Func<Node, int> nodeOrderBy = NodeOrderBy;

            do
            {
                // sort our prioQueue by minCostToStart
                // option #1, use .Sort() which sorts in place
                prioQueue.Sort();

                // option #2, use .OrderBy() with a delegate method or lambda expression 
                // the next 6 lines are equivalent from descriptive to abbreviated:
                prioQueue = prioQueue.OrderBy(nodeOrderBy).ToList();
                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart).ToList();
                prioQueue = prioQueue.OrderBy(n => n.minCostToStart).ToList();

                Node node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (Edge cnn in //node.edges)
                         node.edges.OrderBy(delegate (Edge n) { return n.cost; }))
                {
                    Node childNode = cnn.connectedNode;
                    if (childNode.visited)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true;

                // if we reeached our target
                if (node == colors[(int)EColor.Green])
                {
                    return;
                }
            } while (prioQueue.Any());
        }
    }
}

