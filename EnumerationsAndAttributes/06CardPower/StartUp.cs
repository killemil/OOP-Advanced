namespace _06CardPower
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            IList<Card> cards = new List<Card>();
            for (int i = 0; i < 2; i++)
            {
                string cardRank = Console.ReadLine();
                string cardSuit = Console.ReadLine();
                Rank rank = (Rank)Enum.Parse(typeof(Rank), cardRank);
                Suit suit = (Suit)Enum.Parse(typeof(Suit), cardSuit);
                cards.Add(new Card(suit, rank));
            }
            

            Console.WriteLine(string.Join("",cards.OrderByDescending(c=> c.Power).Take(1)));
        }
    }
}
