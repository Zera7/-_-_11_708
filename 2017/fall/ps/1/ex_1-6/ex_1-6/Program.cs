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

                int amountOfNumbers = 0;
                int number = Convert.ToInt32(Console.ReadLine());
                string bufferSequence = "";
                string sequence = "";

                //Цикл вычисления последовательности
                for (int i = 1; i < number; i++) {
                    int count = 0;
                    bufferSequence = "";
                    for (int j = i; j < number; j++) {
                        count += j;
                        bufferSequence += j + " ";
                        if (count > number) break;
                        if (count == number) {
                            if (amountOfNumbers <= j - i + 1) 
                            {
                                amountOfNumbers = j - i + 1;
                                sequence = bufferSequence;
                            }
                            break;
                        }
                        if (amountOfNumbers > count) break;
                    }
                }

                //Вывод результата, выбор продолжить/завершить
                Console.WriteLine("RESULT: ( {0}) = {1} ({2} чисел)",sequence, number, amountOfNumbers);
                Console.WriteLine("Введите что-нибудь чтобы прекратить выполнение программы");
                end = Console.ReadLine();
            } while (end == "");
        }
    }
}



