using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node Prev;

            public Node(T data)
            {
                Data = data;
            }
        }

        private Node head;
        private Node tail;

        public int Length { get; private set; }

        public void Add(T e)
        {
            Node node = new Node(e);


            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            Length++;
        }

        public void AddAt(int index, T e)
        {
           
        }

        public T ElementAt(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public T RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
