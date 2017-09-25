using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
  Александр Скворцов

      Вариант 15
      4. Считывая числа пока не встретится 0, найти длину самой длинной последовательности чётных чисел
  */

namespace ex_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Цикл выполняется пока не вводится какое-либо значение в end
            string end;
            do
            {
                Console.WriteLine("START \n#Введите числа по одному, программа посчитает максимальную последовательность четных чисел");
                int result = 0;
                int number = 0;
                int input = 0;

                //Цикл ввода
                do
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    number = input % 2 == 0 && input != 0 ? number + 1 : 0;
                    result = number > result ? number : result;
                } while (input != 0);

                //Вывод результата, выбор продолжить/завершить
                Console.WriteLine("RESULT: " + result + "\n#Введите что-нибудь чтобы прекратить выполнение программы");
                end = Console.ReadLine();
            } while (end == "");
        }
    }
}