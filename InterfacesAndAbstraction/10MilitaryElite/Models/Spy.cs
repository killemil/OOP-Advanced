namespace _10MilitaryElite.Models
{
    using _10MilitaryElite.Intefaces;
    using System;
    using System.Text;

    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber
        {
            get
            {
                return this.codeNumber;
            }
            private set
            {
                this.codeNumber = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine + $"Code Number: {this.codeNumber}";
        }
    }
}
