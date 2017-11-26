using System;

namespace Sol
{
    public class Ex2
    {
        public static double GetPI(double k)
        {
            double result = 2 * Math.Log(2);
            double oldResult = 2 * Math.Log(2);
            bool end = false;
            for (int i = 1; !end; i++)
            {
                result += 8.0 / ((4.0 * i - 2) * (4.0 * i - 1));
                end = (Math.Abs(result - oldResult) < k);
                oldResult = result;
            }
            return result;
        }
    }
}
