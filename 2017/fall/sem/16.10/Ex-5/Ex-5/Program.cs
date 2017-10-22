using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   Александр Скворцов

       Col5. Даны два массива. 
       Входит ли первый массив во второй как подпоследовательность?
   */

namespace Ex_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 6, 7, 8, 10 };
            int[] subArray = { 8, 10 };

            if (IsSubArray(array, subArray))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
            
        }

        private static bool IsSubArray(int[] array, int[] subArray)
        {
            bool result = false;
            for (int i = 0; i < array.Length; i++) {
                for (int j = 0; j < subArray.Length; j++) {

                    if (i + j >= array.Length) {
                        result = false;
                        break;
                    }

                    if (array[i + j] == subArray[j])
                        result = true;
                    else
                    {
                        result = false;
                        break;
                    }
                }
                if (result) return true;
            }
            return false;
        }
    }
}
