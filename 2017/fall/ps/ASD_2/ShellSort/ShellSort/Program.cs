using System;
using System.Collections;

namespace Shell_Sort
{
    public class SortShell
    {
        static void Main(string[] args)
        {
            TestShellSort(15, 1);
            Console.Read();
        }

        /// <summary>
        /// Тестирует функцию сортировки
        /// </summary>
        /// <param name="len">Количество элементов тестового массива</param>
        /// <param name="numberTests">Количество тестов</param>
        public static void TestShellSort(int len, int numberTests)
        {
            Random rnd = new Random();
            var testArray = new int[len];
            for (int j = 0; j < numberTests; j++)
            {
                for (int i = 0; i < testArray.Length; i++)
                    testArray[i] = rnd.Next(51) - 25;

                ShellSort(testArray);

                foreach (var item in testArray)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Сортирует массив
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        static void ShellSort(int[] array)
        {
            int i, j, step, temp;
            step = 3;
            while (step > 0)
            {
                for (i = step; i < array.Length; i++)
                {
                    j = i;
                    temp = array[i];
                    while (j >= step && array[j - step] > temp)
                    {
                        array[j] = array[j - step];
                        j = j - step;
                    }
                    array[j] = temp;
                }
                if (step > 2) step /= 2;
                else if (step == 1) step = 0;
            }
        }
    }
}
