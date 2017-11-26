using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver;
using System.Numerics;

/*
Александр Скворцов

    4. Длинная арифметика
*/

namespace Ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Начало цикла
            do
            {
                Console.WriteLine("START");

                BigInteger expectedResult2 = BigInteger.Pow(10, 1);
                BigInteger expectedResult1 = BigInteger.Pow(9, 1);

                Console.WriteLine(BigInteger.Compare(expectedResult1, expectedResult1));

                int[] input = GetInput();
                var a = LongArithmetic.Compare(
                    LongArithmetic.Pow(input[0], input[1]), 
                    LongArithmetic.Pow(input[2], input[3])
                    );
                Console.Write("Число: ");
                foreach (var m in a[0]) Console.Write(m);
                Console.Write("\nБольше на ");
                foreach (var m in a[1]) Console.Write(m);

                Console.WriteLine("\n#Enter any character to complete");
            } while (Console.ReadLine().Length != 1);
        }

        static int[] GetInput()
        {
            Console.WriteLine("Enter the numbers: ");
            string[] numbersString = Console.ReadLine().Trim(' ').Split(' ');
            int[] numbers = new int[4];
            for (int i = 0; i < numbers.Length; i++)
                if (numbersString.Length <= i)
                    numbers[i] = 0;
                else
                    numbers[i] = Convert.ToInt32(numbersString[i]);
            return numbers;
        }
    }
}
