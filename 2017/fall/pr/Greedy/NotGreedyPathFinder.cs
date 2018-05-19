using System;
using System.Collections.Generic;
using System.Drawing;
using Greedy.Architecture;
using Greedy.Architecture.Drawing;
using System.Linq;

namespace Greedy
{
    public class NotGreedyPathFinder : IPathFinder
    {
        public class MazeCell
        {
            public MazeCell(int pathCost, Point coords, MazeCell prev)
            {
                this.PathCost = pathCost;
                this.Previous = prev;
                this.Coords = coords;
            }

            public int PathCost { get; set; }
            public Point Coords { get; set; }
            public MazeCell Previous { get; set; }

            public List<Point> GetPath()
            {
                var result = new List<Point>();
                var current = this;
                while (current != null)
                {
                    result.Add(current.Coords);
                    current = current.Previous;
                }
                result.Reverse();
                return result;
            }
        }

        public List<Point> FindPathToCompleteGoal(State state)
        {
            var chests = new HashSet<Point>(state.Chests);
            if (chests.Contains(state.Position)) chests.Remove(state.Position);
            var ways = new MazeCell[chests.Count + 1, chests.Count + 1];

            GetWaysToPoints(state, state.Position, chests, ways, 1);
            PrintWays(state, ways);

            var i = 0;
            foreach (var item in chests)
                GetWaysToPoints(state, item, chests, ways, i++);

            Console.WriteLine();
            Console.WriteLine($"Количество сундуков: {chests.Count}");
            PrintWays(state, ways);

            Console.Read();

            return null;
        }

        private static void PrintWays(State state, MazeCell[,] ways)
        {
            Console.WriteLine();
            for (int q = 0; q < state.Chests.Count + 1; q++)
            {
                for (int j = 0; j < state.Chests.Count + 1; j++)
                {
                    if (ways[j, q] == null)
                        Console.Write("?\t");
                    else
                        Console.Write($"{ways[j, q].PathCost}\t");
                }
                Console.WriteLine();
            }
        }

        //private List<Point> Getpermutations(MazeCell[,] ways)
        //{
        //    List<MazeCell> bestWay = new List<MazeCell>();

        //}

        private void GetWaysToPoints(State state, Point position, MazeCell[,] ways, int index)
        {
            var cells = new MazeCell[state.MapWidth, state.MapHeight];
            var queue = new Queue<MazeCell>();
            AddCellsToQueue(cells, state, queue, position);

            while (queue.Count > 0)
            {
                var currentPath = queue.Dequeue();
                AddCellsToQueue(cells, state, queue, currentPath.Coords);
            }

            foreach (var item in state.Chests)
            {
                if (cells[item.X, item.Y] != null && item != position)
                ways[i++, index] = cells[item.X, item.Y];
            }
        }

        private static void AddCellsToQueue(MazeCell[,] cells, State state,
            Queue<MazeCell> queue, Point currentCell)
        {
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if (i != j && (i == 0 || j == 0))
                    {
                        var newPoint = new Point(currentCell.X + j, currentCell.Y + i);
                        if (state.InsideMap(newPoint) &&
                            !state.IsWallAt(newPoint) &&
                            (cells[newPoint.X, newPoint.Y] == null ||
                            cells[newPoint.X, newPoint.Y].PathCost >
                            cells[currentCell.X, currentCell.Y].PathCost + state.CellCost[newPoint.X, newPoint.Y]))
                        {
                            var newPath = new MazeCell(
                                state.CellCost[newPoint.X, newPoint.Y] +
                                (cells[currentCell.X, currentCell.Y] == null? 0 : cells[currentCell.X, currentCell.Y].PathCost),
                                newPoint,
                                cells[currentCell.X, currentCell.Y]);

                            queue.Enqueue(newPath);
                            cells[newPoint.X, newPoint.Y] = newPath;
                        }
                    }
        }
    }
}