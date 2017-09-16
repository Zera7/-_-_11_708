using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Expr4. Найти количество чисел меньших N, которые имеют простые делители X или Y.
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

                int input1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите делители");
                int input2 = Convert.ToInt32(Console.ReadLine());
                int input3 = Convert.ToInt32(Console.ReadLine());

                int result = 0;
                int result2 = 0;

                if (input2 != input3)
                    result = ((input1 - 1) / input2 + (input1 - 1) / input3) - ((input1 - 1) / (input2 * input3));
                else
                    result = (input1 - 1) / input2;

                /*
                for (int i = 1; i < input1; i++) {
                    if (i % input2 == 0 || i % input3 == 0) result2++;
                }
                */

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                //if (result != result2) Console.WriteLine("ОШИБКА " + result + " " + result2);
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
