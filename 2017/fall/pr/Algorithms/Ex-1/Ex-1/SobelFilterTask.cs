using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            int width = g.GetLength(0);
            int height = g.GetLength(1);

            double[,] result = new double[width, height];
            int sobelSize = sx.GetLength(0);

            int xEnd = width - sobelSize / 2;
            int yEnd = height - sobelSize / 2;

            var sy = GetSy(sx);
            for (int x = sobelSize / 2; x < xEnd; x++)
                for (int y = sobelSize / 2; y < yEnd; y++)
                {
                    var gx = GetGxGy(g, sx, sobelSize, x, y);
                    var gy = GetGxGy(g, sy, sobelSize, x, y);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }

        private static double GetGxGy(double[,] g, double[,] sxOrSy, int sobelSize, int x, int y)
        {
            double result = 0.0;
            var d = GetD(sobelSize);
            for (var i = 0; i < sobelSize; ++i)
            {
                for (var j = 0; j < sobelSize; ++j)
                {
                    result += sxOrSy[i, j] * g[x + d[j], y + d[i]];
                }
            }
            return result;
        }

        private static int[] GetD(int sobelSize)
        {
            int[] d = new int[sobelSize];
            int start = (-1) * (sobelSize / 2);
            for (int i = 0; i < sobelSize; ++i)
                d[i] = start + i;
            return d;
        }

        private static double[,] GetSy(double[,] sx)
        {
            var sobelSize = sx.GetLength(0);
            var sy = new double[sobelSize, sobelSize];
            for (var i = 0; i < sobelSize; ++i)
                for (var j = 0; j < sobelSize; ++j)
                    sy[j, i] = sx[i, j];
            return sy;
        }
    }
}