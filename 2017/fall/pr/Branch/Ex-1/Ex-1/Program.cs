using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PluralizeRubles(0));
            Console.Read();
        }
        public static string PluralizeRubles(int count)
        {
            string result = "";
            if (count % 100 > 10 && count % 100 < 21) result = "рублей";
            else
                switch (count % 10)
                {
                    case 1:
                        result = "рубль";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        result = "рубля";
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        result = "рублей";
                        break;
                    default:
                        result = "";
                        break;
                }
            return result;
        }
    }
}
