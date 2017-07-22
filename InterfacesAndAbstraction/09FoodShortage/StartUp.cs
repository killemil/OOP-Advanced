namespace _09FoodShortage
{
    using _09FoodShortage.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            ICollection<IBuyer> buyers = new HashSet<IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] lineInfo = Console.ReadLine()
                    .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

                if (lineInfo.Length == 4)
                {
                    DateTime date = DateTime.ParseExact(lineInfo[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    IBuyer buyer = new Citizen(lineInfo[2], lineInfo[0], int.Parse(lineInfo[1]),date);
                    buyers.Add(buyer);
                }
                else if (lineInfo.Length == 3)
                {
                    IBuyer buyer = new Rebel(lineInfo[0], int.Parse(lineInfo[1]), lineInfo[2]);
                    buyers.Add(buyer);
                }
            }

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                if (buyers.Any(b => b.Name == line))
                {
                    buyers.FirstOrDefault(b => b.Name == line).BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b=> b.Food));
        }
    }
}
