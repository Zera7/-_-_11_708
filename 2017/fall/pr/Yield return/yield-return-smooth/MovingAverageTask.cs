using System.Collections.Generic;

namespace yield
{
    public static class MovingAverageTask
    {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            int amountPoints = 0;
            double sum = 0;
            var buffer = new Queue<double>();

            foreach (var item in data)
            {
                amountPoints++;
                sum += item.OriginalY;
                buffer.Enqueue(item.OriginalY);
                if (amountPoints > windowWidth)
                {
                    sum -= buffer.Dequeue();
                    amountPoints--;
                }
                item.AvgSmoothedY = sum / amountPoints;
                yield return item;
            }
        }
    }
}