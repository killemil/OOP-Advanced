namespace _06.Logger.Core.IO
{
    using System;
    using _06.Logger.Interfaces;

    public class Writer : IWriter
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }
}
