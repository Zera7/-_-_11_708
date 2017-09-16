using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Expr7. Найти вектор, параллельный прямой. Перпендикулярный прямой.
*/

namespace Ex_7
{
    class Program
    {
        static void Main()
        {
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");
                Console.WriteLine("Введите a, b, c");

                int input1 = Convert.ToInt32(Console.ReadLine());
                int input2 = Convert.ToInt32(Console.ReadLine());
                int input3 = Convert.ToInt32(Console.ReadLine());

                //Расчет ответа. Вывод
                Console.WriteLine("RESULT: ");
                Console.WriteLine("Вектор, параллельный прямой: ({0}, {1})", input1, input2);

                Console.WriteLine("Вектор, перпендикулярный прямой: ({0}, {1})", 1, -1.0 * input1 / input2);

                //Вывод результата и конец цикла
                Console.WriteLine("\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
 