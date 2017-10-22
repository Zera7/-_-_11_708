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

namespace Ex_1
{
    class Program
    {
        static void Main() {

            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");

                int[] range = GetRange();
                Console.WriteLine("Result: " + GetSum(array, range[0], range[1]));

                //Вывод результата и конец цикла
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static int[] GetRange() {
            Console.WriteLine("Enter the range: ");
            string[] numbersString = Console.ReadLine().Split(' ');
            int[] numbers = new int[2];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = Convert.ToInt32(numbersString[i]);
            return numbers;
        }

        static List<int> GetAdditionalArray(int[] array) {
            int a = array.Length / 4;

            List<int> list = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 4 == 0)
                {
                    list.Add(array[i]);
                }
                else
                    list[list.Count - 1] += array[i];
            }
            return list;
        }

        static int GetSum(int[] array, int from, int to) {
            List<int> list = GetAdditionalArray(array);
            Console.WriteLine("Sum of numbers: ");
            for (int i = from; i <= to; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
            int sum = 0;
            // Проверка
            for (int i = from; i <= to; i++)
                sum += array[i];
            Console.WriteLine("Test: " + sum);
            // Проверка
            sum = 0;
            if (to - from > 4)
            {
                int index = 0;
                if (from % 4 != 0) {
                    index = 4 - from % 4 + from;
                    for (int i = from; i < index; i++)
                        sum += array[i];
                    from += 4 - from % 4;
                }
                if ((to + 1) % 4 != 0) {
                    index = to - to % 4;
                    for (int i = index; i <= to; i++)
                        sum += array[i];
                    to -= to % 4;
                }
                index = (to + 1) / 4;
                for (int i = from / 4; i < index; i++) {
                    sum += list[i];
                }
            }
            else
                for (int i = from; i <= to; i++)
                    sum += array[i];
            return sum;
        }
    }
}
