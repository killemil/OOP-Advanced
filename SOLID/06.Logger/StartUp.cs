namespace _06.Logger
{
    using _06.Logger.Core;
    using _06.Logger.Core.IO;
    using _06.Logger.Entities;
    using _06.Logger.Entities.Appenders;
    using _06.Logger.Entities.Appenders.Factory;
    using _06.Logger.Entities.Layouts;
    using _06.Logger.Entities.Layouts.Factory;
    using _06.Logger.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            AppenderFactory appenderFactory = new AppenderFactory();
            LayoutFactory layoutFactory = new LayoutFactory();

            Controller controller = new Controller(layoutFactory, appenderFactory);
            Engine engine = new Engine(reader, writer, controller);

            engine.Run();
        }
    }
}
