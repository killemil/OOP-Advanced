namespace _06.Logger.Entities.Appenders
{
    using System;
    using _06.Logger.Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string dateTime, string reportLevel, string message)
        {
            this.Count++;
            string formattedMsg = this.Layout.FormatMessage(dateTime, reportLevel, message);
            Console.WriteLine(formattedMsg);
        }
    }
}
