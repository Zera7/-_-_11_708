using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Loops5. Дана строка из символов '(' и ')'. 
    Определить, является ли она корректным скобочным выражением. 
    Определить максимальную глубину вложенности скобок.
*/

namespace Ex_5
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

                string input1 = Console.ReadLine();
                int inputLength = input1.Length;

                int result = 0;
                int current = 0;
                bool correct = true;

                for (int i = 0; i < inputLength && correct; i++) {
                    if (input1[i] == '(') current++;
                    else current--;
                    if (current < 0) correct = false;
                    result = result < current ? current : result;
                }
                if (current != 0) correct = false;

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: {0};\nCORRECT: {1}\n\n", result, correct);
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
