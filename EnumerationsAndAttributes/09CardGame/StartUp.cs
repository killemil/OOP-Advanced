namespace _09CardGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string firstPlayerName = Console.ReadLine();
            string secondPlayerName = Console.ReadLine();

            HashSet<Card> allCards = new HashSet<Card>();

            while (allCards.Count < 10)
            {
                string[] cardTokens = Console.ReadLine().Split();
                string cardRank = cardTokens[0];
                string cardSuite = cardTokens[2];
                Rank rank;
                Suit suit;

                if (Enum.TryParse(cardRank, out rank) && Enum.TryParse(cardSuite, out suit))
                {
                    Card card = new Card(suit, rank, firstPlayerName);
                    if (allCards.Count >= 5)
                    {
                        card = new Card(suit, rank, secondPlayerName);
                    }
                    if (allCards.Contains(card))
                    {
                        Console.WriteLine("Card is not in the deck.");
                        continue;
                    }
                    allCards.Add(card);
                }
                else
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            Card mostPowerfulCard = allCards.Max();
            Console.WriteLine($"{mostPowerfulCard.Owner} wins with {mostPowerfulCard.Rank} of {mostPowerfulCard.Suit}.");
        }
    }
}
