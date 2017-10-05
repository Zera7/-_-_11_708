using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Loops1.	Дано целое неотрицательное число N. 
    Найти число, составленное теми же десятичными цифрами, что и N, но в обратном порядке. 
    Запрещено использовать массивы.

*/

namespace Ex_1
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

                int result = GetNewNumber(number);

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static int GetNewNumber(int input)
        {
            int result = 0;
            int lengthOfNumber = GetLengthNumber(input);
            for (; lengthOfNumber > 0; lengthOfNumber--) {
                result += input % 10 * (int)Math.Pow(10, lengthOfNumber - 1);
                input /= 10;
            }

            return result;
        }

        static int GetLengthNumber(int number) {
            int lengthOfNumber = 0;
            while (number % 10 != 0)
            {
                number /= 10;
                lengthOfNumber++;
            }
            return lengthOfNumber;
        }
    }
}
