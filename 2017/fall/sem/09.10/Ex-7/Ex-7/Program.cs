using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Arr7. 1490. Огненный круг
Лич Сандро проводит свои научные исследования в магии огня. 
Сандро стоит в центре огромного квадратного зала площадью миллион квадратных километров, 
сплошь замощённого квадратными каменными плитами со стороной один метр. По взмаху посоха вокруг Сандро возникает огненный круг 
радиуса R метров. Центр круга совпадает с центром зала и находится в месте соприкосновения четырёх плит. Сандро хочет посчитать, 
сколько плит будет испорчено огнем. 
Считается, что плита испорчена, если она имеет хотя бы две общие точки с кругом. 
*/

namespace Ex_7
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

                int r = Convert.ToInt32(Console.ReadLine());

                int result = 0;

                for (int i = 0; i < r; i++) {
                    for (int j = 0; j < r; j++) {
                        if ((ulong)(i * i) + (ulong)(j * j) < (ulong)(r * r))
                            result++;
                    }
                }

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result * 4 + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
