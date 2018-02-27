using System;
using System.Collections.Generic;

namespace Monobilliards
{
    public class Monobilliards : IMonobilliards
    {
        public bool IsCheater(IList<int> inspectedBalls)
        {
            if (inspectedBalls.Count == 0) return false;
            int count = inspectedBalls.Count;
            Stack<int> buf = new Stack<int>();

            int max = 0;

            for (int i = 0; i < count; i++)
            {

                if (inspectedBalls[i] > max)
                {
                    for (int j = max + 1; j <= inspectedBalls[i] - 1; j++)
                        buf.Push(j);
                }
                else
                if (inspectedBalls[i] != buf.Pop()) return false;
                if (max < inspectedBalls[i]) max = inspectedBalls[i];

            }

            return false;
        }
    }
}