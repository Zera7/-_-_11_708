using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._09
{
    class Program
    {
        static void Main(string[] args)
        {
            string end = "";
            do {
                Console.WriteLine("START");

                int a = Convert.ToInt32(Console.ReadLine());

                int b = a % 10 * 100;
                b += a % 100 / 10 * 10;
                b += a / 100;

                Console.WriteLine("Введено: " + a + ", получено: " + b);

                Console.WriteLine("\n\nВведите любой символ для завершения");
                end = Console.ReadLine();
            } while (end =="");
        }
    }
}
