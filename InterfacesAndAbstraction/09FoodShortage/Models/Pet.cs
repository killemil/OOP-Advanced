
namespace _09FoodShortage.Models
{
    using System;

    public class Pet : IBirthday, IName
    {
        private string name;
        private DateTime birthDay;

        public Pet(string name, DateTime birthDay)
        {
            this.Name = name;
            this.BirthDay = birthDay;
        }

        public DateTime BirthDay
        {
            get
            {
                return this.birthDay;
            }
            private set
            {
                this.birthDay = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set { this.name = value; }
        }
    }
}
