
namespace _08DeckOfCards
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] cardSuits = Enum.GetNames(typeof(Suit));
            string[] cardRanks = Enum.GetNames(typeof(Rank));

            foreach (var suit in cardSuits)
            {
                foreach (var rank in cardRanks)
                {
                    Console.WriteLine($"{rank} of {suit}");
                }
            }
        }
    }
}
