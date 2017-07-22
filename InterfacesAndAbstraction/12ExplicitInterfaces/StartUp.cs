namespace _12ExplicitInterfaces
{
    using _12ExplicitInterfaces.Interfaces;
    using _12ExplicitInterfaces.Models;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            IList<IPerson> citizens = new List<IPerson>();
            IList<IResident> residents = new List<IResident>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                string[] tokens = inputLine.Split();
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                citizens.Add(new Citizen(name, age, country));
                residents.Add(new Citizen(name, age, country));
            }

            for (int i = 0; i < citizens.Count; i++)
            {
                Console.WriteLine(citizens[i].GetName());
                Console.WriteLine(residents[i].GetName());
            }
        }
    }
}
