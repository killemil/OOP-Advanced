namespace _04GenericBox.Models
{
    using System;

    public class Box<T> : IComparable<Box<T>>
        where T : IComparable<T>
    {
        private T value;

        public Box(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            private set
            {
                this.value = value;
            }
        }

        public int CompareTo(Box<T> other)
        {
            return value.CompareTo(other.value);
        }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}
