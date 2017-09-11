using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string end = "";
            do {
                Console.WriteLine("START");

                int input1 = Convert.ToInt32(Console.ReadLine());
                int input2 = Convert.ToInt32(Console.ReadLine());
                int result = 0;

                result = input2 / 4 - input1 / 4;

                result -= (input2 / 100 - input1 / 100);
                result += (input2 / 400 - input1 / 400);

                result = (input1 % 4 == 0 && input2 % 4 == 0) ? result + 1 : result;
                result = input1 == 0 ? result - 1 : result;

                Console.WriteLine("RESULT: "+result+"\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
