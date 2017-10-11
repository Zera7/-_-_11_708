using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов
*/

namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayReverse();
            //ArrayShift();
            //SomeFunction();
            //SomeFunction2();
        }

        // 1. Не используя других массивов, переставить элементы целочисленного массива в обратном порядке.
        static void ArrayReverse() {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int arrayLength = array.Length;
            int buffer = 0;
            for (int i = 0; i < arrayLength / 2; i++)
            {
                buffer = array[i];
                array[i] = array[arrayLength - i - 1];
                array[arrayLength - i - 1] = buffer;
            }
            foreach (int elem in array) Console.Write(elem + " ");
            Console.Read();
        }

        // 2. Значения массива сдвинуть циклически вправо на одну позицию так, чтобы последний элемент стал первым.
        // 3. Значения массива сдвинуть циклически вправо на k позиций.
        static void ArrayShift() {
            int shift = 2;
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int arrayLength = array.Length;
            int buffer = 0;
            for (int j = 0; j < shift; j++)
                for (int i = arrayLength - 1; i > 0; i--)
                {
                    buffer = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = buffer;
                }
            foreach (int elem in array) Console.Write(elem + " ");
            Console.WriteLine();
            Console.Read();
        }

        //4. Двумерный массив размера n x n содержит только положительные значения. 
        //Замените на ноль значения всех элементов, расположенных на главной и на побочной диагоналях. 
        //Главная диагональ идет из верхнего левого угла в правый нижний угол, побочная диагональ идет из 
        //верхнего правого в левый нижний угол.

        static void SomeFunction() {
            int[,] array = { 
                { 1, 2, 3 }, 
                { 4, 5, 6 }, 
                { 7, 8, 9}
            };
            int arrayRowLength = (int)Math.Sqrt(array.Length);
            for (int i = 0; i < arrayRowLength; i++)
            {
                for (int j = 0; j < arrayRowLength; j++)
                {
                    if (i == j) array[i, j] = 0;
                    if (j + i == arrayRowLength - 1) array[i, j] = 0;
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
            Console.Read();
        }

        //5. Двумерный массив размера n x n содержит не равные нулю значения. 
        //Замените на ноль значения всех элементов, расположенные выше побочной диагонали.

        static void SomeFunction2() {
            int[,] array = {
                { 1,2,3},
                { 4,5,6},
                { 7,8,9}
            };
            int arrayLength = (int)Math.Sqrt(array.Length);
            for (int i = 0; i < arrayLength; i++)
                for (int j = 0; j < arrayLength - i - 1; j++)
                    array[i, j] = 0;
        }
    }
}
