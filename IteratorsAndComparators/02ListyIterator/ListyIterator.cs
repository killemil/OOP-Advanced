namespace _02ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private IList<T> data;
        private int currentIndex;

        public ListyIterator()
        {
            this.data = new List<T>();
        }

        public ListyIterator(params T[] data)
            : this()
        {
            this.data = data;
        }

        public bool Move()
        {
            if (this.currentIndex < this.data.Count - 1)
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return this.currentIndex < this.data.Count - 1;
        }

        public void Print()
        {
            Console.WriteLine(this.data[this.currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
