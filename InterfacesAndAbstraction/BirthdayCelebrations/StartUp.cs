namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string line;
            IList<IBirthday> locals = new List<IBirthday>();

            while ((line = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = line
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0].Equals("Citizen"))
                    {
                        DateTime date = DateTime.ParseExact(tokens[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        IBirthday person = new Citizen(tokens[3], tokens[1], int.Parse(tokens[2]), date);
                        locals.Add(person);
                    }
                    else if (tokens[0].Equals("Pet"))
                    {
                        DateTime date = DateTime.ParseExact(tokens[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        IBirthday pet = new Pet(tokens[1], date);
                        locals.Add(pet);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            line = Console.ReadLine();

            foreach (var item in locals.Where(x => x.BirthDay.Year == int.Parse(line)))
            {
                Console.WriteLine($"{item.BirthDay.ToString("dd/MM/yyyy")}");
            }
        }
    }
}
