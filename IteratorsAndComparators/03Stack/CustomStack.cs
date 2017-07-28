namespace _03Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomStack<T> : IEnumerable<T>
    {
        private IList<T> data;

        public CustomStack()
        {
            this.Data = new List<T>();
        }

        public IList<T> Data { get { return this.data; } set { this.data = value; } }

        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                this.Data.Add(item);
            }
        }

        public void Pop()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("No elements");
                return;
            }

            IList<T> tempCollection = new List<T>();
            for (int i = 0; i < this.data.Count - 1; i++)
            {
                tempCollection.Add(this.data[i]);
            }

            this.data = tempCollection;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Data.Count - 1; i >= 0; i--)
            {
                yield return this.Data[i];
            }

            for (int i = this.Data.Count - 1; i >= 0; i--)
            {
                yield return this.Data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
