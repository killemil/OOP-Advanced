namespace _05CustomList.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private bool isRunning ;
        private ListManager manager;

        public Engine()
        {
            this.isRunning = true;
            this.manager = new ListManager();
        }

        public void Run()
        {
            while (isRunning)
            {
                string[] tokens = Console.ReadLine().Split();
                Execute(tokens);
            }
        }

        private void Execute(string[] tokens)
        {
            string command = tokens[0];
            tokens = tokens.Skip(1).ToArray();

            switch (command.ToLower())
            {
                case "add":
                    manager.Add(tokens[0]);
                    break;
                case "remove":
                    manager.Remove(int.Parse(tokens[0]));
                    break;
                case "contains":
                    manager.Contains(tokens[0]);
                    break;
                case "swap":
                    manager.Swap(int.Parse(tokens[0]), int.Parse(tokens[1]));
                    break;
                case "greater":
                    manager.Greater(tokens[0]);
                    break;
                case "max":
                    manager.Max();
                    break;
                case "min":
                    manager.Min();
                    break;
                case "print":
                    manager.Print();
                    break;
                case "sort":
                    manager.Sort();
                    break;
                case "end":
                    isRunning = false;
                    break;
            }
        }
    }
}
