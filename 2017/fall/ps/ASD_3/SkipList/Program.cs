using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        var a = new SkipList<int>();
        a.Add(0);
        a.Remove(1);
        Console.ReadKey();
    }
}

public class SkipList<T> : IEnumerable<T> where T : IComparable
{
    public SkipList() { }
    public SkipList(IEnumerable<T> values)
    {
        foreach (var item in values)
            Add(item);
    }

    public int Count { get; private set; }
    public int MaxLvl { get; private set; }

    private Random random = new Random();
    private List<Node> FirstNodes { get; set; } = new List<Node>();
    private class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Down { get; set; }
        public T Value { get; set; }

        public Node(T value, Node left = null, Node right = null, Node down = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
            this.Down = down;
        }

        public override string ToString()
        {
            return $"Node value: {Value}";
        }
    }

    public void Add(T value)
    {
        Count++;
        if (FirstNodes.Count == 0)
        {
            FirstNodes.Add(new Node(value));
            return;
        }
        var current = FirstNodes[MaxLvl];
        var currentLvl = MaxLvl;
        var nodesToUpdate = new Stack<Node>();

        while (currentLvl >= 0)
        {
            var compare = current.Value.CompareTo(value);
            if (compare < 0)
            {
                if (current.Right == null)
                {
                    nodesToUpdate.Push(current);
                    if (currentLvl > 0)
                    {
                        currentLvl--;
                        current = current.Down;
                    }
                    else
                    {
                        UpdateNodesAdd(nodesToUpdate, value);
                        return;
                    }
                }
                else
                    current = current.Right;
            }
            else if (compare > 0)
            {
                nodesToUpdate.Push(current.Left);
                if (currentLvl > 0)
                {
                    currentLvl--;
                    if (current.Left == null)
                        current = FirstNodes[currentLvl];
                    else
                        current = current.Left.Down;
                }
                else
                {
                    UpdateNodesAdd(nodesToUpdate, value);
                    return;
                }
            }
            else
            {
                while (currentLvl >= 0)
                {
                    nodesToUpdate.Push(current.Left);
                    current = current.Down;
                    currentLvl--;
                }
                UpdateNodesAdd(nodesToUpdate, value);
            }
        }
    }

    public void Remove(T value)
    {
        if (Count <= 0) return;
        Count--;
        var current = FirstNodes[MaxLvl];
        var currentLvl = MaxLvl;
        var nodesToUpdate = new Stack<Node>();
        while (true)
        {
            var compare = current.Value.CompareTo(value);
            if (compare < 0)
            {
                if (current.Right == null)
                {
                    if (currentLvl > 0)
                    {
                        currentLvl--;
                        current = current.Down;
                    }
                    else
                        return;
                }
                else
                    current = current.Right;
            }
            else if (compare > 0)
            {
                if (currentLvl > 0)
                {
                    currentLvl--;
                    if (current.Left == null)
                        current = FirstNodes[currentLvl];
                    else
                        current = current.Left.Down;
                }
                else
                    return;
            }
            else
            {
                while (currentLvl >= 0)
                {
                    nodesToUpdate.Push(current);
                    current = current.Down;
                    currentLvl--;
                }
                UpdateNodesRemove(nodesToUpdate);
                return;
            }
        }
    }

    public bool Contains(T value)
    {
        var current = FirstNodes[MaxLvl];
        var currentLvl = MaxLvl;
        while (true)
        {
            var compare = current.Value.CompareTo(value);
            if (compare < 0)
            {
                if (current.Right == null)
                {
                    if (currentLvl > 0)
                    {
                        currentLvl--;
                        current = current.Down;
                    }
                    else
                        return false;
                }
                else
                    current = current.Right;
            }
            else if (compare > 0)
            {
                if (currentLvl > 0)
                {
                    currentLvl--;
                    if (current.Left == null)
                        current = FirstNodes[currentLvl];
                    else
                        current = current.Left.Down;
                }
                else
                    return false;
            }
            else
                return true;
        }
    }

    private void UpdateNodesRemove(Stack<Node> nodesToRemove)
    {
        var currentLvl = 0;
        while (nodesToRemove.Count > 0)
        {
            var currentNode = nodesToRemove.Pop();

            if (currentNode.Left != null)
                currentNode.Left.Right = currentNode.Right;
            else if (currentNode.Right != null)
                FirstNodes[currentLvl] = currentNode.Right;
            else
            {
                FirstNodes.RemoveAt(FirstNodes.Count - 1);
                if (MaxLvl > 0) MaxLvl--;
            }
            if (currentNode.Right != null)
                currentNode.Right.Left = currentNode.Left;
            currentLvl++;
        }
    }

    private void UpdateNodesAdd(Stack<Node> nodesToUpdate, T value)
    {
        Node currentLeftNode = null;
        Node currentRightNode = null;
        Node addedNode = null;
        var currentLvl = 0;
        var rnd = 1.0;
        while (rnd >= 0.5 && currentLvl <= MaxLvl + 1)
        {
            if (currentLvl < MaxLvl + 1)
            {
                currentLeftNode = nodesToUpdate.Pop();
                currentRightNode = currentLeftNode == null ? FirstNodes[currentLvl] : currentLeftNode.Right;

                addedNode = new Node(value, currentLeftNode, currentRightNode, addedNode);

                if (currentLeftNode != null)
                    currentLeftNode.Right = addedNode;
                else
                    FirstNodes[currentLvl] = addedNode;
                if (currentRightNode != null)
                    currentRightNode.Left = addedNode;
            }
            else
                FirstNodes.Add(new Node(value, null, null, addedNode));

            currentLvl++;
            rnd = random.NextDouble();
        }
        if (currentLvl - 1 > MaxLvl) MaxLvl++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (FirstNodes.Count == 0) yield break;
        Node current = FirstNodes[0];
        while (current != null)
        {
            yield return current.Value;
            current = current.Right;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}