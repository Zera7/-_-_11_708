using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21._09
{
    class Program
    {
        static void Main(string[] args)
        {
            int result, digit;
            int number1, number2;

            number1 = Convert.ToInt32(Console.ReadLine());
            number2 = Convert.ToInt32(Console.ReadLine());

            result= 0;
            digit= 1;
            do
            {
                result += digit * (number2 % 10);   //Берем последний разряд числа
                digit *= 10;                        //Увеличиваем разряд на 1
                number2 /= 10;                      //Уменьшаем разряд исходного числа на 1
                result += digit * (number1 % 10);
                digit *= 10;
                number1 /= 10;
            } while (number1 != 0);

            Console.WriteLine(result);
            Console.Read();
        }
    }
}
