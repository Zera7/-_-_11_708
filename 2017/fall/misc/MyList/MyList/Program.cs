using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }

    class ZeraCollection<T> : IList
    {
        public enum OriginList
        {
            FromStart,
            FromEnd
        }

        private class Node
        {
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public T Data { get; set; }

            public Node(T data)
            {
                this.Data = data;
            }
        }
        private Node lastItem, firstItem;
        private Node[] bufferElements;
        private Node[] elements = new Node[16];
        private int amountElements = 0;
        public bool IsIndexed { get; set; } = false;
        public OriginList Origin { get; set; } = OriginList.FromStart;

        private void IndexCheck(int index)
        {
            if (index >= 0 && index > amountElements - 1) throw new IndexOutOfRangeException();
            if (firstItem == null) throw new Exception();
        }

        private Node GetItem(int index)
        {
            Node buf;
            if (!IsIndexed)
            {
                buf = firstItem;
                for (int i = 0; i < index; i++)
                    buf = buf.Next;
            }
            else
                buf = elements[index];
            return buf;
        }

        public object this[int index]
        {
            get
            {
                IndexCheck(index);
                return GetItem(index).Data;
            }
            set
            {
                IndexCheck(index);
                GetItem(index).Data = (T)value;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => false;

        public int Count
        {
            get
            {
                return amountElements;
            }
        }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public int Add(object value)
        {
            if (!(value is T)) throw new ArgumentException();
            if (IsIndexed)
            {
                if (elements.Length <= amountElements)
                    ExpandArray();
                elements[amountElements] = new Node((T)value);
                if (amountElements > 0)
                {
                    elements[amountElements - 1].Next = elements[amountElements];
                    elements[amountElements].Prev = elements[amountElements - 1];
                }
                else
                    firstItem = elements[amountElements];
                lastItem = elements[amountElements];
                return amountElements++;
            }
            else
            {
                if (amountElements > 0)
                {
                    if (Origin == OriginList.FromStart)
                    {
                        lastItem.Next = new Node((T)value)
                        {
                            Prev = lastItem
                        };
                        lastItem = lastItem.Next;
                    }
                    else
                    {
                        firstItem.Prev = new Node((T)value)
                        {
                            Next = firstItem
                        };
                        firstItem = firstItem.Prev;
                        amountElements++;
                        return 0;
                    }
                }
                else
                {
                    firstItem = new Node((T)value);
                    lastItem = firstItem;
                }
                return amountElements++;
            }
        }

        // ETO NE RABOTAET???
        public void Clear()
        {
            Node buf = amountElements > 0 ? firstItem : null;
            IsIndexed = false;
            for (int i = 0; i < elements.Length; i++)
                elements[i] = null;
            amountElements = 0;
            lastItem = null;
            firstItem = null;
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            if (!(value is T)) throw new ArgumentException();
            IndexCheck(index);
            Node buf = GetItem(index);
            Node newNode = new Node((T)value);
            IsIndexed = false;

            newNode.Next = buf;
            if (firstItem == buf)
                firstItem = newNode;
            else
            {
                newNode.Prev = buf.Prev;
                buf.Prev.Next = newNode;
            }

            buf.Prev = newNode;
            amountElements++;
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            IndexCheck(index);
            Node buf = GetItem(index);
            if (IsIndexed) elements[index] = null;
            IsIndexed = false;
            amountElements--;

            if (firstItem == lastItem)
            {
                firstItem = null;
                lastItem = null;
                return;
            }

            if (buf == firstItem)
                firstItem = buf.Next;
            else
                buf.Prev.Next = buf.Next;

            if (buf == lastItem)
                lastItem = buf.Prev;
            else
                buf.Next.Prev = buf.Prev;
        }

        private void ExpandArray()
        {
            bufferElements = elements;
            elements = new Node[elements.Length * 2];
            for (int i = 0; i < bufferElements.Length; i++)
                elements[i] = bufferElements[i];
            bufferElements = null;
        }

        public void IndexItems()
        {
            if (firstItem == null) return;
            elements = new Node[(int)(amountElements * 1.2)];
            Node buf = firstItem;
            elements[0] = buf;
            for (int i = 1; i < amountElements; i++)
            {
                buf = buf.Next;
                elements[i] = buf;
            }
        }
    }
}
