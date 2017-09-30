using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Cond6. * Заданы координаты трех точек на плоскости. 
    Являются ли они вершинами квадрата? Если да, то найти координаты четвертой вершины.
*/

namespace Ex_6
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

                //Вводим координаты точек
                int pointAX = Convert.ToInt32(Console.ReadLine());
                int pointAY = Convert.ToInt32(Console.ReadLine());
                int pointBX = Convert.ToInt32(Console.ReadLine());
                int pointBY = Convert.ToInt32(Console.ReadLine());
                int pointCX = Convert.ToInt32(Console.ReadLine());
                int pointCY = Convert.ToInt32(Console.ReadLine());

                //Находим длины отрезков между ними
                int distanceAB = GetSqrDistance(pointAX, pointAY, pointBX, pointBY);
                int distanceAC = GetSqrDistance(pointAX, pointAY, pointCX, pointCY);
                int distanceBC = GetSqrDistance(pointCX, pointCY, pointBX, pointBY);

                bool result = false;

                //Определение квадрата на существование
                //Нахождение координаты последней точки квадрата
                int x = 0, y = 0;
                if (distanceAB == distanceAC || distanceAB == distanceBC || distanceAC == distanceBC)
                    if (distanceAB == 2 * distanceAC || distanceAC == 2 * distanceAB || distanceBC == 2 * distanceAB)
                    {
                        if (distanceAB > distanceAC)
                        {
                            x = -(pointCX - pointAX) + pointBX;
                            y = -(pointCY - pointAY) + pointBY;
                        }
                        else if (distanceAC > distanceAB)
                        {
                            x = -(pointBX - pointAX) + pointCX;
                            y = -(pointBY - pointAY) + pointCY;
                        }
                        else
                        {
                            x = -(pointAX - pointCX) + pointBX;
                            y = -(pointAY - pointCY) + pointBY;
                        }
                        result = true;
                    }

                //Вывод результата и конец цикла
                if (result) Console.WriteLine("RESULT: ({0}, {1})" + "\n\n");
                else Console.WriteLine("Квадрат не квадрат" + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }

        static int GetSqrDistance(int aX, int aY, int bX, int bY) {
            return (int)(Math.Pow(bX - aX, 2) + Math.Pow(bY - aY, 2));
        }

    }
}
