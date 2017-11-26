using System;
using System.Collections.Generic;

namespace solver
{
    public class Ex1
    {
        public static double[] F1(double x, double k)
        {
            double[] result = new double[2];
            if (x == 0)
            {
                result[0] = double.NaN;
                result[1] = double.NaN;
                return result;
            }
            double oldResult = 0;
            bool end = false;
            int i = 0;

            for (i = 0; !end; i++)
            {
                result[0] += (2 * i * x + 1) / (Math.Pow(x, 2 * i) * Fact(2 * i));
                end = Math.Abs(result[0] - oldResult) < k;
                oldResult = result[0];
            }
            result[1] = i;

            return result;
        }

        public static double[] F2(double x, double k)
        {
            k = Math.Max(0.000004, k);
            double[] result = new double[2];
            if (Math.Abs(x) > 1) {
                result[0] = double.NaN;
                result[1] = double.NaN;
                return result;
            }

            List<double> array = new List<double>();

            int i;
            double oldResult = 0;
            bool end = false;

            for (i = 0; !end; i++)
            {
                result[0] += ((i % 2 == 0 ? 1 : -1) * Fact(2 * i, i + 1, 4 / x, i)) /
                    (1 - 2 * i);
                end = Math.Abs(result[0] - oldResult) < k;
                oldResult = result[0];
            }

            result[1] = i;
            return result;
        }

        public static double[] F3(double k)
        {

            double[] result = new double[2];
            double oldResult = 0;
            bool end = false;
            int i = 0;

            for (i = 1; !end; i++)
            {
                result[0] += Math.Abs(Fact(i - 1)) / Fact(2 * i, i);
                end = Math.Abs(result[0] - oldResult) < k;
                oldResult = result[0];
            }

            result[1] = i;
            return result;
        }

        static double Fact(int number, int start = 1, double del = 1, int number2 = 0, int start2 = 1)
        {
            double result = 1;
            int j = 1;
            start = start <= 0 ? 1 : start;
            for (int i = start; i <= number; i++)
            {
                result *= i / del / (j < number2 ? start2 + j : 1);
                if (j < number2) j++;
            }
            return result;
        }
    }
}
