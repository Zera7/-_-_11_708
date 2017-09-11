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
                int a1 = Convert.ToInt32(Console.ReadLine());
                int a2 = Convert.ToInt32(Console.ReadLine());

                //Ввод числа членов прогрессии
                int n = Convert.ToInt32(Console.ReadLine());

                //Разница между 1 и 2
                int dif = a2 - a1;

                //Расчет суммы до n
                int answer = 0;

                for (int i = 0; i < n; i++)
                {
                    answer += a1 + dif * i;
                }

                //Вывод результата, выбор продолжить/завершить
                Console.WriteLine("ANSWER: "+answer + "\n#Введите что-нибудь чтобы прекратить выполнение программы");
                end = Console.ReadLine();
            } while (end == "");

        }
    }
}
