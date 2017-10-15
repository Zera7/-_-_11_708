using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

   Arr5. * Дан неубывающий массив положительных целых чисел. 
   Найти наименьшее положительное целое число, не представимое в виде суммы элементов этого массива 
   (каждый элемент разрешается использовать в сумме только один раз).
*/

namespace Ex_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 50 };
            int max = 0;
            for (int i = 0; i < array.Length && array[i] <= max + 1; i++)
                max += array[i];
            Console.WriteLine(max + 1);
            Console.Read();
        }
    }
}
