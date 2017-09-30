using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

    Cond1. Дана начальная и конечная клетки на шахматной доске. 
    Корректный ли это ход на пустой доске для: слона, коня, ладьи, ферзя, короля?
*/

namespace Ex_1
{
    class Program
    {
        enum TypeOfFigure{
            King,
            Queen,
            Rook,
            Bishop,
            Knight
        }
        static void Main(string[] args)
        {
            //Начало цикла
            string end = "";
            do
            {
                Console.WriteLine("START");

                int x1 = Convert.ToInt32(Console.ReadLine());
                int y1 = Convert.ToInt32(Console.ReadLine());
                int x2 = Convert.ToInt32(Console.ReadLine());
                int y2 = Convert.ToInt32(Console.ReadLine());

                TypeOfFigure figure = (TypeOfFigure)Convert.ToInt32(Console.ReadLine());

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: {0} {1}\n\n", figure.ToString(), IsCanMove(x1,y1,x2,y2,figure));
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
        static bool IsCanMove(int x1, int y1, int x2, int y2, TypeOfFigure figure)
        {
            if (figure == TypeOfFigure.King) return Math.Abs(x2 - x1) <= 1 && Math.Abs(y2 - y1) <= 1;  //король всегда ходит на одну клетку
            if (figure == TypeOfFigure.Queen) return x2 - x1 == 0 || y2 - y1 == 0 || (Math.Abs(x2 - x1) == Math.Abs(y2 - y1));
            if (figure == TypeOfFigure.Rook) return x2 - x1 == 0 || y2 - y1 == 0;
            if (figure == TypeOfFigure.Bishop) return Math.Abs(x2 - x1) == Math.Abs(y2 - y1);
            if (figure == TypeOfFigure.Knight) return (Math.Abs(x2 - x1) == 2 && Math.Abs(y2 - y1) == 1) || (Math.Abs(x2 - x1) == 1 && Math.Abs(y2 - y1) == 2);

            return false;
        }
    }
}
