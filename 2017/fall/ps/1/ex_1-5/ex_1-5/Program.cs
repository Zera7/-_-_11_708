using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Вариант 15
    5. Найти сумму четырехзначных чисел, у которых значение равно сумме четвёртых степеней их цифр
    (Найти сумму цифр четырехзначного числа, получаемом при сложении четвертых степеней его цифр)
*/

namespace ex_1_5
{
    class Program
    {
        const int input1_length = 4;
        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");

                for (int i = 1000; i <= 9999; i++) {
                    int result = 0;
                    for (int j = 0; j < input1_length; j++) {
                        result += (int)Math.Pow(get_number(i, j), 4);
                    }
                    if (i == result)
                    {
                        Console.WriteLine("RESULT: " + result);
                    }
                }

                //Вывод результата и конец цикла
                Console.WriteLine("\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);

        }

        //Определяет цифру в числе по порядковому номеру
        //Принимает число и порядковый номер
        //Возврашает цифру
	// ---check--- плохое название методов
        static int get_number(int input1, int number)
        {
            number = input1_length - number;
            return (input1 % (int)(Math.Pow(10, number)) / (int)Math.Pow(10, number - 1));
        }
    }
}
