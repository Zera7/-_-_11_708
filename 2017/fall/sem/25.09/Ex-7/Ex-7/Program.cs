using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

   Cond7. ** (1484. Кинорейтинг) На сайте за фильм проголосовало N человек, 
   каждый поставил оценку от 1 до 10. Сейчас рейтинг фильма равен X (рейтинг — средняя оценка, 
   округлённая до десятых по математическим правилам, цифра 5 всегда округляется вверх). 
   Сколько минимум раз нужно поставить фильму оценку 1, чтобы его рейтинг гарантированно стал не выше Y? 
   В решении нельзя использовать циклы.
*/

namespace Ex_7
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

                char separator = ' ';
                string[] input = (Console.ReadLine()).Split(separator);
                if (input[0] == "") return;

                int x = int.Parse(input[0]);
                int y = int.Parse(input[1]);
                int n = int.Parse(input[2]);

                int result = 0;

                result = n*(y - x) / (1 - y);

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
