using System;
using System.Linq;

namespace _04Froggy
{
    public class StartUp
    {
        public static void Main()
        {
            Lake myLake = new Lake(Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Console.WriteLine(string.Join(", ",myLake));
        }
    }
}
