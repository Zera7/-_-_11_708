using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_2
{
    public class Node
    {
        public Node(int number)
        {
            this.Number = number;
        }

        public int Number { get; set; }

        public List<Edge> IncidentEdges { get; set; } = new List<Edge>();
    }

    public struct Edge
    {
        public Edge(Node from, Node to)
        {
            this.From = from;
            this.To = to;
        }

        public Node From { get; set; }
        public Node To { get; set; }
    }

    public class Graph
    {
        public Dictionary<int, Node> Nodes { get; set; } = new Dictionary<int, Node>();
        public Graph(params int[] nodes)
        {
            int nodesLen = nodes.Length - nodes.Length % 2;

            for (int i = 0; i < nodesLen; i += 2)
            {
                TryAddNode(nodes[i]);
                TryAddNode(nodes[i + 1]);

                Nodes[nodes[i]].IncidentEdges.Add(new Edge(Nodes[nodes[i]], Nodes[nodes[i + 1]]));
                Nodes[nodes[i + 1]].IncidentEdges.Add(new Edge(Nodes[nodes[i]], Nodes[nodes[i + 1]]));
            }
        }

        public void TryAddNode(Node a)
        {
            if (!Nodes.ContainsKey(a.Number))
                Nodes[a.Number] = a;
        }
        public void TryAddNode(int a)
        {
            if (!Nodes.ContainsKey(a))
                Nodes[a] = new Node(a);
        }

        public bool TryConnectNodes(Node a, Node b)
        {
            TryAddNode(a);
            TryAddNode(b);
            if (a.IncidentEdges.Contains(new Edge(a, b))) return false;
            a.IncidentEdges.Add(new Edge(a, b));
            b.IncidentEdges.Add(new Edge(a, b));
            return true;
        }
        public bool TryConnectNodes(int a, int b)
        {
            TryAddNode(a);
            TryAddNode(b);
            if (Nodes[a].IncidentEdges.Contains(new Edge(Nodes[a], Nodes[b]))) return false;
            Nodes[a].IncidentEdges.Add(new Edge(Nodes[a], Nodes[b]));
            Nodes[b].IncidentEdges.Add(new Edge(Nodes[a], Nodes[b]));
            return true;
        }
    }
}
