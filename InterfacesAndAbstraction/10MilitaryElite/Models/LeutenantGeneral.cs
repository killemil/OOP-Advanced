namespace _10MilitaryElite.Models
{
    using _10MilitaryElite.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private IList<ISoldier> privates;

        public LeutenantGeneral(int id, string firstName, string lastName, double salary, IList<ISoldier> soldiers)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = soldiers;
        }

        public IList<ISoldier> Privates
        {
            get
            {
                return this.privates;
            }
            private set
            {
                this.privates = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
            sb.AppendLine("Privates:");

            foreach (var soldier in this.privates)
            {
                sb.AppendLine("  " + soldier.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
