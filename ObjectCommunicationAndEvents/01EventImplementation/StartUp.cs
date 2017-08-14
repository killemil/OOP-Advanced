using System;

namespace _01EventImplementation
{
    public class StartUp
    {
        public static void Main()
        {
            Handler handler = new Handler();
            Dispatcher dispatcher = new Dispatcher();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input = Console.ReadLine();
            while (input != "End")
            {
                dispatcher.Name = input;
                input = Console.ReadLine();
            }
        }
    }
}
