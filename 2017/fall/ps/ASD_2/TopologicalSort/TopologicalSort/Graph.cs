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

        public HashSet<Edge> IncidentEdges { get; set; } = new HashSet<Edge>();
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
        /// <summary>
        /// Создает граф по парам вершин
        /// </summary>
        /// <param name="nodes">Номера вершин</param>
        public Graph(params int[] nodes)
        {
            int nodesLen = nodes.Length - nodes.Length % 2;

            for (int i = 0; i < nodesLen; i += 2)
            {
                TryCreateNode(nodes[i]);
                TryCreateNode(nodes[i + 1]);

                var newEdge = new Edge(Nodes[nodes[i]], Nodes[nodes[i + 1]]);
                Nodes[nodes[i]].IncidentEdges.Add(newEdge);
                Nodes[nodes[i + 1]].IncidentEdges.Add(newEdge);
            }
        }

        public Dictionary<int, Node> Nodes { get; set; } = new Dictionary<int, Node>();

        /// <summary>
        /// Пробует поместить вершину в граф
        /// </summary>
        /// <param name="a">Вершина</param>
        /// <returns>Возвращает вершину в графе по номеру переданной вершины</returns>
        public Node TryCreateNode(Node a)
        {
            if (!Nodes.ContainsKey(a.Number))
                Nodes[a.Number] = a;
            return Nodes[a.Number];
        }

        public Node TryCreateNode(int a)
        {
            return TryCreateNode(new Node(a));
        }

        /// <summary>
        /// Пробует соединить вершины
        /// </summary>
        /// <param name="a">Вершина 1</param>
        /// <param name="b">Вершина 2</param>
        /// <param name="edge">Получившаяся дуга</param>
        /// <returns>Возможность соединить данные вершины</returns>
        public bool TryConnectNodes(Node a, Node b, out Edge edge)
        {
            a = TryCreateNode(a);
            b = TryCreateNode(b);
            edge = new Edge(a, b);

            if (a.IncidentEdges.Contains(edge))
            {
                edge = new Edge(null, null);
                return false;
            } 

            a.IncidentEdges.Add(edge);
            b.IncidentEdges.Add(edge);
            return true;
        }

        public bool TryConnectNodes(int a, int b, out Edge newEdge)
        {
            return TryConnectNodes(new Node(a), new Node(b), out newEdge);
        }
    }
}
