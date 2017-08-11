using _02.Blobs.Interfaces.IO;

namespace _02.Blobs.Core
{
    public class Engine
    {
        private bool isRunnig;
        private IWriter writer;
        private IReader reader;
        private GameExecutor gameExecutor;

        public Engine(IWriter writer, IReader reader, GameExecutor gameExecutor)
        {
            this.writer = writer;
            this.reader = reader;
            this.gameExecutor = gameExecutor;
        }

        public void Run()
        {
            this.isRunnig = true;

            while (this.isRunnig)
            {
                string lineRead = this.reader.ReadLine();
                if (lineRead == "drop")
                {
                    this.isRunnig = false;
                    continue;
                }

                this.gameExecutor.PlayAction(lineRead, this.writer);
            }
        }
    }
}
