using System.Collections.Generic;
using System.Drawing;
using Greedy.Architecture;
using Greedy.Architecture.Drawing;
using System.Linq;
using System.Collections;

namespace Greedy
{
    public class GreedyPathFinder : IPathFinder
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
            var result = new List<Point>();
            var spentEnergy = 0;
            var startPoint = state.Position;
            var chests = new HashSet<Point>(state.Chests);

            for (int i = 0; i < state.Goal; i++)
            {
                var newPath = GetMinPathToChest(state, chests, ref spentEnergy, ref startPoint);
                if (spentEnergy > state.InitialEnergy || newPath == null)
                    return new List<Point>();
                result.AddRange(newPath);
            }
            return result;
        }

        private List<Point> GetMinPathToChest(State state, HashSet<Point> chests,
            ref int spentEnergy, ref Point startPoint)
        {
            var array = new MazeCell[state.MapWidth, state.MapHeight];
            var queue = new Queue<MazeCell>();
            MazeCell minPathToChest = null;
            if (chests.Contains(startPoint))
            {
                chests.Remove(startPoint);
                return new List<Point>();
            }
            minPathToChest = AddNewCellsToQueue(
                state, chests, array, queue, minPathToChest,
                new MazeCell(0, startPoint, null));
            while (queue.Count > 0)
            {
                var currentPath = queue.Dequeue();
                minPathToChest = AddNewCellsToQueue(
                    state, chests, array, queue, minPathToChest, currentPath);
            }
            if (minPathToChest == null) return null;
            chests.Remove(minPathToChest.Coords);
            spentEnergy += minPathToChest.PathCost;
            startPoint = minPathToChest.Coords;
            return minPathToChest.GetPath();
        }

        private static MazeCell AddNewCellsToQueue(
            State state, HashSet<Point> chests, MazeCell[,] array,
            Queue<MazeCell> queue, MazeCell minPathToChest, MazeCell currentPath)
        {
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if ((i == 0 || j == 0) && i != j)
                    {
                        var newPoint = new Point(currentPath.Coords.X + j, currentPath.Coords.Y + i);
                        if (state.InsideMap(newPoint) && !state.IsWallAt(newPoint) &&
                            (array[newPoint.X, newPoint.Y] == null ||
                            array[newPoint.X, newPoint.Y].PathCost >
                            currentPath.PathCost + state.CellCost[newPoint.X, newPoint.Y]))
                        {
                            var newPath = new MazeCell(state.CellCost[newPoint.X, newPoint.Y] + currentPath.PathCost,
                                newPoint, currentPath.PathCost != 0 ? currentPath : null);
                            if (minPathToChest == null || minPathToChest.PathCost > newPath.PathCost)
                            {
                                queue.Enqueue(newPath);
                                array[newPoint.X, newPoint.Y] = newPath;
                                if (chests.Contains(newPath.Coords))
                                    minPathToChest = newPath;
                            }
                        }
                    }
            return minPathToChest;
        }
    }
}