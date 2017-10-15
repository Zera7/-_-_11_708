using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Arr2. Перевести число из системы счисления с основанием A в систему с основанием B.
    Можно считать, что 2 ≤ A, B ≤ 10, а число дано в виде массива цифр.
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
                Console.WriteLine("Ввод начальной системы счисления: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ввод конечной системы счисления: ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ввод числа: ");
                string number = Console.ReadLine();
                number = number.TrimStart('0');

                int result = 0;
                if (a > 1 && b <= 10)
                    result = GetConvertedNumber(number, a, b);
                else
                {
                    Console.WriteLine("нет\n\n");
                    continue;
                }


                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static int GetConvertedNumber(string number, int a, int b) {
            int newNumber = 0;
            int result = 0;
            int digit = 1;
            if (a != 10)
                for (int i = 0; i < number.Length; i++)
                {
                    newNumber += Convert.ToInt32(number[number.Length - i - 1].ToString()) * (int)Math.Pow(a, i);
                }
            else
                newNumber = Convert.ToInt32(number);

            while (newNumber / b > 0 || newNumber % b != 0) {
                result += newNumber % b * digit;
                newNumber /= b;
                digit *= 10;
            }
            return result;
        }
    }
}
