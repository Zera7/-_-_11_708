using System.Linq;
using System.Collections.Generic;
using System;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        static int maxY;
        static int maxX;

        public static double[,] MedianFilter(double[,] original)
        {
            maxX = original.GetLength(0);
            maxY = original.GetLength(1);

            List<double> list = new List<double>();
            double[,] result = new double[maxX, maxY];

            for (int i = 0; i < maxY; i++)
            {
                list = GetPixels(original, i);
                for (int j = 0; j < maxX; j++)
                {
                    List<double> sortedList = new List<double>(list);
                    sortedList.Sort();
                    if (sortedList.Count % 2 == 0)
                        result[j, i] = (sortedList[sortedList.Count / 2] + sortedList[sortedList.Count / 2 - 1]) / 2;
                    else
                        result[j, i] = sortedList[sortedList.Count / 2];
                    UpdatePixels(original, list, i, j + 1);
                }
                list.Clear();
            }
            return result;
        }

        private static void UpdatePixels(double[,] original, List<double> list, int y, int x)
        {
            int k = y == 0 || y == maxY - 1 ? 2 : 3;
            if (x > 1)
                list.RemoveRange(0, k);

            if (x < maxX - 1 && x > 0)
            {
                for (int i = -1; i <= 1; i++)
                    if (y + i >= 0 && y + i < maxY)
                    {
                        list.Add(original[x + 1, i + y]);
                    }
            }
        }

        private static List<double> GetPixels(double[,] original, int y)
        {
            List<double> list = new List<double>();
            for (int j = 0; j <= 1; j++)
                for (int i = -1; i <= 1; i++)
                {
                    if (j < maxX && y + i >= 0 && y + i < maxY)
                        list.Add(original[j, i + y]);
                }
            return list;
        }
    }
}