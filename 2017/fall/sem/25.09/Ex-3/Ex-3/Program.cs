using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Cond3. (1493. В одном шаге от счастья) Дан номер трамвайного билета, 
    в котором суммы первых трёх цифр и последних трёх цифр отличаются на 1 (но не сказано, в какую сторону). 
    Правда ли, что предыдущий или следующий билет счастливый?
*/

namespace Ex_3
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

                int number = Convert.ToInt32(Console.ReadLine());

                bool result = false;

                if (!result) result = IsHappyTicket(number + 1);
                if (!result) result = IsHappyTicket(number - 1);

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static bool IsHappyTicket(int number) {

            int a = 0;
            int b = 0;

            b += number % 10; number /= 10;
            b += number % 10; number /= 10;
            b += number % 10; number /= 10;

            a += number % 10; number /= 10;
            a += number % 10; number /= 10;
            a += number % 10; number /= 10;

            return a - b == 0;
        }
    }
}
