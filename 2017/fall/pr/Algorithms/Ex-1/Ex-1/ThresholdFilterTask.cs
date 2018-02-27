using System;
using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
	public static class ThresholdFilterTask
	{
        /* 
		 * Замените пиксели ярче порогового значения T на белый (1.0),
		 * а остальные на черный (0.0).
		 * Пороговое значение найдите так, чтобы:
		 *  - если N — общее количество пикселей изображения, 
		 *    то хотя бы (int)(threshold*N)  пикселей стали белыми;
		 *  - белыми стало как можно меньше пикселей.
		*/

        static int maxX;
        static int maxY;

		public static double[,] ThresholdFilter(double[,] original, double threshold)
		{
            maxX = original.GetLength(0);
            maxY = original.GetLength(1);

            double[,] result = new double[maxX, maxY];
            double minBrightness = GetMinBrightness(original, threshold);

            for (int i = 0; i < maxY; i++)
                for (int j = 0; j < maxX; j++)
                    result[j, i] = original[j, i] < minBrightness ? 0 : 1;

            return result;
		}

        private static double GetMinBrightness(double[,] original, double threshold)
        {
            int n = (int)(threshold * original.Length);
            double minBrightness = double.MaxValue;
            var list = new List<double>(original.Cast<double>());

            list.Sort();

            for (int i = list.Count - 1; i >= 0 && n > 0; i--, n--)
                minBrightness = list[i];

            return minBrightness;
        }
    }
}