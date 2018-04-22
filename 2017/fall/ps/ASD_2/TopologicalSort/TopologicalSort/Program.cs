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
        public static int Iterations { get; set; }

        public static void Main()
        {
            TestTopologicalSort(3000, 50);
            Console.Read();
        }

        /// <summary>
        /// Тестирует топологическую сортировку
        /// </summary>
        /// <param name="MinAmountOfNewElements">Минимальное количество новых вершин и дуг</param>
        /// <param name="step">Шаг отображения тести</param>
        private static void TestTopologicalSort(int MinAmountOfNewElements, int step)
        {
            // В начальном графе не должно быть цикла
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

            List<TimeSpan> elapsedTimeList = new List<TimeSpan>(15000);
            List<int> amountOfElementsList = new List<int>(15000);
            List<int> iterationsOfSortList = new List<int>(15000);

            for (int i = 0; i < MinAmountOfNewElements; i++)
            {
                var time = NextTest(a, out int sum);
                if (i % step == 0)
                {
                    Console.WriteLine(i);

                    elapsedTimeList.Add(time);
                    amountOfElementsList.Add(sum);
                    iterationsOfSortList.Add(Iterations);

                    // Вывод всех вершин
                    //PrintAllNodes(a);
                }
            }

            PrintList(elapsedTimeList, "Время");
            PrintList(amountOfElementsList, "Количество элементов");
            PrintList(iterationsOfSortList, "Количество итераций");
        }

        /// <summary>
        /// Добавляет в граф новые вершины и дуги, запускает сортировку
        /// </summary>
        /// <param name="graph">Граф</param>
        /// <param name="sum">Сумма вершин и дуг в графе</param>
        /// <returns></returns>
        public static TimeSpan NextTest(Graph graph, out int sum)
        {
            Stopwatch time = new Stopwatch();
            List<Node> result = null;
            Tuple<int, int> a;
            Edge edge = new Edge(null, null);

            while (result == null)
            {
                time.Reset();
                Iterations = 0;

                do
                {
                    a = new Tuple<int, int>(
                        rnd.Next(0, graph.Nodes.Count + (int)(graph.Nodes.Count * 0.2)),
                        rnd.Next(0, graph.Nodes.Count + (int)(graph.Nodes.Count * 0.2)));

                } while (!graph.TryConnectNodes(a.Item1, a.Item2, out edge));

                time.Start();
                result = TarjanAlgorithm(graph);
                time.Stop();

                if (result == null)
                {
                    graph.Nodes[a.Item1].IncidentEdges.Remove(edge);
                    graph.Nodes[a.Item2].IncidentEdges.Remove(edge);
                }
            }

            sum = 0;
            foreach (var item in graph.Nodes)
                sum += item.Value.IncidentEdges.Count;
            sum /= 2;
            sum += graph.Nodes.Count;

            //// Проверка на повторения дуг
            //var b = result
            //    .SelectMany(q => q.IncidentEdges)
            //    .GroupBy(q => q)
            //    .Where(q => q.Count() > 2)
            //    .SelectMany(q => q)
            //    .ToList();
            //if (b.Count() > 0)
            //{
            //    Console.WriteLine("Повторяются:");
            //    foreach (var item in b)
            //        Console.WriteLine($"{item.From.Number} {item.To.Number}");
            //    Console.WriteLine("\n\n\nВ:");
            //    foreach (var item in result.OrderBy(q => q.Number))
            //        foreach (var item2 in item.IncidentEdges)
            //            Console.WriteLine($"Node {item.Number}: From {item2.From.Number} to {item2.To.Number}");
            //    Console.Read();
            //}

            return time.Elapsed;
        }

        /// <summary>
        /// Печатает содержимое списка
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список</param>
        /// <param name="title">Заголовок</param>
        /// <param name="indentation">Отступ</param>
        private static void PrintList<T>(IEnumerable<T> list, string title, int indentation = 10)
        {
            Console.WriteLine(title);
            foreach (var item in list)
                Console.WriteLine(item);
            StringBuilder ind = new StringBuilder();
            for (int i = 0; i < indentation; i++)
                ind.Append("\n");
            Console.WriteLine(ind.ToString());
        }

        /// <summary>
        /// Печатает все инцедентные дуги для всех вершин
        /// </summary>
        /// <param name="graph">Граф</param>
        private static void PrintAllNodes(Graph graph)
        {
            foreach (var item in graph.Nodes)
                foreach (var item2 in item.Value.IncidentEdges)
                    Console.WriteLine("Node " + item.Key + " From " + item2.From.Number + " To " + item2.To.Number);
            Console.WriteLine();
        }


        /// <summary>
        /// Выбирает следующую необработанную вершину и передает ее в обработку TarjanDepthSearch
        /// </summary>
        /// <param name="graph">Сортируемый граф</param>
        /// <returns>Отсортированный список вершин</returns>
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

        /// <summary>
        /// Ищет в глубину по исходящим дугам белые или серые вершины: белые обрабатывает, 
        /// серые говорят о том, что в графе есть цикл и это плохо
        /// </summary>
        /// <param name="node"></param>
        /// <param name="states"></param>
        /// <param name="topSort"></param>
        /// <returns>Успешность сортировки</returns>
        public static bool TarjanDepthSearch(Node node, Dictionary<Node, State> states, List<Node> topSort)
        {
            Iterations++;

            if (states[node] == State.Gray) return false;
            if (states[node] == State.Black) return true;
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
