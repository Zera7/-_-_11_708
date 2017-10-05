using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Loops2.	Дано N (1 ≤ N ≤ 27). Найти количество трехзначных натуральных чисел, сумма цифр которых равна N. 
    Операции деления (/, %) не использовать.
*/

namespace Ex_2
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

                int number = Convert.ToInt32(Console.ReadLine());
                bool outOfBounds = number < 1 || number > 27; ;
                int result = 0;

                if (!outOfBounds)
                {
                    for (int i = 1; i <= 9; i++)
                        for (int j = 0; j <= 9; j++)
                            for (int k = 0; k <= 9; k++)
                                if (i + j + k == number)
                                {
                                    result++;
                                    //Console.WriteLine("{0}{1}{2}", i, j, k);
                                }
                if (!outOfBounds)Console.WriteLine("RESULT: " + result + "\n\n");
                }
                else
                    Console.WriteLine("Выход за границы значений");
                //Вывод результата и конец цикла
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
