using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Profiling
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X, Y;
    }

    class Program
    {
        public static void Main()
        {
            foreach (var point in ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
                Console.WriteLine(point.X + " " + point.Y);
            Console.Read();
        }

        public static List<Point> ParsePoints(IEnumerable<string> lines)
        {
            return lines
                .Select(x => x.Split(' '))
                .Select(y =>
                        y.Select(x => int.Parse(x))
                        .ToArray())
                .Select(x => new Point(x[0], x[1]))
                .ToList();
        }
    }
}