﻿namespace _07BorderControl
{
    using System;

    public class Citizen : Habitant, IPerson
    {
        private string name;
        private int age;

        public Citizen(string id, string name, int age)
            : base(id)
        {
            this.Name = name;
            this.Age = age;
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
    }
}
