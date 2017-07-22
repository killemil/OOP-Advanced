namespace _11CollectionHierarchy
{
    using _11CollectionHierarchy.Interfaces;
    using _11CollectionHierarchy.Models;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();

            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IAddRemoveCollection<string> myList = new MyList<string>();

            string[] input = Console.ReadLine()
                .Split();
            int removeOperations = int.Parse(Console.ReadLine());

            foreach (var word in input)
            {
                sb.Append(addCollection.Add(word) + " ");
                Console.Write(addCollection.Add(word) + " ");
            }

            Console.WriteLine();
            foreach (var word in input)
            {
                Console.Write(addRemoveCollection.Add(word) + " ");
            }

            Console.WriteLine();
            foreach (var word in input)
            {
                Console.Write(myList.Add(word) + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(myList.Remove() + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}
