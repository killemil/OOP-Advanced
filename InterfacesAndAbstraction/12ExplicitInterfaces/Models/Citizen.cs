namespace _12ExplicitInterfaces.Models
{
    using System;
    using _12ExplicitInterfaces.Interfaces;

    public class Citizen : IPerson, IResident
    {
        private string name;
        private int age;
        private string country;

        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set { this.name = value; }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            private set { this.country = value; }
        }

        string IPerson.GetName()
        {
            return $"{this.Name}";
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.name}";
        }

    }
}
