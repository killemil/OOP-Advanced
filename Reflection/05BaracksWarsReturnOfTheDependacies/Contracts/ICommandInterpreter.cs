namespace _05BaracksWarsReturnOfTheDependacies.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }
}
