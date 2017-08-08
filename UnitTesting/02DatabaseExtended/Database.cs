namespace _02DatabaseExtended
{
    using _02DatabaseExtended.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int MaxCapacity = 16;

        private HashSet<IPerson> data;
        private int size;

        public Database()
        {
            this.data = new HashSet<IPerson>();
        }

        public Database(params IPerson[] people)
            : this()
        {
            if (people.Length > MaxCapacity)
            {
                throw new InvalidOperationException("Maximum capacity is 16!");
            }

            if (people != null)
            {
                foreach (IPerson person in people)
                {
                    this.Add(person);
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

        public void Add(IPerson person)
        {
            if (this.Size == 16)
            {
                throw new InvalidOperationException("Cannot add more than 16 elements in this collection!");
            }
            if (this.data.Any(p => p.Username == person.Username)
             || this.data.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException();
            }
            this.data.Add(person);
            this.Size++;
        }

        public void Remove(IPerson person)
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty collection!");
            }

            this.data.RemoveWhere(p => p.Id == person.Id && p.Username == person.Username);
            this.Size--;
        }

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }
            if (!this.data.Any(p => p.Username == username))
            {
                throw new InvalidOperationException();
            }

            return this.data.First(p => p.Username == username);
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!this.data.Any(p => p.Id == id))
            {
                throw new InvalidOperationException();
            }

            return this.data.First(p => p.Id == id);
        }

        public IPerson[] Fetch()
        {
            return this.data.Take(this.Size).ToArray();
        }
    }
}
