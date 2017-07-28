namespace _05ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            IList<Person> people = new List<Person>();

            string inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] tokens = inputLine.Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                people.Add(new Person(name, age, town));
            }

            int n = int.Parse(Console.ReadLine());
            try
            {
                Person persontToComapre = people[n];
                int equalCounter = 0;

                foreach (var person in people)
                {
                    if (persontToComapre.CompareTo(person) == 0)
                    {
                        equalCounter++;
                    }
                }

                if (equalCounter == 0)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine($"{equalCounter} {Math.Abs(people.Count - equalCounter)} {people.Count}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("No matches");
            }


        }
    }
}
