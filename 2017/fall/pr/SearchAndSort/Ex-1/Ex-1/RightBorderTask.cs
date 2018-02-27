using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (prefix == "" || phrases.Count == 0) return right;
            left++;
            right--;
            while (right - left > 0)
            {
                int m = (left + right) / 2;

                if (string.Compare(prefix, phrases[m], StringComparison.OrdinalIgnoreCase) >= 0
                || phrases[m].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    left = m + 1;
                else right = m - 1;
            }
            if (string.Compare(prefix, phrases[right], StringComparison.OrdinalIgnoreCase) >= 0
            || phrases[left].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return right + 1;
            else
                return right;
        }
    }
}