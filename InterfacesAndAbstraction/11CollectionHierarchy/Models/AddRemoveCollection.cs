namespace _11CollectionHierarchy.Models
{
    using System;
    using _11CollectionHierarchy.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private IList<T> list;

        public AddRemoveCollection()
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
            T result = this.list.LastOrDefault();
            this.list.RemoveAt(list.Count - 1);

            return result;
        }
    }
}
