using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Expr8. Дана прямая L и точка A. Найти точку пересечения прямой L с перпендикулярной ей прямой P, проходящей через точку A.
*/

namespace Ex_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                //Ввод уравнения прямой
                Console.WriteLine("START");
                Console.WriteLine("Введите a,b,c");

                double input1 = Convert.ToDouble(Console.ReadLine());
                double input2 = Convert.ToDouble(Console.ReadLine());
                double input3 = Convert.ToDouble(Console.ReadLine());

                //Ввод координаты точки,
                Console.WriteLine("Введите координаты точки");

                double input4 = Convert.ToDouble(Console.ReadLine());
                double input5 = Convert.ToDouble(Console.ReadLine());

                if (input1 == 0 && input2 == 0)
                {
                    Console.WriteLine("#Коэффициенты уравнения а и b не могут быть равны нулю одновременно");
                }
                else if (input2 == 0)
                {
                    Console.WriteLine("RESULT: (" + -input3 / input1 + ", " + input5 + ")");
                }
                else if (input1 == 0)
                {
                    Console.WriteLine("RESULT: (" + input4 + ", " + -input3 / input2 + ")");
                }
                else
                {
                    double y = (input1 * input1 * input5 - input1 * input2 * input4 - input2 * input3) / (input1 * input1 + input2 * input2);
                    double x = -(input2 * y + input3) / input1;
                    Console.WriteLine("RESULT: (" + x + ", " + y + ")");
                }


                //Конец цикла
                Console.WriteLine("\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}