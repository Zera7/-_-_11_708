using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class CalcIntegral
    {
        public static double a = 0.5, b = 2;

        public static double CalcIntegralMK(int n)
        {
            double result = 0;
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                result += GetFx(rnd.NextDouble() * (b - a) + a);
            }
            return result * ((b - a) / n);
        }

        public static double CalcIntegralSimpson(int n)
        {
            double result = 0;
            double h = (b - a) / (2 * n);
            double x = 0;
            result += GetFx(a);
            result += GetFx(b);
            result += 4 * GetFx(GetXSimpson(a, 2 * n - 1, h));
            for (int i = 1; i <= n; i++)
            {
                x = GetXSimpson(a, 2 * i - 1, h);
                result += 4 * GetFx(x);
                x = GetXSimpson(a, 2 * i, h);
                result += 2 * GetFx(x);
            }
            return result * h / 3;
        }

        private static double GetXSimpson(double a, int number, double h)
        {
            return a + number * h;
        }

        public static double CalcIntegralTrapeze(int n)
        {
            double result = 0;
            double x = 0;
            double h = (b - a) / n;
            for (int i = 1; i < n; i++)
            {
                x = a + i * h;
                result += GetFx(x);
            }
            result += GetFx(a) / 2;
            result += GetFx(b) / 2;
            return result * h;
        }

        public static double CalcIntegralRightRect(int n)
        {
            double result = 0;
            double x = 0;
            double h = (b - a) / n;
            for (int i = 1; i <= n; i++)
            {
                x = a + i * h;
                result += GetFx(x);
            }
            return result * h;
        }

        public static double CalcIntegralLeftRect(int n)
        {
            double result = 0;
            double x = 0;
            double h = (b - a) / n;
            for (int i = 0; i < n; i++)
            {
                x = a + i * h;
                result += GetFx(x);
            }
            return result * h;
        }

        static double GetFx(double x)
        {
            return Math.Cos(1 / x + x * x / 4);
        }
    }
}
