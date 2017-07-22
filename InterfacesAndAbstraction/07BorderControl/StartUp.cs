namespace _07BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string line;
            ICollection<Habitant> locals = new HashSet<Habitant>();

            while ((line = Console.ReadLine()) != "End")
            {
                string[] tokens = line
                    .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 3)
                {
                    Habitant person = new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]));
                    locals.Add(person);
                }
                else
                {
                    Habitant robot = new Robot(tokens[1], tokens[0]);
                    locals.Add(robot);
                }
            }

            line = Console.ReadLine();

            foreach (var item in locals.Where(l => l.Id.EndsWith(line)))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
