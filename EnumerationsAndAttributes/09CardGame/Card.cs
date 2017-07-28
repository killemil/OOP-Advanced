namespace _09CardGame
{
    using System;

    public class Card : IComparable<Card>
    {
        private Suit suit;
        private Rank rank;
        private int power;
        private string owner;

        public Card(Suit suit, Rank rank, string owner)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.Owner = owner;
            this.SetPower();
        }

        public Suit Suit { get { return this.suit; } private set { this.suit = value; } }

        public Rank Rank { get { return this.rank; } private set { this.rank = value; } }

        public int Power { get { return this.power; } private set { this.power = value; } }

        public string Owner { get { return this.owner; } private set { this.owner = value; } }

        private void SetPower()
        {
            this.Power = (int)this.Rank + (int)this.Suit;
        }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override int GetHashCode()
        {
            return this.Power + (int)this.Rank + (int)this.Suit;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}
