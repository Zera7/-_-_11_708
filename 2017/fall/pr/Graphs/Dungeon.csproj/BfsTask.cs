using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class BfsTask
    {
        public static IEnumerable<SinglyLinkedList<Point>> FindPaths(Map map, Point start, Point[] chests)
        {
            var visited = new Dictionary<Point,SinglyLinkedList<Point>>();
            var queue = new Queue<SinglyLinkedList<Point>>();
            queue.Enqueue(new SinglyLinkedList<Point>(start));
            while (queue.Count != 0)
            {
                var currentWay = queue.Dequeue();
                if (visited.ContainsKey(currentWay.Value)) continue;
                visited[currentWay.Value] = (currentWay);
                if (chests.Contains(currentWay.Value)) yield return currentWay;
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                        if (i != j && (i == 0 || j == 0))
                        {
                            Point newPoint = new Point(currentWay.Value.X + j, currentWay.Value.Y + i);
                            if (!map.InBounds(newPoint)) continue;
                            if (map.Dungeon[newPoint.X, newPoint.Y] == MapCell.Empty)
                                queue.Enqueue(new SinglyLinkedList<Point>(
                                        new Point(newPoint.X, newPoint.Y),
                                        currentWay));
                        }
            }
        }
    }
}