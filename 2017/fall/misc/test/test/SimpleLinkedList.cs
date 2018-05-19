//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace test
////{
////    public class SimpleLinkedList<T> : IEnumerable
////    {
////        public SimpleLinkedList(T value)
////        {
////            First = new Node(value);
////        }

////        public SimpleLinkedList(IEnumerable<T> list)
////        {
////            First.Value = list;
////            Last = new Node();

////            var a = list.GetEnumerator();

////        }

////        public Node First { get; set; }
////        public Node Last { get; set; }
////        public Node NextLast { get; set; }
////        public int Count { get; private set; }
////        public class Node
////        {
////            public Node(T value)
////            {
////                this.Value = value;
////            }
////            public Node()
////            {

////            }
////            public Node Next { get; set; }
////            public T Value { get; set; }
////        }

////        public void Add(T value)
////        {
////            Last.Next = new Node(value);
////            Last = Last.Next;
////            Count++;
////        }

////        public void Add(SimpleLinkedList<T> list)
////        {
////            if (list == null) throw new ArgumentNullException();
////            Last.Next = list.First;
////            NextLast = list.NextLast;
////            Count += list.Count;
////        }

////        public IEnumerator GetEnumerator()
////        {
////            var node = First;
////            while (node != null)
////            {
////                yield return node;
////                node = node.Next;
////            }
////        }
////    }

//}
