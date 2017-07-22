namespace _11CollectionHierarchy.Models
{
    using System;
    using _11CollectionHierarchy.Interfaces;
    using System.Collections.Generic;

    public class AddCollection<T> : IAddCollection<T>
    {
        private IList<T> list;

        public AddCollection()
        {
            this.list = new List<T>();
        }

        public int Add(T item)
        {
            list.Add(item);

            return list.Count - 1;
        }
    }
}
