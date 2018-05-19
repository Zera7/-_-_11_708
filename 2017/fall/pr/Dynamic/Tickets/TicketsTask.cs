using System.Numerics;

namespace Tickets
{
    public static class TicketsTask
    {
        public static BigInteger Solve(int length, int sum)
        {
            if (sum % 2 != 0) return 0;
            var halfSum = sum / 2;
            var result = new BigInteger[length + 1, halfSum + 1];

            for (var i = 0; i < length + 1; i++)
                result[i, 0] = 1;

            for (var i = 1; i < length + 1; i++)
                for (var j = 1; j < halfSum + 1; j++)
                    for (var k = 0; k <= j && k < 10; k++)
                        result[i, j] += result[i - 1, j - k];
            return result[length, halfSum] * result[length, halfSum];
        }
    }
}
