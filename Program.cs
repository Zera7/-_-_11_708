using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1___3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>
            {
                "SANANA",
                "BANANA",
                "APELSIN",
                "MANDARIN",
                "ZUBRA"
            };

            var newList = list
                .Select(a => a[0])
                .Reverse()
                .ToList();

            foreach (var item in newList)
                Console.WriteLine(item);

            Console.Read();
        }
    }
}
