using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    В кинотеатре n  рядов по m  мест в каждом. 
    В двумерном массиве хранится информация о проданных билетах, число 1 означает, 
    что билет на данное место уже продано, число 0 означает, что место свободно. 
    Поступил запрос на продажу k  билетов на соседние места в одном ряду. 
    Определите, можно ли выполнить такой запрос.
*/

namespace Ex_last
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

                Console.WriteLine("\nВвод ширины и высоты матрицы");
                int xLength = Convert.ToInt32(Console.ReadLine());
                int yLength = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nВвод необходимого количества свободных мест");
                int k = Convert.ToInt32(Console.ReadLine());
                int result = 0;
                int resultCount = 0;

                byte[,] array = new byte[yLength, xLength];
                Console.WriteLine("\nВвод занятых и свободных мест");

                for (int i = 0; i < yLength; i++)
                {
                    string[] inputArray;
                    inputArray = (Console.ReadLine()).Split(' ');
                    int count = check(array, inputArray, k, xLength, i);
                    if (resultCount < count)
                    {
                        resultCount = count;
                        result = i + 1;
                    }
                }

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT:\nРяд № {0}\nКоличество мест: {1}", result, resultCount);
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static int check(byte[,] array, string[] inputArray, int k, int xLength, int currentY) {
            int count = 0;
            int maxCount = 0;
            for (int j = 0; j < xLength; j++)
            {
                array[currentY, j] = Convert.ToByte(inputArray[j]);
                count = array[currentY, j] == 0 ? count + 1 : 0;
                if (count >= k && count > maxCount) maxCount = count;
            }

            return maxCount;
        }
    }
}

