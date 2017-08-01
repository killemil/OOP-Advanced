namespace _08PetClinic.Models
{
    using System;
    using _08PetClinic.Interfaces;

    public class Pet : IAnimal
    {
        private string name;
        private int age;
        private string kind;

        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
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

        public string Kind
        {
            get
            {
                return this.kind;
            }
            private set
            {
                this.kind = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Kind}";
        }
    }
}
