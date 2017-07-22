namespace _05CustomList.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T> 
        where T : IComparable<T>
    {
        private IList<T> data;

        public CustomList()
        {
            this.data = new List<T>();
        }

        public IList<T> Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public T Remove(int index)
        {
            T element = this.data[index];
            this.Data.RemoveAt(index);

            return element;
        }

        public bool Contains(T element)
        {
            return this.Data.Any(e => e.Equals(element));
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T element = this.Data[firstIndex];
            this.Data[firstIndex] = this.Data[secondIndex];
            this.Data[secondIndex] = element;
        }

        public int CountGreaterThan(T element)
        {
            int counter = 0;

            foreach (var e in this.Data)
            {
                if (e.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            T maxElement = this.Data[0];

            foreach (var element in this.Data)
            {
                if (element.CompareTo(maxElement) > 0)
                {
                    maxElement = element;
                }
            }

            return maxElement;
        }

        public T Min()
        {
            T minElement = this.Data[0];

            foreach (var element in this.Data)
            {
                if (element.CompareTo(minElement) < 0)
                {
                    minElement = element;
                }
            }

            return minElement;
        }
    }
}
