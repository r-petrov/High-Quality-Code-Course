namespace SoftUni.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Stack<T>
    {
        private const int DefaultCapacity = 4; 

        private List<T> items;

        public Stack(int capacity)
        {
            this.Capacity = capacity;
        }

        public Stack() : this (DefaultCapacity)
        {
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.items.Capacity;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The stack must not be empty.");
                }

                this.items = new List<T>(value);
            }
        }

        public void Push(T item)
        {
            this.items.Add(item);
        }

        public T Pop()
        {
            T value = this.Peek();
            this.items.RemoveAt(this.Count - 1);

            return value;
        }
        
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("You can't remove items from an empty stack.");
            }

            T value = this.items[this.Count - 1];

            return value;
        }
    }
}
