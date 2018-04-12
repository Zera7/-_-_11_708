using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

        }



        public static IEnumerable<Tuple<int, int>> Task1_2(IEnumerable<int> a, IEnumerable<int> b)
        {
            var res = a.Join(b, q => GetItems(q), w => GetItems(w), (q, w) => Tuple.Create(q, w));
            return res;
        }

        public static int GetItems(int item)
        {
            int res = 0;
            int index = 1;
            while (true)
            {
                item /= 10000;
                if (item <= 0) break;
                res += item % 10 * index; 
                index *= 10;
            }
            return res;
        }
    }

    public static class Extensions
    {
        public static IEnumerable<Tuple<Item, Item>> Task2_2<Item, Key>(this IEnumerable<Item> a, Func<Item, Key> getKey)
        {
            Dictionary<Key, Item> result = new Dictionary<Key, Item>();
            return a
            .Join(a, q => getKey(q), w => getKey(w), (q, w) => Tuple.Create(q,w));
        }
    }

    public static class Task3_3
    {
        public class B
        {
        }

        public class D
        {

        }

        public class E
        {

        }

    }



}




/*
//////////////////
/
/
/
///
    /
    ///
    //
    /
//
*/