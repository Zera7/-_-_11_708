using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Col3. 1296 Гиперпереход 
    В массиве чисел найти подмассив (непрерывный отрезок исходного массива) с максимальной суммой.
*/

namespace Ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { -1, 1, 0 };
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

        private static void GetMaxSubarray(int[] array)
        {
            int minIndex = 0, bufferMinIndex = -1;
            int maxIndex = 0, bufferMaxIndex = 0;
            int maxSum = int.MinValue, bufferMaxSum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    if (bufferMinIndex == -1)
                        bufferMinIndex = i;
                    bufferMaxIndex = i;
                    bufferMaxSum += array[i];

                    if (maxSum < bufferMaxSum)
                    {
                        maxIndex = bufferMaxIndex;
                        minIndex = bufferMinIndex;
                        maxSum = bufferMaxSum;
                    }
                }
                else
                {
                    if (bufferMaxSum + array[i] > 0)
                    {
                        bufferMaxIndex = i;
                        bufferMaxSum += array[i];
                    }
                    else
                    {
                        if (maxSum < bufferMaxSum)
                        {
                            maxIndex = i;
                            minIndex = i;
                            maxSum = array[i];
                        }
                        bufferMinIndex = -1;
                        bufferMaxIndex = 0;
                        bufferMaxSum = 0;
                    }
                }
            }
            Console.Write("\nMax sum = {0} on indeces: {1} - {2}\n\n", maxSum, minIndex, maxIndex);
        }
    }
}
