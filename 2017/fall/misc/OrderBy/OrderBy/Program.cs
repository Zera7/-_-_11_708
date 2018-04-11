using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupBy
{
    public static class MyGroupByExt
    {
        // T1 - перечислимый тип
        // T2 - хранимый тип (ключ)
        // T3 - возвращаемый тип
        // grouper - делегат возвращающий подходящие элементы
        public static Dictionary<T2,List<T3>> MyGroupBy<T1,T2,T3>(
            this IEnumerable<T1> obj, 
            Func<T1, T2> grouper,
            Func<T1, T3> returner)
        {
            var dict = new Dictionary<T2, List<T3>>();

            foreach (var item in obj)
            {
                var key = grouper(item);
                if (!dict.ContainsKey(key)) dict[key] = new List<T3>();
                dict[key].Add(returner(item));
            }

            return dict;
        }
    }

    //public struct Asd
    //{
    //    public int a;
    //    public double b;
    //}

    public struct LogYear
    {
        public DateTime FirstDay { get; set; }
        public int[] Load { get; set; }

        public DayOfWeek DayWeek()
        {
            return (DayOfWeek.)
        }
    }

    class Program
    {
        //public static double Grouper(Asd item)
        //{
        //    return item.b;
        //}

        //public static int Returner(Asd item)
        //{
        //    return item.a;
        //}

        static void Main(string[] args)
        {
            

            Console.Read();
        }
    }
}
