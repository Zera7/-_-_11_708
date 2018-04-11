using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2___2
{
    class Program
    {
        class Shop
        {
            public Shop(int code, int discount, string name) {
                this.Code = code;
                this.Discount = discount;
                this.Name = name;
            }

            public int Code { get; set; }
            public string Name { get; set; }
            public int Discount { get; set; }
        }

        class Buyer
        {
            public Buyer(int code, int year)
            {
                this.Code = code;
                this.Year = year;
            }

            public int Code { get; set; }
            public string Street { get; set; }
            public int Year { get; set; }
        }

        static void Main(string[] args)
        {
            var shop = new List<Shop>
            {
                new Shop(1,20,"asd"),
                new Shop(2,25,"asd2"),
                new Shop(3,23,"asd"),
            };
            var buyer = new List<Buyer>
            {
                new Buyer(1,1998),
                new Buyer(2,1998),
                new Buyer(3,1999),
                new Buyer(4,1999),
            };

            var q = shop.Join(buyer, a => a.Code, d => d.Code, (a, d) => new
            {
                a.Name,
                a.Discount,
                d.Year
            })
            .GroupBy(a => new { a.Year, a.Name })
            .Select(a => new
            {
                Avarage = (int)a.Average(b => b.Discount),
                Name = a.First().Name,
                Year = a.First().Year
            })
            .ToArray();

            var w = q.GroupBy(a => a.Name)
                .Select(a => a.ToList())
                .Except()
                .Where(a => buyer.Select(
                    b => b.Year)
                    .Where(b => !a.Contains(b)))



            foreach (var item in q)
                Console.WriteLine(item);

            Console.Read();
        }
    }
}
