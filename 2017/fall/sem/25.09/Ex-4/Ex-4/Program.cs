using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Cond4. Пересечение двух отрезков [A,B] и [C,D] на числовой прямой. 
    Найти красивое решение, то есть наиболее ясное и краткое.
*/

namespace Ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");

                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                int c = Convert.ToInt32(Console.ReadLine());
                int d = Convert.ToInt32(Console.ReadLine());

                int result = 0;

                if (a <= c)
                {
                    result = d <= b ? d - c : b - c;
                }
                else {
                    result = b <= d ? b - a : d - a;
                }
                result = result < 0 ? 0 : result;

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
