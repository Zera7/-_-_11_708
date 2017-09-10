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
            //Цикл выполняется пока не вводится какое-либо значение в end
            string end;
            do
            {
                Console.WriteLine("START \n#Введите число");

                int number = Convert.ToInt32(Console.ReadLine());

                string answer = "";

                //Перевод в биты
                answer = Convert.ToString(number,2);


                //Вывод результата, выбор продолжить/завершить
                Console.Write("ANSWER: ");
                    reverse(answer);  
                    Console.WriteLine("\n#Введите что-нибудь чтобы прекратить выполнение программы");
                end = Console.ReadLine();
            } while (end == "");
        }

        //Вывод строки с битами в обратном порядке
        static void reverse(string answer) {
            int answer_length = answer.Length;
            for (int i = 0; i < answer_length; i++) {
                Console.Write(answer[answer_length-i-1]);
            }
        }
    }
}

    