using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Loops3.	Если все числа натурального ряда записать подряд каждую цифру в своей позиции, то необходимо ответить на вопрос: 
    какая цифра стоит в заданной позиции N.
*/

namespace Ex_3
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
                int currentNumber = 0;
                int digit = 1;
                int iterator = 0;
                int result = 0;
                bool error = number < 1;

                if (!error)
                {
                    do
                    {
                        iterator++;
                        if (iterator >= Math.Pow(10, digit)) digit++;
                        currentNumber += digit;
                    } while (currentNumber < number);

                    digit = currentNumber - number;

                    for (int i = 0; i < digit; i++)
                    {
                        iterator /= 10;
                    }
                    result = iterator % 10;

                    //Вывод результата и конец цикла
                    Console.WriteLine("RESULT: " + result + "\n\n");
                }
                else
                    Console.WriteLine("Выход за диапазон значений");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
