using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Expr3. Задано время Н часов (ровно). Вычислить угол в градусах между часовой и минутной стрелками. 
    Например, 5 часов -> 150 градусов, 20 часов -> 120 градусов. 
    Не использовать циклы.
*/

namespace Ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Начало цикла (Это только для удобства)
            string end = "";
            do
            {
                Console.WriteLine("START");

                int input1 = Convert.ToInt32(Console.ReadLine());
                input1 = input1 > 12 ? input1 - 12 : input1;
                int result = input1 * (360/12);
                result = result > 180 ? 360 - result : result;

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
