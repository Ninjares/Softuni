using System;

namespace WorkShop_linkedlist
{
    class Program
    {
        public class DoubleLinkedList
        {
            private class ListNode
            {
                public int Value { get; set; }
                public ListNode NextNode { get; set; }
                public ListNode PreviousNode { get; set; }
                public ListNode(int value)
                {
                    this.Value = value;
                }
            }

            private ListNode head;
            private ListNode tail;
            public int Count { get; private set; } = 0;

            public void AddFirst(int element)
            {
                if(this.Count == 0)
                {
                    this.head = this.tail = new ListNode(element);
                }
                else
                {
                    ListNode newHead = new ListNode(element);
                    newHead.NextNode = this.head;
                    this.head.PreviousNode = newHead;
                    this.head = newHead;
                }
            }

            public void AddLast(int element)
            {
                if (this.Count == 0)
                {
                    this.head = this.tail = new ListNode(element);
                }
                else
                {
                    ListNode newTail = new ListNode(element);
                    newTail.PreviousNode = this.tail;
                    this.tail.NextNode = newTail;
                    this.tail = newTail;
                }
            }

            public int RemoveFirst()
            {
                if(this.Count == 0)
                {
                    throw new InvalidOperationException("The list is empty");
                }
                int firstElement = this.head.Value;
                this.head = this.head.NextNode;
                if(this.head != null) //there is an element
                {
                    this.head.PreviousNode = null;
                }
                else //the list is empty
                {
                    this.tail = null;
                }
                this.Count--;
                return firstElement;
            }

            public int RemoveLast()
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("The list is empty");
                }
                int LastElement = this.tail.Value;
                this.tail = this.tail.PreviousNode;
                if(this.tail==null)
                {
                    this.tail.NextNode = null;
                }
                else //the list is empty
                {
                    this.head = null;
                }
                this.Count--;
                return LastElement;
            }

            public void ForEach(Action<int> action)
            {
                var currentNode = this.head;
                while (currentNode != null)
                {
                    action(currentNode.Value);
                    currentNode = currentNode.NextNode;
                }
            }
            
            public int[] ToArray()
            {
                int[] array = new int[Count];
                int i = 0;
                var currentNode = this.head;
                while (currentNode != null)
                {
                    array[i] = currentNode.Value;
                    currentNode = currentNode.NextNode;
                    i++;
                }
                return array;
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
