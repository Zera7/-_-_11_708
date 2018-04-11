using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_practice_control
{
    public static class LinqObj1
    {
        public static void Test()
        {
            List<Client> a = new List<Client> {
                new Client{ DurationInHours = 1 },
                new Client{ DurationInHours = 2 },
                new Client{ DurationInHours = 3 },
                new Client{ DurationInHours = 4 },
            };

            Console.Read();
        }

        public class Client
        {
            public int Code { get; set; }
            public int Year { get; set; }
            public int Mounth { get; set; }
            public int DurationInHours { get; set; }
        }
    }
}
