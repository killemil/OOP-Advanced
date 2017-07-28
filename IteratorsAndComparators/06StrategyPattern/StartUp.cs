namespace _06StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> peopleSortByName = new SortedSet<Person>(new PersonNameComparator());
            SortedSet<Person> peopleSortByAge = new SortedSet<Person>(new PersonAgeComparer());
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person person = new Person(name, age);

                peopleSortByName.Add(person);
                peopleSortByAge.Add(person);
            }

            foreach (var person in peopleSortByName)
            {
                Console.WriteLine(person);
            }
            foreach (var person in peopleSortByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
