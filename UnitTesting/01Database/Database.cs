namespace _01Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int MaxCapacity = 16;

        private int[] data;
        private int size;
        
        public Database()
        {
            this.data = new int[MaxCapacity];
        }

        public Database(params int[] numbers)
            : this()
        {
            if (numbers.Length > MaxCapacity)
            {
                throw new InvalidOperationException("Maximum capacity is 16!");
            }

            if (numbers != null)
            {
                foreach (int number in numbers)
                {
                    this.Add(number);
                }
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                this.size = value;
            }
        }

        public void Add(int number)
        {
            if (this.Size == 16)
            {
                throw new InvalidOperationException("Cannot add more than 16 elements in this collection!");
            }
            this.data[this.Size] = number;
            this.Size++;
        }

        public void Remove()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty collection!");
            }
            this.Size--;
        }

        public int[] Fetch()
        {
            return this.data.Take(this.Size).ToArray();
        }
    }
}
