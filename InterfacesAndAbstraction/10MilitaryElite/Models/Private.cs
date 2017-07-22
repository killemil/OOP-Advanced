namespace _10MilitaryElite.Models
{
    using _10MilitaryElite.Intefaces;
    using System;
    using System.Text;

    public class Private : Soldier, IPrivate
    {
        private double salary;

        public Private(int id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public double Salary
        {
            get
            {
                return this.salary;
            }
            private set
            {
                this.salary = value;
            }
        }

        public override string ToString()
        { 
            return $"{base.ToString()} Salary: {this.salary:F2}";
        }
    }
}
