namespace _06Tuple.Models
{
    public class CustomTuple<T, V, K>
    {
        public CustomTuple(T item1, V item2, K item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public T Item1 { get; set; }
        public V Item2 { get; set; }
        public K Item3 { get; set; }

        public override string ToString()
        {

            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
