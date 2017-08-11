namespace _06.Logger.Core.IO
{
    using System;
    using _06.Logger.Interfaces;

    public class Reader : IReader
    {
        public string ReadLine()
        {
           return Console.ReadLine();
        }
    }
}
