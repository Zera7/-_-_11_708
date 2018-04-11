using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
	public static class ExtensionsTask
	{
		/// <summary>
		/// Медиана списка из нечетного количества элементов — это серединный элемент списка после сортировки.
		/// Медиана списка из четного количества элементов — среднее арифметическое двух серединных элементов списка после сортировки.
		/// </summary>
		/// <exception cref="InvalidOperationException">Если последовательность не содержит элементов</exception>
		public static double Median(this IEnumerable<double> items)
		{
            double[] newItems = items
                .OrderBy(a => a)
                .ToArray();
            if (newItems.Length == 0) throw new InvalidOperationException();
            var middleItem = newItems.Length / 2;
            
            if (newItems.Length % 2 == 0)
                return (newItems[middleItem - 1] + newItems[middleItem]) / 2;
            else
                return newItems[middleItem];
        }

		/// <returns>
		/// Возвращает последовательность, состоящую из пар соседних элементов.
		/// Например, по последовательности {1,2,3} метод должен вернуть две пары: (1,2) и (2,3).
		/// </returns>
		public static IEnumerable<Tuple<T, T>> Bigrams<T>(this IEnumerable<T> items)
		{
            var enumerator = items.GetEnumerator();
            T current, prev;
            enumerator.MoveNext();
            current = enumerator.Current;

            while (enumerator.MoveNext())
            {
                prev = current;
                current = enumerator.Current;
                yield return Tuple.Create(prev, current);
            }
        }
    }
}