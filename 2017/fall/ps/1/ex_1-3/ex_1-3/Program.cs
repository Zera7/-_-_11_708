using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
    Александр Скворцов

        Вариант 15
        3. Вывести биты натурального числа n в обратном порядке (n<=10^9)
    */

namespace ex_1_3
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
                int input_length = 0;
                int input1 = Convert.ToInt32(Console.ReadLine());

                //Вычисление количества разрядов числа
                for (int i = 0; input1 / Math.Pow(10, i) >= 1; i++) input_length++;

                Console.Write("RESULT: ");
                for (int i = input_length-1; i >= 0 ; i--) {
                    get_bin(get_number(input1, i, input_length));
                }

                //Вывод результата и конец цикла
                Console.WriteLine("\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        //Превращает dec в bin
        //Получает цифру
        //Возвращает ее в двоичном представлении
        static void get_bin(int number) {
            int answer = 0, help = number, number_length = -1;
            for (int i = 0; i<8; i++) {
                answer += ((help % 2) * (int)Math.Pow(10 ,8-i-1));
                if (help % 2 == 1 && number_length == -1) {
                    number_length = i;
                }
                help = help/2;

            }
            answer += help % 2;

            for (int i = 0; i < number_length; i++) Console.Write("0");
            Console.Write(answer);
        }

        //Определяет цифру в числе по порядковому номеру
        //Принимает число и порядковый номер
        //Возврашает цифру
        static int get_number(int input1, int number, int input1_length)
        {
            number = input1_length - number;
            return input1 % (int)(Math.Pow(10, number)) / (int)Math.Pow(10, number - 1);
        }
    }
}

    