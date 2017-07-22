namespace _09FoodShortage.Models
{
    using System;

    public class Citizen : Habitant, IPerson, IBirthday, IName, IBuyer
    {
        private string name;
        private int age;
        private DateTime birthDay;
        private int food;

        public Citizen(string id, string name, int age, DateTime birthDay)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
            this.BirthDay = birthDay;
            this.food = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
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

        public int Food
        {
            get
            {
                return this.food;
            }
            private set
            {
                this.food = value;
            }
        }


        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
