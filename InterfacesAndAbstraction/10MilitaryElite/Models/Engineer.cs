namespace _10MilitaryElite.Models
{
    using _10MilitaryElite.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private IList<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, double salary, string corps, IList<IRepair> parts)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = parts;
        }

        public IList<IRepair> Repairs
        {
            get
            {
                return this.repairs;
            }
            private set
            {
                this.repairs = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
            sb.AppendLine("Repairs:");

            foreach (var item in this.Repairs)
            {
                sb.AppendLine("  " + item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
