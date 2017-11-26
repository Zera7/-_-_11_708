using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver;

/*
Александр Скворцов

    Интегралы 
*/

namespace Ex_3
{
    class Program
    {

        static void Main(string[] args)
        {
            //Начало цикла
            do
            {
                Console.WriteLine("START");

                int n = GetInput();
                Console.WriteLine("Метод левых прямоугольников: " + CalcIntegral.CalcIntegralLeftRect(n));
                Console.WriteLine("Метод правых прямоугольников: " + CalcIntegral.CalcIntegralRightRect(n));
                Console.WriteLine("Метод трапеций: " + CalcIntegral.CalcIntegralTrapeze(n));
                Console.WriteLine("Метод Симпсона: " + CalcIntegral.CalcIntegralSimpson(n));
                Console.WriteLine("Метод Монте-Карло: " + CalcIntegral.CalcIntegralMK(n));

                Console.WriteLine("\n#Enter any character to complete\n");
            } while (Console.ReadLine().Length != 1);
        }

        static int GetInput()
        {
            int n;
            Console.WriteLine("Enter the numbers: ");
            while (!int.TryParse(Console.ReadLine(), out n));
            return n;
        }
    }
}
