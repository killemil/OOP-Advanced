namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;
    using _03BarracksFactory.Core.Commands;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName).Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private IExecutable InterpredCommand(string[] data, string commandName)
        {
            Type typeOfCommand = Assembly.GetExecutingAssembly()
                .DefinedTypes
                .FirstOrDefault(x => x.Name.ToLower() == commandName + "command");
            object[] parameters = new object[] { data, this.repository, this.unitFactory };
            Command command = (Command)Activator.CreateInstance(typeOfCommand, parameters);

            return command;
        }
    }
}
