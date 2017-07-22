namespace _06Tuple
{
    using System;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstLine = Console.ReadLine().Split();
            string[] secondLine = Console.ReadLine().Split();
            string[] thirdLine = Console.ReadLine().Split();

            CustomTuple<string, string, string> firstTuple = new CustomTuple<string, string, string>(
                firstLine[0] + " " + firstLine[1], firstLine[2], firstLine[3]);

            CustomTuple<string, int, string> secondTuple = new CustomTuple<string, int, string>(
                secondLine[0], int.Parse(secondLine[1]), (secondLine[2] == "drunk") ? "True" : "False");
            CustomTuple<string, double, string> thirdTuple = new CustomTuple<string, double, string>(
                thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);


        }
    }
}
