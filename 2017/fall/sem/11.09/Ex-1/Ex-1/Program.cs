using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Александр Скворцов

    Expr1. Как поменять местами значения двух переменных? 
    Можно ли это сделать без ещё одной временной переменной. 
    Стоит ли так делать?
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

                int input1 = Convert.ToInt32(Console.ReadLine());
                int input2 = Convert.ToInt32(Console.ReadLine());

                input2 = input2 - input1;
                input1 = input1 + input2;
                input2 = input1 - input2;

                Console.WriteLine("RESULT1: " + input1);
                Console.WriteLine("RESULT2: " + input2);

                //Вывод результата и конец цикла
                Console.WriteLine("\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);

        }
    }
}
