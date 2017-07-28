namespace _04CardSuit
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] cardTypes = Enum.GetNames(typeof(CardSuit));

            Console.WriteLine($"{input}:");
            foreach (var card in cardTypes)
            {
                int oridnalValue = (int)Enum.Parse(typeof(CardSuit), card);
                Console.WriteLine($"Ordinal value: {oridnalValue}; Name value: {card}");
            }
        }
    }
}
