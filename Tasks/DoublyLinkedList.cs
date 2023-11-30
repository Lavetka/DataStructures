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
            if (index < 0 || index > Length)
                throw new IndexOutOfRangeException(nameof(index));
            Node newNode = new Node(e);

            if (index == 0)
            {
                newNode.Next = head;
                if (head != null)
                    head.Prev = newNode;
                head = newNode;

                if (Length == 0)
                    tail = newNode;
            }
            else if (index == Length)
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else
            {
                Node current = GetNodeAtIndex(index);
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }
            Length++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException(nameof(index));

            return GetNodeAtIndex(index).Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Remove(T item)
        {
            Node current = head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    RemoveNode(current);
                    return;
                }
                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException(nameof(index));

            Node nodeToRemove = GetNodeAtIndex(index);
            RemoveNode(nodeToRemove);

            return nodeToRemove.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node GetNodeAtIndex(int index)
        {
            Node current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        private void RemoveNode(Node node)
        {
            if (node.Prev == null)
                head = node.Next;
            else
                node.Prev.Next = node.Next;

            if (node.Next == null)
                tail = node.Prev;
            else
                node.Next.Prev = node.Prev;

            Length--;
        }
    }
}
