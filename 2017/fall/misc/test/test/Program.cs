using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Profiling
{
    class Program
    {
        public static void Main()
        {
            Stack<int> a = new Stack<int>();
            a.Push(1);
            a.Push(2);
            a.Push(3);
            Stack<int> b = new Stack<int>(a);
            Console.WriteLine(b.Peek());
            Console.WriteLine(a.Peek());
            Console.Read();

        }
    }
}