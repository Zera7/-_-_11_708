using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ASD_2
{
    public enum State
    {
        White,
        Gray,
        Black
    }

    class Program
    {
        public static Random rnd = new Random();
        public static int iterations = 0;

        public static void Main()
        {
            Graph a = new Graph(
                11, 2,
                11, 9,
                11, 10,
                8, 9,
                7, 11,
                7, 8,
                5, 11,
                3, 8,
                3, 10
                );

            List<TimeSpan> timeList = new List<TimeSpan>(15000);
            List<int> sumList = new List<int>(15000);
            List<int> iterationsList = new List<int>();

            for (int i = 0; i < 5000; i++)
            {
                var time = AddArc(a, out int sum);
                if (i % 50 == 0)
                {
                    iterationsList.Add(iterations);
                    timeList.Add(time);
                    sumList.Add(sum);
                    Console.WriteLine(i);
                    //foreach (var item in a.Nodes)
                    //{
                    //    foreach (var item2 in item.Value.IncidentEdges)
                    //    {
                    //        Console.WriteLine("Node " + item.Key + " From " + item2.From.Number + " To " + item2.To.Number);
                    //    }
                    //}
                    //Console.WriteLine();
                }

                  
                iterations = 0;
            }

            foreach (var item in timeList)
                Console.WriteLine(item);

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            foreach (var item in sumList)
                Console.WriteLine(item);

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");

            foreach (var item in iterationsList)
                Console.WriteLine(item);

            Console.Read();
        }

        /// <summary>
        /// Метод для добавления тестовых вершин и дуг в граф
        /// </summary>
        /// <param name="graph">Граф</param>
        /// <param name="sum">Сумма вершин и дуг в графе</param>
        /// <returns></returns>
        public static TimeSpan AddArc(Graph graph, out int sum)
        {
            List<Node> result;
            Tuple<int, int> a;

            do
            {
                a = new Tuple<int, int>(
                    rnd.Next(0, graph.Nodes.Count + (int)(graph.Nodes.Count * 0.2)),
                    rnd.Next(0, graph.Nodes.Count + (int)(graph.Nodes.Count * 0.2)));

            } while (!graph.TryConnectNodes(a.Item1, a.Item2));

            Stopwatch time = new Stopwatch();
            time.Start();
            result = TarjanAlgorithm(graph);
            time.Stop();

            if (result == null)
            {
                graph.Nodes[a.Item1].IncidentEdges.RemoveAt(graph.Nodes[a.Item1].IncidentEdges.Count - 1);
                graph.Nodes[a.Item2].IncidentEdges.RemoveAt(graph.Nodes[a.Item2].IncidentEdges.Count - 1);
                time.Restart();
                TarjanAlgorithm(graph);
                time.Stop();
            }

            sum = 0;
            foreach (var item in graph.Nodes)
                sum += item.Value.IncidentEdges.Count;
            sum /= 2;
            sum += graph.Nodes.Count;

            return time.Elapsed;
        }



        public static List<Node> TarjanAlgorithm(Graph graph)
        {
            var topSort = new List<Node>();
            var states = graph.Nodes.ToDictionary(node => node.Value, node => State.White);
            while (true)
            {
                var nodeToSearch = states
                    .Where(z => z.Value == State.White)
                    .Select(z => z.Key)
                    .FirstOrDefault();
                if (nodeToSearch == null) break;

                if (!TarjanDepthSearch(nodeToSearch, states, topSort))
                    return null;
            }
            topSort.Reverse();
            return topSort;
        }

        public static bool TarjanDepthSearch(Node node, Dictionary<Node, State> states, List<Node> topSort)
        {
            if (states[node] == State.Gray) return false;
            if (states[node] == State.Black) return true;
            iterations++;
            states[node] = State.Gray;

            var outgoingNodes = node.IncidentEdges
                .Where(edge => edge.From == node)
                .Select(edge => edge.To);
            foreach (var nextNode in outgoingNodes)
                if (!TarjanDepthSearch(nextNode, states, topSort)) return false;

            states[node] = State.Black;
            topSort.Add(node);
            return true;
        }
    }
}