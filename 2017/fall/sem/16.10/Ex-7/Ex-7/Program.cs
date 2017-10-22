using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   Александр Скворцов

       Col7. * 1510 Порядок Дан массив, более половины элементов которого равны X. X неизвестно, нужно его найти. 
       Можно ли решить задачу, не используя дополнительных коллекций (массивов, списков, словарей)
   */

namespace Ex_7
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] array = { 1, 1, 1, 2, 4, 1, 1, 5, 1, 1, 5, 1, 2 };
            for (int i = 0; i < array.Length - 1; i++) {
                if (array[i] <= int.MaxValue)
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] != array[j] && array[j] != long.MaxValue)
                        {
                            array[i] = long.MaxValue;
                            array[j] = long.MaxValue;
                            break;
                        }
                    }
            }
            for (int i = 0; i < array.Length; i++)
                if (array[i] != long.MaxValue) {
                    Console.WriteLine("RESULT: {0}", array[i]);
                    break;
                }
        }
    }
}
