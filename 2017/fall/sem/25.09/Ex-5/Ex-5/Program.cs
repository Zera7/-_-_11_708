using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*
        Александр Скворцов

        Cond5. (1740. А олени лучше) Нужно проехать L километров так, 
        чтобы любой отрезок пути длиной K километров (K ≤ L) проезжать ровно за H часов. 
        Мгновенная скорость не ограничена. 
        За сколько минимум и максимум времени можно проехать этот путь?
    */

namespace Ex_5
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

                int l = Convert.ToInt32(Console.ReadLine());
                int k = Convert.ToInt32(Console.ReadLine());
                int h = Convert.ToInt32(Console.ReadLine());

                int result = 0;

                //Вывод результата и конец цикла
                Console.WriteLine("RESULT: " + result + "\n\n");
                Console.WriteLine("#Любой символ для завершения");
                end = Console.ReadLine();
            } while (end == "" || end.Length > 1);

        }
    }
}
