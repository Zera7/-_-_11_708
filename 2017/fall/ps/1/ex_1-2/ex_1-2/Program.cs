using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    /*
    Александр Скворцов

        Вариант 15
        2. По двум первым членам арифметической прогрессии и натуральному числу n
        посчитать значение суммы n членов арифметической прогрессии
    */

namespace ex_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Цикл выполняется пока не вводится какое-либо значение в end
            string end;
            do
            {
                Console.WriteLine("START \n#Введите 2 первых числа, а так же количество чисел в прогрессии");
                //Ввод первых двух чисел арифметической прогрессии
                int number1 = Convert.ToInt32(Console.ReadLine());
                int number2 = Convert.ToInt32(Console.ReadLine());

                //Ввод числа членов прогрессии
                int AmountOfNumbers = Convert.ToInt32(Console.ReadLine());

                //Разница между 1 и 2
                int step = number2 - number1;

                //Расчет суммы до n
                int result = 0;

		// ---check--- а почему не по формуле суммы?
                for (int i = 0; i < AmountOfNumbers; i++)
                {
                    result += number1 + step * i;
                }

                //Вывод результата, выбор продолжить/завершить
                Console.WriteLine("RESULT: "+result + "\n#Введите что-нибудь чтобы прекратить выполнение программы");
                end = Console.ReadLine();
            } while (end == "");

        }
    }
}
