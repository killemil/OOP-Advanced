namespace _05CustomList.Core
{
    using System;
    using _05CustomList.Models;

    public class ListManager
    {
        private CustomList<string> myList;

        public ListManager()
        {
            this.myList = new CustomList<string>();
        }
        
        public void Add(string element)
        {
            myList.Add(element);
        }

        public void Remove(int index)
        {
            myList.Remove(index);
        }

        public void Contains(string element)
        {
            Console.WriteLine(myList.Contains(element));
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            myList.Swap(firstIndex, secondIndex);
        }

        public void Greater(string element)
        {
            Console.WriteLine(myList.CountGreaterThan(element));
        }

        public void Max()
        {
            Console.WriteLine(myList.Max());
        }

        public void Min()
        {
            Console.WriteLine(myList.Min());
        }

        public void Print()
        {
            foreach (var element in myList.Data)
            {
                Console.WriteLine(element);
            }
        }

        public void Sort()
        {
            myList = Sorter.Sort(myList);
        }
    }
}
