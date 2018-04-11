using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_practice_control
{
    class Extensions
    {
        public IEnumerable<TItem> DistinctBy<TItem, TKey>(IEnumerable<TItem> a, Func<TItem, TKey> func)
        {
            Dictionary<TKey, TItem> result1 = new Dictionary<TKey, TItem>(); 
            foreach (var item in a)
            {
                var key = func(item);
                if (!result1.ContainsKey(key)) result1[key] = item;
            }

            // Без линков
            List<TItem> result2 = new List<TItem>();
            foreach (var item in result1)
                result2.Add(item.Value);
            return result2;

            // То же самое с линками
            // return result1.Select(q => q.Value).ToList();
        }
    }
}
