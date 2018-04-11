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
                amountDeletedElements = RemoveSmallerElements(items, deletedItems, amountDeletedElements, item);
                // Add new item
                items.AddLast(item);
                if (amountPoints < windowWidth)
                    amountPoints++;
                else
                    RemoveOldItems(items, deletedItems, ref amountDeletedElements);
                item.MaxY = items.First.Value.OriginalY;
                yield return item;
            }
        }

        private static int RemoveSmallerElements(LinkedList<DataPoint> items, Queue<DataPoint> deletedItems, int amountDeletedElements, DataPoint item)
        {
            while (items.Count > 0 && item.OriginalY >= items.Last.Value.OriginalY)
            {
                deletedItems.Enqueue(items.Last.Value);
                items.RemoveLast();
                amountDeletedElements++;
            }

            return amountDeletedElements;
        }

        private static void RemoveOldItems(LinkedList<DataPoint> items, Queue<DataPoint> deletedItems, ref int amountDeletedElements)
        {
            if (amountDeletedElements > 0 && deletedItems.Peek().X < items.First.Value.X)
            {
                deletedItems.Dequeue();
                amountDeletedElements--;
            }
            else items.RemoveFirst();
        }
    }
}