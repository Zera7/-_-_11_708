using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_practice_control
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks709.Test();

            Console.Read();
        }

        static IEnumerable<char> Task32(IEnumerable<string> a)
        {
            return a
                .Select(q => q[0])
                .Reverse();
        }

        static IEnumerable<int> Task33(IEnumerable<int> a)
        {
            return a
                .Where(q => q > 0)
                .Take(1)
                .Select(q => q % 10)
                .Concat(
                    a.Skip(1)
                    .Where(q => q > 0)
                    .Select(q => q % 10)
                    .Distinct()
                );
        }

        static IEnumerable<char> Task40(IEnumerable<string> a, int k)
        {
            return a
                .Where(q => q.Length > k)
                .SelectMany(q => q)
                .Reverse();
        }

        static IEnumerable<string> Task46(IEnumerable<int> a, IEnumerable<int> b)
        {
            return a
                .Join(b.Reverse(), q => q % 10, w => w % 10, (q,w) => q + "-" + w );
        }
    }
}
