namespace _06Telephony
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            IEnumerable<string> phoneNumbers = Console.ReadLine()
                .Split();
            IEnumerable<string> webSites = Console.ReadLine()
                .Split();

            ICallable call = new Smartphone();
            IBrowsable browse = new Smartphone();

            foreach (var number in phoneNumbers)
            {
                Console.WriteLine(call.Call(number));
            }
            foreach (var url in webSites)
            {
                Console.WriteLine(browse.Browse(url));
            }
        }
    }
}
