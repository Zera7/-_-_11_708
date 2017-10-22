using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   Александр Скворцов

       Col6. * Даны два массива из целых чисел от 1 до 100: длины n и длины N (n < N). 
       Определить для каждого подмассива второго массива длины n, является ли он перестановкой первого массива.
   */

namespace Ex_6
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] subArray = { 3, 2, 1 };
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 6, 4, 32 };

            bool stop = false;

            Dictionary<int, int> indexSubArray = GetIndexArray(subArray, subArray.Length);
            Dictionary<int, int> indexArray = GetIndexArray(array, subArray.Length);

            for (int i = 0; i < array.Length - subArray.Length && !stop; i++)
            {
                for (int j = 0; j < subArray.Length; j++)
                {
                    if (!indexArray.ContainsKey(subArray[j]) || indexArray[subArray[j]] != indexSubArray[subArray[j]]) {
                        stop = false;
                        break;
                    }
                    stop = true;
                }
                if (!stop)
                {
                    indexArray[array[i]]--;
                    if (indexArray.ContainsKey(array[i + subArray.Length]))
                        indexArray[array[i + subArray.Length]]++;
                    else
                        indexArray.Add(array[i + subArray.Length], 1);
                }
                else
                {
                    Console.WriteLine("YES");
                }
            }
            if (!stop) Console.WriteLine("NO");
        }

        private static Dictionary<int, int> GetIndexArray(int[] array, int lengthOfSubarray)
        {
            Dictionary<int, int> indexArray = new Dictionary<int, int>();
            for (int i = 0; i < lengthOfSubarray; i++)
            {
                if (!indexArray.ContainsKey(array[i]))
                    indexArray.Add(array[i], 1);
                else
                    indexArray[array[i]] += 1;
            }
            return indexArray;
        }
    }
}
