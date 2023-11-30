using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> queueAndStack;

        public HybridFlowProcessor()
        {
            queueAndStack = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (queueAndStack.Length == 0)
                throw new InvalidOperationException("Queue is empty.");

            return queueAndStack.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            queueAndStack.Add(item);
        }

        public T Pop()
        {
            if (queueAndStack.Length == 0)
                throw new InvalidOperationException("Queue is empty.");

            return queueAndStack.RemoveAt(queueAndStack.Length-1);
        }

        public void Push(T item)
        {
            queueAndStack.AddAt(queueAndStack.Length,item) ;
        }
    }
}
