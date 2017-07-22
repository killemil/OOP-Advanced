namespace _04GenericBox
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            IList<double> boxes = new List<double>();

            for (int i = 0; i < numberOfLines; i++)
            {
                double value = double.Parse(Console.ReadLine());
                boxes.Add(value);
            }

            double comparingElement = double.Parse(Console.ReadLine());

            Console.WriteLine(Compare(boxes,comparingElement));
        }

        private static void SwapElements<T>(IList<T> list, int[] indexes)
        {
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            T firstElement = list[firstIndex];
            T secondElement = list[secondIndex];

            list[firstIndex] = secondElement;
            list[secondIndex] = firstElement;

            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }

        public static int Compare<T>(IList<T> list, T element)
            where T : IComparable<T>
        {
            int couter = 0;

            foreach (var e in list)
            {
                if (e.CompareTo(element) > 0)
                {
                    couter++;
                }
            }

            return couter;
        }
    }
}
