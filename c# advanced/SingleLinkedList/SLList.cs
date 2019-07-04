using System;
using System.Collections.Generic;
using System.Text;

namespace SingleLinkedList
{
    class SLList<T>
    {
        //add empty list protection
        //add private comparison function
        //add contains and remove item
        //add foreach cycler
        //advanced: sorting function
        class ListNode
        {
            public T item;
            public ListNode previousNode { get; set; }

            public ListNode(T item)
            {
                this.item = item;
                previousNode = null;
            }
        }

        ListNode head;
        public int Count { get => GetCount(0, head); }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                    return GetAt(Count - index - 1, head);
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Count)
                    SetAt(Count - index - 1, head, value);
                else throw new IndexOutOfRangeException();
            }
        }
        public SLList()
        {
            head = null;
        }

        public void Add(T item)
        {
            ListNode newnode = new ListNode(item);
            newnode.previousNode = head;
            head = newnode;
        }

        //public bool Contains(T item)
        //{
        //    return ContainsCycler(item, head);
        //}
        public void Insert(T item, int at)
        {
            if (at == Count) Add(item);
            else InsertCycler(item, head, Count - at - 1);
        }

        public void RemoveAt(int at)
        {
            if (at == Count - 1) head = head.previousNode;
            else RemoveAtCycler(head, Count - at -1);
        }
        


        #region private

        //private bool ContainsCycler(T item, ListNode currentnode)
        //{
        //    if (currentnode == null) return false;
        //    else if (currentnode.item == item) return true;
        //    else return ContainsCycler(item, currentnode.previousNode);
        //}

        private void InsertCycler(T item, ListNode currentnode, int at)
        {
            if (at == 0)
            {
                ListNode leftnode = currentnode.previousNode;
                ListNode rightnode = currentnode;
                ListNode newnode = new ListNode(item);
                newnode.previousNode = leftnode;
                rightnode.previousNode = newnode;
            }
            else InsertCycler(item, currentnode.previousNode, at - 1);
        }

        private void RemoveAtCycler(ListNode currentnode, int at)
        {
            if (at == 1)
            {
                ListNode toremove = currentnode.previousNode;
                currentnode.previousNode = currentnode.previousNode.previousNode;
            }
            else RemoveAtCycler(currentnode.previousNode, at - 1);
        }
        
        private int GetCount(int pos, ListNode currentnode)
        {
            if (currentnode==null)
                return pos;
            else return GetCount(pos + 1, currentnode.previousNode);
        }

        private T GetAt(int at, ListNode currentnode)
        {
            if (at == 0) return currentnode.item;
            else return GetAt(at - 1, currentnode.previousNode);
        }

        private void SetAt(int at, ListNode currentnode, T item)
        {
            if (at == 0) currentnode.item = item;
            else SetAt(at - 1, currentnode.previousNode, item);
        }
        #endregion
    }
}
