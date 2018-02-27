using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YR1
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static IEnumerable<int[]> Combinations(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = ++value;
                    stack.Push(value);

                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }

        static void Main()
        {
            foreach (int[] c in Combinations(3, 6))
            {
                Console.WriteLine(string.Join(",", c));
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}