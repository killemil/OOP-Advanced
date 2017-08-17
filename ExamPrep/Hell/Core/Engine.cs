using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private IManager heroManager;
    private bool isRunning;

    public Engine(IInputReader reader, IOutputWriter writer, IManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            IList<string> arguments = this.parseInput(inputLine);

            this.writer.WriteLine(this.processInput(arguments));
            if (inputLine == "Quit")
            {
                isRunning = false;
            }
        }
    }

    private List<string> parseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string processInput(IList<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        object[] parametersForConstruction = new object[]
        {
            arguments,this.heroManager
        };
        //ConstructorInfo constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });

        Type commandType = Type.GetType(command + "Command");
        IExecutable exe = (IExecutable)Activator.CreateInstance(commandType, parametersForConstruction);
        //IExecutable cmd = (Command)constructor.Invoke(new object[] { arguments, this.heroManager });
        return exe.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}