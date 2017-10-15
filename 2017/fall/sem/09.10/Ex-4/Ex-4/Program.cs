using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Arr4. Даны два неубывающих массива чисел. 
    Сформировать неубывающие массивы, являющиеся объединением,
    пересечением и разностью этих двух массивов (разность в смысле мультимножеств).
*/

namespace Ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 3, 10, 100, 100, 1000, 100000 ,100000000 };
            int[] array2 = { 1, 2, 3, 5, 6, 7, 100 };
            CombiningArrays(array1, array2);
            IntersectionArrays(array1, array2);
            DifferenceArrays(array1, array2);
            Console.Read();
        }

        //Объединение массивов
        static void CombiningArrays(int[] array1, int[] array2) {

            int[] bufferResult = new int[array1.Length + array2.Length];
            int[] result;

            int iterator = 0;

            int index1 = 0, index2 = 0;

            while (index1 < array1.Length && index2 < array2.Length)
            {
                if (array1[index1] == array2[index2])
                {
                    bufferResult[iterator] = array1[index1];
                    index1++;
                    index2++;
                }
                else if (array1[index1] > array2[index2])
                {
                    bufferResult[iterator] = array2[index2];
                    index2++;
                }
                else
                {
                    bufferResult[iterator] = array1[index1];
                    index1++;
                }
                iterator++;
            }

            if (index1 < array1.Length)
            {
                for (; index1 < array1.Length; index1++)
                {
                    bufferResult[iterator] = array1[index1];
                    iterator++;
                }
            }
            else if (index2 < array2.Length) {
                for (; index2 < array2.Length; index2++) {
                    bufferResult[iterator] = array2[index2];
                    iterator++;
                }
            }

            result = new int[iterator];
            for (int i = 0; i < iterator; i++)
            {
                result[i] = bufferResult[i];
            }
            foreach (int n in result) Console.Write(n + " ");
            Console.WriteLine();
        }


        //Пересечение массивов
        static void IntersectionArrays(int[] array1, int[] array2) {

            int[] bufferResult = new int[Math.Min(array1.Length, array2.Length)];
            int[] result;

            int iterator = 0;

            int index1 = 0, index2 = 0;

            while (index1 < array1.Length && index2 < array2.Length)
            {
                if (array1[index1] == array2[index2])
                {
                    bufferResult[iterator] = array1[index1];
                    index1++;
                    index2++;
                    iterator++;
                }
                else if (array1[index1] > array2[index2])
                {
                    index2++;
                }
                else
                {
                    index1++;
                }
            }

            result = new int[iterator];
            for (int i = 0; i < iterator; i++)
            {
                result[i] = bufferResult[i];
            }
            foreach (int n in result) Console.Write(n + " ");
            Console.WriteLine();
        }


        //Разность массивов
        static void DifferenceArrays(int[] array1, int[] array2) {

            bool[] bufferResult = new bool[array1.Length];
            int[] result;

            int iterator = 0;

            int index1 = 0, index2 = 0;

            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = index2; j < array2.Length; j++) {
                    if (array1[i] == array2[j])
                    {
                        bufferResult[i] = true;
                        index2 = j + 1;
                        iterator++;
                    }
                }
            }

            result = new int[array1.Length - iterator];
            for (int i = 0; i < array1.Length; i++)
            {
                if (!bufferResult[i])
                {
                    result[index1] = array1[i];
                    index1++;
                }
            }
            foreach (int n in result) Console.Write(n + " ");
            Console.WriteLine();
        }
    }
}
