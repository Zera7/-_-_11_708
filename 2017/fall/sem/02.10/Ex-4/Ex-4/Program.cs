using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Loops4. В массиве чисел найдите самый длинный подмассив из одинаковых чисел.
*/

namespace Ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");
                int result = 1;
                int currentMax = 1;
                int currentNumber = 0;
                int lastNumber = -1;

                do
                {
                    currentNumber = Convert.ToInt32(Console.ReadLine());
                    currentMax = currentNumber == lastNumber ? currentMax + 1 : 1;
                    result = result < currentMax ? currentMax : result;
                    lastNumber = currentNumber;
                } while (currentNumber != 0);

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
