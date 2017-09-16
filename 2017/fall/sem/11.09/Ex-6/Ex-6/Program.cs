using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Expr6. Посчитать расстояние от точки до прямой, заданной двумя разными точками.
*/

namespace Ex_6
{
    class Program
    {
        //Задаём структуру point
        public struct point {
            public int x;
            public int y;
        }

        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");
                
                //Вводим точки
                Console.WriteLine("Введите 1 точку прямой");
                point input1;
                input1.x = Convert.ToInt32(Console.ReadLine());
                input1.y = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите 2 точку прямой");
                point input2;
                input2.x = Convert.ToInt32(Console.ReadLine());
                input2.y = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите координаты 3 точки");
                point input3;
                input3.x = Convert.ToInt32(Console.ReadLine());
                input3.y = Convert.ToInt32(Console.ReadLine());

                //Вычисляем расстояние
                double result = Math.Abs((input1.y-input2.y) * input3.x +(input2.x - input1.y) * input3.y +(input1.x*input2.y - input2.x*input1.y));
                result /= Math.Sqrt(Math.Pow((input2.x - input1.x), 2) + Math.Pow((input2.y - input1.y), 2));

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
