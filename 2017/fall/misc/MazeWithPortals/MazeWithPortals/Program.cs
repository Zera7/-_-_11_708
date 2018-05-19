using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MazeWithPortals
{
    public enum MazeCell
    {
        empty,
        wall,
        finish
    }

    public class Cell
    {
        public MazeCell Type { get; set; }
    }

    public class Portal
    {
        public Portal(int x1, int y1)
        {
            Coords = new Point(x1, y1);
        }

        public Portal(Portal next, int x, int y)
        {
            this.Next = next;
            Coords = new Point(x, y);
        }

        public Portal Next;
        public Point Coords { get; set; }
    }

    public class Path
    {
        public Point Coords { get; set; }
        public Path Prev { get; set; }

        public List<Point> GetPath()
        {
            List<Point> result = new List<Point>();
            do
            {
                result.Add(Coords);
            } while (Prev != null);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var arr = new Cell[20, 20];
            var portalA = new Portal(5, 5);
            var portalB = new Portal(portalA, 7, 7);

            var portals = new List<Portal> { portalA, portalB };

            List<Point> result = GetPath(arr, portals, new Point(2, 2));
        }

        private static List<Point> GetPath(Cell[,] arr, List<Portal> portals, Point initialPosition)
        {
            var xLength = arr.GetLength(0);
            var yLength = arr.GetLength(0);

            var array = new Path[xLength, yLength];

            var queue = new Queue<Point>();
            queue.Enqueue(initialPosition);
            var minPath = 

            while (queue.Count > 0)
            {
                var currentPoint = queue.Dequeue();
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if ((i == 0 || j == 0) && i != j)
                        // Проверка: находится внутри карты?
                        {
                            queue.Enqueue(new Point(currentPoint.X + j, currentPoint.Y + i));
                        }
                    }
                }


            }
        }
    }
}
