using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Александр Скворцов

    Практика «Два прямоугольника»
*/

namespace Ex_2
{
    class Program
    {
        public struct Rectangle {
            public int Left;
            public int Width;
            public int Right;

            public int Top;
            public int Height;
            public int Bottom;
        }

        public static Rectangle r1, r2;

        static void Main(string[] args)
        {
            r1.Left = 20;
            r1.Top = 2;
            r1.Width = 40;
            r1.Height = 4;
            r1.Right = r1.Left + r1.Width;
            r1.Bottom = r1.Top + r1.Height;

            r2.Left = 10;
            r2.Top = 1;
            r2.Width = 50;
            r2.Height = 5;
            r2.Right = r2.Left + r2.Width;
            r2.Bottom = r2.Top + r2.Height;

            Console.WriteLine(AreIntersected(r1,r2));
            Console.WriteLine(IntersectionSquare(r1,r2));
            Console.WriteLine(IndexOfInnerRectangle(r1,r2));
            Console.Read();
        }

        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            int a1a2Length = GetIntersection(r1.Left, r1.Right, r2.Left, r2.Right);
            int b1b2Length = GetIntersection(r1.Top, r1.Bottom, r2.Top, r2.Bottom);
            return (a1a2Length <= (r1.Width + r2.Width) && b1b2Length <= (r1.Height + r2.Height));
        }

        // Нахождение пересечения отрезков
        public static int GetIntersection(int a1, int a2, int b1, int b2) {
            return a1 <= b2 ? b2 - a1 : a2 - b1;
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            if (AreIntersected(r1, r2))
            {
                int intersection = 0;

                //intersectionX
                intersection = IntersectionLength(r1.Left, r1.Right, r2.Left, r2.Right);
                //intersectionY
                return intersection *= IntersectionLength(r1.Top, r1.Bottom, r2.Top, r2.Bottom);
            }
            else
                return 0;
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (IsInnerCoords(r1, r2)) return 0;
            if (IsInnerCoords(r2, r1)) return 1;
            return -1;
        }

        // Проверка на вложенность inner прямоугольника в external
        public static bool IsInnerCoords(Rectangle inner, Rectangle external)
        {
            return (inner.Top >= external.Top && inner.Left >= external.Left && inner.Right <= external.Right && inner.Bottom <= external.Bottom)? true : false;
        }

        // Возвращает длину пересечения
        public static int IntersectionLength(int coord1, int coord2, int coord3, int coord4)
        {
            int intersection = Math.Min(coord2, coord4) - Math.Max(coord1, coord3);
            return Math.Max(0, intersection);
        }

    }
}

