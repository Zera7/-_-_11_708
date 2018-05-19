using System.Collections.Generic;
using System.Drawing;

namespace Rivals
{
    public class RivalsTask
    {
        public static IEnumerable<OwnedLocation> AssignOwners(Map map)
        {
            var queue = new Queue<OwnedLocation>();
            var ownedLocations = new Dictionary<Point,OwnedLocation>();

            for (int i = 0; i < map.Players.Length; i++)
                queue.Enqueue(new OwnedLocation(i, map.Players[i], 0));

            while (queue.Count > 0)
            {
                var currentLocation = queue.Dequeue();
                if (ownedLocations.ContainsKey(currentLocation.Location) ||
                    !map.InBounds(currentLocation.Location) ||
                    map.Maze[currentLocation.Location.X, currentLocation.Location.Y] != MapCell.Empty)
                    continue;

                ownedLocations[currentLocation.Location] = currentLocation;
                yield return currentLocation;
                AddNearbyPoints(queue, currentLocation);
            }
        }

        private static void AddNearbyPoints(Queue<OwnedLocation> queue, OwnedLocation currentLocation)
        {
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    if ((i == 0 || j == 0) && i != j)
                    {
                        var newLocation = new OwnedLocation(
                            currentLocation.Owner,
                            new Point(currentLocation.Location.X + j, currentLocation.Location.Y + i),
                            currentLocation.Distance + 1);
                        queue.Enqueue(newLocation);
                    }
        }
    }
}