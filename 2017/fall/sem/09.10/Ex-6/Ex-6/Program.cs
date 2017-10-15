using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    6. Городские кварталы
*/

namespace Ex_6
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
                //если убрать -1 будет считать по количеству столбцов и строк
                //используется черная магия System.Numeric
                int a = Convert.ToInt32(Console.ReadLine()) - 1;
                int b = Convert.ToInt32(Console.ReadLine()) - 1;

                int result = 0;
                int g = (int)BigInteger.GreatestCommonDivisor(a, b);
                result = (a / g + b / g - 1) * (int)BigInteger.GreatestCommonDivisor(a, b);

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
