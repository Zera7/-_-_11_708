using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_O_1__
{
    class Program
    {
        class Asd
        {
            public bool upd;
            public Asd next, prev1, prev2;
        }

        static void Main(string[] args)
        {
            int amountElements = 0;
            Console.WriteLine("Enter amount of elements");
            while (!int.TryParse(Console.ReadLine(), out amountElements)) Console.WriteLine("?"); ;
            Asd[] list = new Asd[amountElements];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new Asd();
            }
        }

        void Tree(Asd[] list, int[] p)
        {
            Asd a = GetRef(list[p[0]]);
            Asd b = GetRef(list[p[1]]);

            Asd newRef = new Asd();

            if (a != b)
            {
                if (a.prev1 == null && a.prev2 == null)
                {
                    a.next = newRef;
                    b.next = newRef;
                    newRef.prev1 = a;
                    newRef.prev2 = b;
                }
            }
        }

        private Asd GetRef(Asd asd)
        {
            while (true)
            {
                if (asd.next != null) asd = asd.next;
                else return asd;
            }
        }
    }
}
