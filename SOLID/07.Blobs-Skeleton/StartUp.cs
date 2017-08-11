using _02.Blobs.Core;
using _02.Blobs.Core.IO;
using _02.Blobs.Interfaces.IO;

namespace _02.Blobs
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            GameExecutor gameExecutor = new GameExecutor();

            Engine engine = new Engine(writer, reader, gameExecutor);
            engine.Run();
        }
    }
}
