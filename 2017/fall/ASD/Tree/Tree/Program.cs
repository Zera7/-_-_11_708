using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        public class SList<T>
        {
            public SList() { }

            public Node First { get; set; }
            public Node Last { get; set; }
            public int Count {get => GetCount();}

            private int GetCount()
            {
                int i = 0;
                Node a = First;
                while (a != null)
                {
                    i++;
                    a = a.next;
                }
                return i;
            }

            public T this[int index] { get => GetElem(index); }

            public class Node
            {
                public Node next;
                public T item;
                public Node(T item)
                {
                    this.item = item;
                }
            }

            private T GetElem(int index)
            {
                Node a = First;
                for (int i = 0; i < index; i++)
                {
                    if (a.next == null) throw new Exception("INDEXception");
                    a = a.next;
                }
                return a.item;
            }

            public void Add(T newItem)
            {
                Node newNode = new Node(newItem);
                if (First == null) First = newNode;
                if (Last != null) Last.next = newNode;
                Last = newNode;
            }

            public void AddRange(SList<T> range)
            {
                if (range != null)
                {
                    if (range.First != null)
                    {
                        this.Last.next = range.First;
                        this.Last = range.Last;
                    }
                }
                else
                    throw new NullReferenceException();
            }
        }

        static void Main(string[] args)
        {
            int amountElements = 0;
            Console.WriteLine("Enter amount of elements");
            while (!int.TryParse(Console.ReadLine(), out amountElements)) Console.WriteLine("?"); ;
            SList<int>[] listArray = new SList<int>[amountElements];
            for (int i = 0; i < listArray.Length; i++)
            {
                listArray[i] = new SList<int>();
                listArray[i].Add(i);
            }
            EnterNumbers(amountElements, listArray);
        }

        private static void EnterNumbers(int amountElements, SList<int>[] listArray)
        {
            string[] val;
            int[] pair = new int[2];

            Console.WriteLine("Enter values, 0 0 to stop");
            while (true)
            {
                val = Console.ReadLine().Split(' ');
                if (val.Length != 2) Console.WriteLine("Invalid pair of numbers");
                else
                {
                    for (int i = 0; i < pair.Length; i++)
                        pair[i] = int.Parse(val[i]);
                    if (Tree(pair, listArray))
                        Console.WriteLine("A pair of vertices was connected");
                    else
                        Console.WriteLine("A pair of vertices was already connected");
                }
            }
        }

        static public bool Tree(int[] p, SList<int>[] list)
        {
            if (list[p[0]] != list[p[1]])
            {
                list[p[0]].AddRange(list[p[1]]);
                SList<int> a = list[p[1]];
                for (int i = 0; i < list.Length; i++)
                    if (a == list[i]) list[i] = list[p[0]];

                Console.Clear();
                for (int j = 0; j < list.Length; j++)
                {
                    Console.Write("## " + j + " ##");
                    if (list[j] != null)
                    {
                        for (int i = 0; i < list[j].Count; i++)
                            Console.Write(list[j][i] + ", ");
                    }
                    Console.WriteLine();
                }
                return true;
            }
            return false;
        }

        private static void CheckList(int p, SList<int>[] list)
        {
            if (list[p] == null)
            {
                list[p] = new SList<int>();
                list[p].Add(p);
            }
        }
    }
}