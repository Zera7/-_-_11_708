using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
            //Fix me!
            IEnumerator<DataPoint> e = data.GetEnumerator();
            DataPoint current = new DataPoint();

            if (e.MoveNext())
            {
                current = e.Current;
                current.ExpSmoothedY = current.OriginalY;
                yield return current;
            }
            else
                yield break;
            DataPoint prev = e.Current;
            
            while (e.MoveNext())
            {
                current = e.Current;

                current.ExpSmoothedY = alpha * current.OriginalY + (1 - alpha) * prev.ExpSmoothedY;
                yield return current;
                prev = current;
            }
		}
	}
}