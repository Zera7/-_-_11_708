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
            var result = Task5(2);
                Console.WriteLine(result);
        }

        public static IEnumerable<string> Task1(IEnumerable<string> a, int k)
        {
            return a
                .Where((q, w) => (w < k && w % 2 == 1) || (w >= k && w % 2 == 0))
                .Where((X,i) => 
                .Reverse();
        }
        // where(
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

        public static double Task5(int k)
        {
            return Enumerable
                .Range(1, k)
                .Sum(a => 1 / (double)a);
        }
    }

    public static class Task2_1
    {
        public class Abi
        {
            public int SchoolNumber { get; set; }
            public int Year { get; set; }
            public int Lastname { get; set; }
        }

        public static void Test()
        {
            List<Abi> a = new List<Abi> {
                new Abi{ SchoolNumber= 3, Year = 1234 },
                new Abi{ SchoolNumber= 1, Year = 1233 },
                new Abi{ SchoolNumber= 3, Year = 1234 },
                new Abi{ SchoolNumber= 3, Year = 1234 },
                new Abi{ SchoolNumber= 2, Year = 1231 },
            };

            var groupA = a
                .GroupBy(q => q.Year)
                .OrderBy(q => q.Count())
                .Select(q => new { Year = q.Key, AmountSchools = q.Count() });

            foreach (var item in groupA)
            {
                Console.WriteLine(item);
            }

        }


    }
}
