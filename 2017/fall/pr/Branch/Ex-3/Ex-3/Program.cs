using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_3
{
    class Program
    {

        public static class DistanceTask
        {

            public static double GetDistance(double x1, double y1, double x2, double y2)
            {
                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }

            public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
            {
                //Проверено на GetDistanceToSegment(0,0,11,0,6,0) == 0;
                double distanceXA = GetDistance(x, y, ax, ay);
                double distanceXB = GetDistance(x, y, bx, by);
                double distanceAB = GetDistance(ax, ay, bx, by);
                //Проеверяем тупой угол В или нет
                //Узнаем, что больше: сумма квадратов сторон АВ и ХВ или квадрат ХА
                //if (distanceXA >= GetDistance(distanceXB, distanceAB, 0, 0))
                if (Math.Pow(distanceXA, 2) >= Math.Pow(distanceXB, 2) + Math.Pow(distanceAB, 2))
                    return distanceXB;
                //То же самое для угла А
                //else if (distanceXB >= GetDistance(distanceXA, distanceAB, 0, 0))
                else if (Math.Pow(distanceXB, 2) >= Math.Pow(distanceXA, 2) + Math.Pow(distanceAB, 2))
                    return distanceXA;
                else
                {
                    double a = by - ay;
                    double b = ax - bx;
                    double c = -ax * (by - ay) + ay * (bx - ax);
                    double t = GetDistance(a, b, 0, 0);

                    double perpendicular = (a * x + b * y + c) / t;
                    return Math.Abs(perpendicular);
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine(GetDistanceToSegment(0, 0, 11, 0, 4, 0));
                Console.Read();
            }
        }
    }
}

