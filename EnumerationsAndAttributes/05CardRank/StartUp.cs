namespace _05CardRank
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] cardRanks = Enum.GetNames(typeof(CardRank));

            Console.WriteLine($"{input}:");
            foreach (var card in cardRanks)
            {
                int oridnalValue = (int)Enum.Parse(typeof(CardRank), card);
                Console.WriteLine($"Ordinal value: {oridnalValue}; Name value: {card}");
            }
        }
    }
}
