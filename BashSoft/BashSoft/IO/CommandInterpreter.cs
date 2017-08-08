namespace BashSoft
{
    using System;
    using System.Linq;
    using System.Reflection;
    using BashSoft.Contracts;
    using BashSoft.IO.Commands;
    using BashSoft.Attributes;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];
            commandName = commandName.ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstruction = new object[]
            {
                input,data
            };

            Type typeOfCommand = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                        .Where(atr => atr.Equals(command))
                        .ToArray()
                        .Length > 0);
            Type typeOfInterpreter = typeof(CommandInterpreter);
            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAtribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAtribute != null)
                {
                    if (fieldsOfInterpreter.Any(f=> f.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.
                            SetValue(exe, fieldsOfInterpreter.First(x => x.FieldType == fieldOfCommand.FieldType).GetValue(this));
                    }
                }
            }

            return exe;
        }

        private void TryDownloadFile(string input, string[] data)
        {
            throw new NotImplementedException();
        }

        private void TryDownloadeAsynch(string input, string[] data)
        {
            throw new NotImplementedException();
        }
    }
}