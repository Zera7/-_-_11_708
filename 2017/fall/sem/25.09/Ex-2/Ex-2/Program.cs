using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Александр Скворцов

   Cond2. Пролезет ли брус со сторонами x, y, z в отверстие со сторонами a, b, 
   если его разрешается поворачивать на 90 градусов?
*/

namespace Ex_2
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

                bool result = false;

                Console.WriteLine("Стороны бруса: x, y, z");
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());
                int z = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Стороны отверстия a, b");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());

                if (!result) result = ((x <= a && y <= b) || (x <= b && y <= a));
                if (!result) result = ((x <= a && z <= b) || (x <= b && z <= a));
                if (!result) result = ((y <= a && z <= b) || (y <= b && z <= a));

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);
        }
    }
}
