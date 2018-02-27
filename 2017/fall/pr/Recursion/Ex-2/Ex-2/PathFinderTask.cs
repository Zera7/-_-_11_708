using System;
using System.Collections.Generic;
using System.Drawing;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        private static double MinLength = double.MaxValue;
        private static int[] BestOrder;

        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            BestOrder = new int[checkpoints.Length];
            GetBestOrder(checkpoints, new int[checkpoints.Length]);
            MinLength = double.MaxValue;
            return BestOrder;
        }



        private static void GetBestOrder(Point[] checkpoints, int[] permutation, int iteration = 0, double orderLength = 0)
        {
            if (iteration > 0)
                orderLength += checkpoints[permutation[iteration-1]].DistanceTo(checkpoints[permutation[iteration]]);
            if (orderLength > MinLength) return;

            if (iteration == checkpoints.Length - 1)
            {
                if (orderLength < MinLength)
                {
                    MinLength = orderLength;
                    Array.Copy(permutation, BestOrder, permutation.Length);
                }
                return;
            }
            for (int i = 1; i < permutation.Length; i++)
            {
                if (!IsUsedCheckpoint(i, permutation, iteration))
                {
                    permutation[iteration + 1] = i;
                    GetBestOrder(checkpoints, permutation, iteration + 1, orderLength);
                } 
            }
        }

        private static bool IsUsedCheckpoint(int i, int[] permutation, int iteration)
        {
            for (int k = 1; k <= iteration; k++)
                if (i == permutation[k])
                    return true;
            return false;
        }
    }
}





