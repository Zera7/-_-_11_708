using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Arr3. Превратить рациональную дробь в десятичную. Возможен период. "1/3" должна превратиться в "0.(3)"

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

                double numerator = Convert.ToInt32(Console.ReadLine());
                double denominator = Convert.ToInt32(Console.ReadLine());
                string result = (numerator / denominator).ToString();

                const int MinNumberOfRepitions = 5;
                int numberOfRepitions = 1;
                bool isRepeating = false;

                if (denominator != 0 && numerator % denominator != 0) {
                    string k = result[result.Length - 1].ToString();

                    for (int i = 0; i < result.Length - 2; i++)
                    {
                        if (result[result.Length - 1 - i] == result[result.Length - 2 - i])
                        {
                            numberOfRepitions++;
                            if (numberOfRepitions >= MinNumberOfRepitions)
                                isRepeating = true;
                        }
                        else
                        {
                            if (!isRepeating)
                                numberOfRepitions = 0;
                            else
                                break;
                        }
                    }
                    result = result.Substring(0, result.Length - numberOfRepitions);
                    if (isRepeating)
                        result += '(' + k + ')';
                }

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
