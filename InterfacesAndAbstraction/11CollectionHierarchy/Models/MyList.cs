namespace _11CollectionHierarchy.Models
{
    using _11CollectionHierarchy.Interfaces;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class MyList<T> : IAddRemoveCollection<T>
    {
        private IList<T> list;

        public MyList()
        {
            this.list = new List<T>();
        }

        public int Add(T item)
        {
            this.list.Add(item);

            return 0;
        }

        public T Remove()
        {
            T result = this.list.FirstOrDefault();
            this.list.RemoveAt(0);

            return result;
        }

        public int Count => this.list.Count;
    }
}
