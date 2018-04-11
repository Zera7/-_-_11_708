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
            var queue = new Queue<Point>();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var point = queue.Dequeue();
                if (!map.InBounds(point)) continue;
                if (map[point.X, point.Y] != MapCell.Empty) continue;
                map[point.X, point.Y] = State.Visited;
                Print(map);

                for (var dy = -1; dy <= 1; dy++)
                    for (var dx = -1; dx <= 1; dx++)
                        if (dx != 0 && dy != 0) continue;
                        else queue.Enqueue(new Point { X = point.X + dx, Y = point.Y + dy });

            }
        }
}