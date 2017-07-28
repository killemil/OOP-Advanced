
namespace _06CardPower
{
    using System;

    public class Card : IComparable<Card>
    {
        private Suit suit;
        private Rank rank;
        private int power;

        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.SetPower();
        }

        public Suit Suit { get { return this.suit; } private set { this.suit = value; } }

        public Rank Rank { get { return this.rank; } private set { this.rank = value; } }

        public int Power { get { return this.power; } private set { this.power = value; }  }

        private void SetPower()
        {
            int rank = (int)Enum.Parse(typeof(Rank), this.Rank.ToString());
            int suit = (int)Enum.Parse(typeof(Suit), this.Suit.ToString());

            this.Power = rank + suit;
        }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
        }
    }
}
