namespace BashSoft
{
    using System;
    using BashSoft.Contracts;

    public class InputReader : IReader
    {
        private const string EndCommand = "quit";

        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}>");
            string input = Console.ReadLine();
            input = input.Trim();

            while (!input.Equals(EndCommand))
            {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}>");
                input = Console.ReadLine();
                input = input.Trim();
            }
        }
    }
}
