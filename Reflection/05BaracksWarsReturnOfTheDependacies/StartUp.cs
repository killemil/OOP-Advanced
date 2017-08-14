namespace _05BaracksWarsReturnOfTheDependacies
{
    using _05BaracksWarsReturnOfTheDependacies.Contracts;
    using _05BaracksWarsReturnOfTheDependacies.Core;
    using _05BaracksWarsReturnOfTheDependacies.Core.Factories;
    using _05BaracksWarsReturnOfTheDependacies.Data;

    public class StartUp
    {
        public static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
