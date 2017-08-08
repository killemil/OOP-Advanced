namespace BashSoft.Exceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        private const string DisplayInvalidCommandMessage = "The command '{0}' is invalid";

        public InvalidCommandException(string command)
            : base(string.Format(DisplayInvalidCommandMessage, command))
        {
        }
    }
}