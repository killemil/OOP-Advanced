namespace _07EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> people = new HashSet<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person person = new Person(name, age);

                sortedPeople.Add(person);
                people.Add(person);
            }

            Console.WriteLine($"{sortedPeople.Count}");
            Console.WriteLine($"{people.Count}");
        }
    }
}
