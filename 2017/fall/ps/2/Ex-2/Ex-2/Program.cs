using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex_2;
using Solver;

/*
Александр Скворцов

    2. Вычисление PI
*/

namespace Ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                double k = Convert.ToDouble(GetInput()[0]);
                if (k <= 0) k = 0.0000000000001;
                Console.WriteLine("result: " + Ex2.GetPI(k));
                Console.WriteLine("PI: " + Math.PI);

                //Вывод результата и конец цикла
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static double[] GetInput()
        {
            Console.WriteLine("Enter K: ");
            
            string[] numbersString = Console.ReadLine().Split(' ');
            double[] numbers = new double[1];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = Convert.ToDouble(numbersString[i]);
            return numbers;
        }

        
    }
}
