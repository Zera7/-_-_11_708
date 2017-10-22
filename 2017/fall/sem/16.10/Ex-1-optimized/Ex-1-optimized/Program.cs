using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Col1. 1330 Интервалы 
    Дан массив. Сделав его предобработку, научиться быстро находить сумму чисел на отрезке [L, R].
*/

namespace Ex_1_optimized
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            int[] newArray = GetAdditionalArray(array);
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + GetSum(newArray) + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static int[] GetRange()
        {
            Console.WriteLine("Enter the range: ");
            string[] numbersString = Console.ReadLine().Split(' ');
            int[] numbers = new int[2];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = Convert.ToInt32(numbersString[i]);
            return numbers;
        }

        static int[] GetAdditionalArray(int[] array)
        {
            int[] newArray = new int[array.Length];
            int sum = 0;
            for (int i = 0; i < array.Length; i++) {
                sum += array[i];
                newArray[i] = sum;
            }
            return newArray;
        }

        static int GetSum(int[] array)
        {
            int[] fromTo = GetRange();
            return array[fromTo[1]] - (fromTo[0] > 0 ? array[fromTo[0] - 1] : 0);
        }
    }
}
