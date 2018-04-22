using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonInsertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            TestInsertionSort(15, 1);
            Console.Read();
        }

        /// <summary>
        /// Тестирует функцию сортировки
        /// </summary>
        /// <param name="len">Количество элементов тестового массива</param>
        /// <param name="numberTests">Количество тестов</param>
        public static void TestInsertionSort(int len, int numberTests)
        {
            Random rnd = new Random();
            var testArray = new int[len];
            for (int j = 0; j < numberTests; j++)
            {
                for (int i = 0; i < testArray.Length; i++)
                    testArray[i] = rnd.Next(51) - 25;

                InsertionSort(testArray);

                foreach (var item in testArray)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Сортирует массив
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        /// <returns>Отсортированный массив</returns>
        static int[] InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
    }
}
