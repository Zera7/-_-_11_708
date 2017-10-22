using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Col4. В массиве чисел найти подмассив длины m с максимальной суммой. 
    Запрещается использовать другие массивы.

*/

namespace Ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 100, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");

                GetMaxSubarray(array);

                //Вывод результата и конец цикла
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);

        }

        static int[] GetInput()
        {
            Console.WriteLine("Enter the numbers: ");
            string[] numbersString = Console.ReadLine().Split(' ');
            int[] numbers = new int[1];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = Convert.ToInt32(numbersString[i]);
            return numbers;
        }

        private static void GetMaxSubarray(int[] array)
        {
            int maxSum = 0, bufferSum = 0;
            int subArrayLength = GetInput()[0];
            for (int i = 0; i < array.Length; i++) {
                if (i >= subArrayLength)
                    bufferSum -= array[i - subArrayLength];
                bufferSum += array[i];
                maxSum = maxSum < bufferSum ? bufferSum : maxSum;
            }
            Console.WriteLine("\nMax sum = {0}\n\n", maxSum);
        }
    }
}
