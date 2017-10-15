using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Arr1. Дан массив чисел. Нужно его сдвинуть циклически на K позиций вправо, 
    не используя других массивов.
*/

namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
