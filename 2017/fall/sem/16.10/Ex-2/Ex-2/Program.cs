using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("START");

                Console.WriteLine("Total number of knights: ");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] knights = new int[n];
                int[] arr = new int[n + 1];

                for (int i = 0; i < n + 1; i++)
                {
                    int[] data = GetInput();
                    arr[data[0] - 1] += data[2];
                    arr[data[1]] -= data[2];
                }

                Console.WriteLine("\nRESULT:");
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    sum += arr[i];
                    knights[i] += sum;
                    Console.Write(sum + " ");
                }

                //Вывод результата и конец цикла
                Console.WriteLine("\n\n#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static int[] GetInput()
        {
            Console.WriteLine("Enter the numbers: ");
            string[] numbersString = Console.ReadLine().Split(' ');
            int[] numbers = new int[3];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = Convert.ToInt32(numbersString[i]);
            return numbers;
        }
    }
}
