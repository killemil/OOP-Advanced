namespace _02ListyIterator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string inputLine = Console.ReadLine();
            string[] elements = inputLine.Split().Skip(1).ToArray();
            var myList = new ListyIterator<string>(elements);

            while ((inputLine = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = inputLine.Split();
                    string command = tokens[0];

                    if (command == "Move")
                    {
                        Console.WriteLine(myList.Move());
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(myList.HasNext());
                    }
                    else if (command == "Print")
                    {
                        myList.Print();
                    }
                    else if (command == "PrintAll")
                    {
                        Console.WriteLine(string.Join(" ",myList));
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Operation!");
                }
            }
        }
    }
}
