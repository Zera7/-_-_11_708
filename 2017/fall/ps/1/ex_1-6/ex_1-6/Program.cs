using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Александр Скворцов

      Вариант 15
      6. Найти максимальную длину последовательности натуральных чисел, равных в сумме числу n(n<=10^9). 
      Пример: 25 = 3+4+5+6+7 (длина 5)
  */


namespace ex_1_6
{
    class Program
    {
        static void Main(string[] args)
        {

            //Цикл выполняется пока не вводится какое-либо значение в end
            string end;
            do
            {
                Console.WriteLine("START \n#Введите число, программа посчитает максимальную последовательность чисел, чья сумма будет равна введенному");

                int answer = 0;
                int n = Convert.ToInt32(Console.ReadLine());
                string text = "";
                string text2 = "";

                //Цикл вычисления последовательности
                for (int i = 1; i < n; i++) {
                    int count = 0;
                    text = "";
                    for (int j = i; j < n; j++) {
                        count += j;
                        text += j + " ";
                        if (count > n) break;
                        if (count == n) {
                            if (answer > j - i + 1)
                            {
                            }
                            else 
                            {
                                answer = j - i + 1;
                                text2 = text;
                            }
                            break;
                        }
                        if (answer > count) break;
                    }
                }

                //Вывод результата, выбор продолжить/завершить
                Console.WriteLine("ANSWER: " + "( " + text2 + ") = " + n + " (" + answer + " чисел)" + "\n#Введите что-нибудь чтобы прекратить выполнение программы");
                end = Console.ReadLine();
            } while (end == "");
        }
    }
}



