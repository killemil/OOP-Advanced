namespace BirthdayCelebrations
{
    using System;

    public class Citizen : Habitant, IPerson, IBirthday, IName
    {
        private string name;
        private int age;
        private DateTime birthDay;

        public Citizen(string id, string name, int age, DateTime birthDay)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
            this.BirthDay = birthDay;
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
    }
}
