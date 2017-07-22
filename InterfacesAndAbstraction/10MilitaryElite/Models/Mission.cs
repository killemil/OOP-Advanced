namespace _10MilitaryElite.Models
{
    using _10MilitaryElite.Intefaces;
    using System;

    public class Mission : IMission
    {
        private string codeName;
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName
        {
            get
            {
                return this.codeName;
            }
            private set
            {
                this.codeName = value;
            }
        }

        public string State
        {
            get
            {
                return this.state;
            }
            private set
            {
                this.state = value;
            }
        }

        public override string ToString()
        {
            return $"Code Name: {this.codeName} State: {this.state}";
        }
    }
}
