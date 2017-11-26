using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using solver;

/*
 Александр Скворцов

     1. Вычислить сумму ряда
 */

namespace Ex_1
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

                //Console.WriteLine("Ввод Х и точности: ");
                Console.WriteLine(Ex1.F2(1, 0.000003)[1]);

                //Вывод результата и конец цикла
                Console.WriteLine("\n\n#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
