namespace _07EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Person;
            if (item == null)
            {
                return false;   
            }

            return this.Name.Equals(item.Name) && this.Age.Equals(item.Age);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() * 17 + this.Age.GetHashCode();
        }
    }
}
