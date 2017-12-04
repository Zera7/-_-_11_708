using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Вариант 15
    1. Дана пара двух четырёхзначных чисел (цифры внутри каждого числа не повторяются). 
    Определить число «коров» в паре – цифр не на своём месте, но присутствующих в другом числе
*/

namespace ex_1_1
{
    class Program
    {
        const int InputLength = 4;

        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");

                int input1 = Convert.ToInt32(Console.ReadLine());
                int input2 = Convert.ToInt32(Console.ReadLine());

                int result = 0;

                for (int i = 0; i < InputLength - 1; i++) {
                    int answer = GetCowNumber(GetNumber(input1, i), input2);
		    // ---check--- зачем такие конструкции { }?
		    // if (answer != -1 && answer != i) result++;
                    if (answer == -1 || answer == i) { }
                    else result++;
                }

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);

        }

        //Определяет цифру в числе по порядковому номеру
        //Принимает число и порядковый номер
        //Возврашает цифру
        static int GetNumber(int input1, int number) {
            number = InputLength - number;
            return (input1 % (int)(Math.Pow(10, number)) / (int)Math.Pow(10, number - 1));
        }

        //Проверка на наличие цифры на роль коровы из другого числа
        //Принимает проверяемую цифру и число в котором выполняется проверка
        //Возвращает порядковый номер числа при совподении, если совпадений не найдено, возвращает -1
        static int GetCowNumber(int number, int input2) {
            for (int i = 0; i < InputLength; i++){
                if (number == GetNumber(input2, i)) return i;
            }
            return -1;
        }
    }
}
