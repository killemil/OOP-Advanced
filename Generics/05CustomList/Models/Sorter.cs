namespace _05CustomList.Models
{
    using System;
    using System.Linq;

    public class Sorter
    {
        public static CustomList<T> Sort<T>(CustomList<T> list)
            where T : IComparable<T>
        {
            CustomList<T> sorted = new CustomList<T>();

            foreach (var element in list.Data.OrderBy(s=> s))
            {
                sorted.Add(element);
            }

            return sorted;
        }
    }
}
