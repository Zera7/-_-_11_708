using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
	public class DungeonTask
	{
		public static MoveDirection[] FindShortestPath(Map map)
		{
            var exit = BfsTask.FindPaths(map, map.InitialPosition, new[] { map.Exit }).FirstOrDefault();
            if (exit == null)
                return new MoveDirection[0];

            var pathToExit = BfsTask.FindPaths(map, map.Exit, map.Chests).DefaultIfEmpty();
            var pathToChests = BfsTask.FindPaths(map, map.InitialPosition, map.Chests);

            var exitList = exit.ToList();
            exitList.Reverse();
            if (pathToChests.FirstOrDefault() == null) return ConvertPointsToDirections(exitList);

            var pathPoints = GetShortestPath(pathToChests, pathToExit);
            return ConvertPointsToDirections(pathPoints);
        }

        static List<Point> GetShortestPath(IEnumerable<SinglyLinkedList<Point>> pathToChests, IEnumerable<SinglyLinkedList<Point>> pathToExit)
        {
            var a = pathToChests
                .Join(pathToExit, q => q.Value, w => w.Value, (q, w) => new
                {
                    Length = q.Length + w.Length,
                    List1 = q,
                    List2 = w
                });
            var min = a.Min(q => q.Length);
            var b = a
                .Where(q => q.Length == min)
                .Select(q => Tuple.Create(q.List1.ToList(), q.List2.ToList()))
                .First();
            b.Item1.Reverse();
            b.Item2.RemoveAt(0);
            b.Item1.AddRange(b.Item2);
            return b.Item1;
        }

        static MoveDirection[] ConvertPointsToDirections(List<Point> list)
        {
            var result = new List<MoveDirection>();

            for (int i = 0; i < list.Count - 1; i++)
                result.Add(GetDirection(list[i], list[i + 1]));

            return result.ToArray();
        }

        static MoveDirection GetDirection(Point a, Point b)
        {
            var delta = new Point(a.X - b.X, a.Y - b.Y);
            if (delta.X == 1) return MoveDirection.Left;
            if (delta.X == -1) return MoveDirection.Right;
            if (delta.Y == 1) return MoveDirection.Up;
            return MoveDirection.Down;
        }
    }
}
