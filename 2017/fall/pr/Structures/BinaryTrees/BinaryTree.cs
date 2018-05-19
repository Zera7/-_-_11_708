using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTrees
{
    public class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public T Key { get; }
        public int ChildrenCount { get; set; }

        public TreeNode(T key)
        {
            Key = key;
            ChildrenCount = 1;
        }
    }

    public class BinaryTree<T>:IEnumerable<T> where T:IComparable
    {
        public TreeNode<T> Root { get; private set; }

        public void Add(T key)
        {
            if (Root == null)
            { 
                Root = new TreeNode<T>(key);
                return;
            }
            TreeNode<T> current = Root;
            while (true) 
            {
                current.ChildrenCount++;
                if (key.CompareTo(current.Key) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left =  new TreeNode<T>(key);
                        return;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null) 
                    {
                        current.Right =  new TreeNode<T>(key);
                        return;
                    }
                    current = current.Right;
                }
            }       
        }

        public bool Contains(T key) 
        {
            var current = Root;
            while (current != null) 
            {
                if (key.Equals(current.Key)) return true;
                if (key.CompareTo(current.Key) < 0)
                    current = current.Left;
                else current = current.Right;
            }
            return false;
        }
        
        public T this[int index]
        {
            get
            {
                var current = Root;
                while (true)
                {
                    var leftSubtreeCount = current.Left != null ? current.Left.ChildrenCount : 0;
                    if (leftSubtreeCount == index) return current.Key;
                    if (index > leftSubtreeCount)
                    {
                        index = index - leftSubtreeCount - 1;
                        current = current.Right;
                    }
                    else current = current.Left;
                }
            }
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            if (Root != null)
            {
                var current = Root;
                var parents = new Stack<TreeNode<T>>();
                bool toLeft = true;
                parents.Push(current);

                while (parents.Count > 0)
                {
                    if (toLeft)
                        while (current.Left != null)
                        {
                            parents.Push(current);
                            current = current.Left;
                        }
                    
                    yield return current.Key;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        toLeft = true;
                    }
                    else
                    {
                        current = parents.Pop();
                        toLeft = false;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}