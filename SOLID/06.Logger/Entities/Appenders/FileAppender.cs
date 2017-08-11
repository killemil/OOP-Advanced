namespace _06.Logger.Entities.Appenders
{
    using System;
    using _06.Logger.Interfaces;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout) : base(layout)
        {
            this.File = new LogFile();
        }

        public LogFile File { get; set; }

        public override void Append(string dateTime, string reportLevel, string message)
        {
            this.Count++;
            string formatedMsg = this.Layout.FormatMessage(dateTime, reportLevel, message);
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
