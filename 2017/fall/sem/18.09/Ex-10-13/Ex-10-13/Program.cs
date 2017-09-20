using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Expr10. Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5.
    Expr11. Дано время в часах и минутах. Найти угол от часовой к минутной стрелке на обычных часах.
    Expr12. 1885. Комфорт пассажиров
    Expr13. 1084. Пусти козла в огород

*/

namespace Ex_10_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START");
            Expr12();
            Console.ReadLine();
        }
        //1
        static int SumX(int from, int to, int multiple) // количество чисел кратных x на [l, r)
        {
            from = (from % multiple == 0 ? from : from + multiple - from % multiple);
            to--;
            to = (to % multiple == 0 ? to : to - to % multiple);
            return (from + to) * ((to - from) / multiple + 1) / 2;
        }
        
        static void Expr10()
        {
            int result = SumX(1, 1000, 3) + SumX(1, 1000, 5) - SumX(1, 1000, 15);
            Console.WriteLine("RESULT: {0}", result);
        }

        //2
        static void Expr11() {
            int hours = Convert.ToInt32(Console.ReadLine());
            int minutes = Convert.ToInt32(Console.ReadLine());

            double result = Math.Abs(6 * minutes - (30 * hours + 0.5 * minutes));
            result = result > 180 ? 360 - result : result;
            Console.WriteLine("RESULT: {0}",result);
        }

        static void Expr12() {
            int h = 0, v = 0, x = 0;
            h = Convert.ToInt32(Console.ReadLine()); //Высота
            double t = Convert.ToInt32(Console.ReadLine()); //Время за которое надо успеть
            v = Convert.ToInt32(Console.ReadLine()); //Максимальная скорость подъема
            x = Convert.ToInt32(Console.ReadLine()); //Скорость при которой закладывает уши

            double minTime = (h - x * t) / (v - x); //Считаем минимальное время
            t = h / t >= x ? t : 0;                 //Считаем максимальное время

            Console.WriteLine("Min Time: {0}\nMax Time: {1}", minTime, t);
        }

        //4
        static void Expr13()
        {
            double a = Convert.ToInt32(Console.ReadLine());
            double radius = Convert.ToInt32(Console.ReadLine());
            if (radius <= a / 2)
                Console.WriteLine(Math.PI * radius * radius);
            else
            if (radius >= a / Math.Sqrt(2.0))
                Console.WriteLine(a * a);
            else
            {
                double angle = 0, angleokr = 0, square = 0, z = 0;
                z = Math.Sqrt(radius * radius - (a * a / 4.0));
                angle = Math.Atan(z / (a * 0.5)) * 180.0 / Math.PI;
                angleokr = 90.0 - 2 * angle;
                square = 4.0 * (z * (a / 2.0) + Math.PI * radius * radius * (angleokr / 360.0));
                Console.WriteLine(((int)(square * 1000)) / 1000.0);
            }
        }
    }
}