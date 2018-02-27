using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace yield
{
    public static class MovingMaxTask
    {
        public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
        {
            int amountPoints = 0;
            LinkedList<DataPoint> items = new LinkedList<DataPoint>();
            Queue<DataPoint> deletedItems = new Queue<DataPoint>();
            int amountDeletedElements = 0;
            foreach (var item in data)
            {
                // Remove smaller elements
                while (items.Count > 0 && item.OriginalY >= items.Last.Value.OriginalY)
                {
                    deletedItems.Enqueue(items.Last.Value);
                    items.RemoveLast();
                    amountDeletedElements++;
                }
                // Add new item
                items.AddLast(item);
                amountPoints++;
                // Remove old items
                if (amountPoints > windowWidth)
                {
                    amountPoints--;
                    if (amountDeletedElements > 0 && deletedItems.Peek().X < items.First.Value.X)
                    {
                        deletedItems.Dequeue();
                        amountDeletedElements--;
                    }
                    else items.RemoveFirst();
                }
                item.MaxY = items.First.Value.OriginalY;
                yield return item;
            }
        }
    }
}