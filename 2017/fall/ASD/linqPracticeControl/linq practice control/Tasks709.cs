using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_practice_control
{
    public static class Tasks709
    {
        public static void Test()
        {
            int[] asd = {1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = Task1(asd, 5);
            foreach (var item in result)
                Console.WriteLine(item);
        }

        public static IEnumerable<int> Task1(IEnumerable<int> a, int k)
        {
            return a
                .Where((q, w) => (w < k && w % 2 == 1) || (w >= k && w % 2 == 0))
                .Reverse();
        }

        public static IEnumerable<int> Task2(IEnumerable<int> a, IEnumerable<int> b)
        {
            return a
                .SelectMany(q => b.Select(w => q + w)).OrderBy(q => q);
        }

        public static IEnumerable<int> Task3(IEnumerable<int> a)
        {
            return a
                .Where(q => q % 2 == 1)
                .Distinct();
        }
    }
}
