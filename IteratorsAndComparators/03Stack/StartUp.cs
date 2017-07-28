namespace _03Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] tokens = inputLine
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                int[] elements = tokens.Skip(1).Select(int.Parse).ToArray();

                if (command == "Push")
                {
                    myStack.Push(elements);
                }
                else if (command == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
