using System;
using System.Collections.Generic;

namespace Clones
{
    public class CloneVersionSystem : ICloneVersionSystem
    {
        public class MyStack<T>
        {
            private class Node
            {
                public T Data { get; set; }
                public Node Prev { get; set; }
            }

            public MyStack() { }
            public MyStack(MyStack<T> a)
            {
                last = a.last;
                first = a.first;
                Count = a.Count;
            }

            public int Count { get; private set; } = 0;
            Node last;
            Node first;

            public void Push(T data)
            {
                Node a = new Node
                {
                    Data = data,
                    Prev = last
                };
                if (last == null) first = a;
                last = a;
                Count++;
            }

            public T Pop()
            {
                if (last == null) throw new Exception("Попытка доступа к несуществующему элементу стека");
                Node a = last;
                last = last.Prev;
                Count--;
                return a.Data;
            }

            public void Clear()
            {
                Count = 0;
                first = null;
                last = null;
            }

            public T Peek()
            {
                return last.Data;
            }
        }

        private List<Clone> allClones = new List<Clone>
        {
            new Clone()
        };

        public class Clone
        {
            MyStack<int> programs = new MyStack<int>();
            MyStack<int> rollBackPrograms = new MyStack<int>();

            public Clone() { }
            public Clone(MyStack<int> programs, MyStack<int> rollBackPrograms)
            {
                this.programs = programs;
                this.rollBackPrograms = rollBackPrograms;
            }

            public void Learn(int p)
            {
                rollBackPrograms.Clear();
                programs.Push(p);
            }

            public void Rollback()
            {
                if (programs.Count > 0)
                    rollBackPrograms.Push(programs.Pop());
            }

            public void Relearn()
            {
                if (rollBackPrograms.Count > 0)
                    programs.Push(rollBackPrograms.Pop());
            }

            public void CloneItem(List<Clone> allClones)
            {
                Clone newClone = new Clone(new MyStack<int>(programs), new MyStack<int>(rollBackPrograms));
                allClones.Add(newClone);
            }

            public string Check()
            {
                if (programs.Count == 0) return "basic";
                return programs.Peek().ToString();
            }
        }
        public string Execute(string query)
        {
            string[] inquiry = query.Split(' ');
            int number = int.Parse(inquiry[1]) - 1;

            switch (inquiry[0])
            {
                case "check":
                    return allClones[number].Check();
                case "learn":
                    int p = int.Parse(inquiry[2]);
                    allClones[number].Learn(p);
                    break;
                case "rollback":
                    allClones[number].Rollback();
                    break;
                case "clone":
                    allClones[number].CloneItem(allClones);
                    break;
                case "relearn":
                    allClones[number].Relearn();
                    break;
            }
            return null;
        }
    }
}
