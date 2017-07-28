
namespace _07CustomEnumAttribute
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Type typeRank = typeof(Rank);
            Type typeSuit = typeof(Suit);
            object[] rankAttributes = typeRank.GetCustomAttributes(false);
            object[] suitAttributes = typeSuit.GetCustomAttributes(false);

            if (input == "Rank")
            {
                foreach (TypeAttribute attr in rankAttributes)
                {
                    Console.WriteLine($"Type = {attr.Type}, Description = {attr.Description}");
                }
            }
            else if(input == "Suit")
            {
                foreach (TypeAttribute attr in suitAttributes)
                {
                    Console.WriteLine($"Type = {attr.Type}, Description = {attr.Description}");
                }
            }
        }
    }
}
