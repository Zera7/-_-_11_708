using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
    Александр Скворцов

        Вариант 15
        3. Вывести биты натурального числа n в обратном порядке (n<=10^9)
    */

namespace ex_1_3
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

                int number = Convert.ToInt32(Console.ReadLine());

                Console.Write("RESULT: ");
                for (int i = 0; i < 32; i++)
                {
                    //Вывод результата
                    Console.Write((number & (1 << i)) >> i);
                }
                Console.WriteLine("\n");

            } while (end == "" || end.Length > 1);
        }
    }
}
