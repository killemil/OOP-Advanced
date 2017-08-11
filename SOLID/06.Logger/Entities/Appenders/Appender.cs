namespace _06.Logger.Entities.Appenders
{
    using System;
    using _06.Logger.Enums;
    using _06.Logger.Interfaces;
    using System.Text;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public int Count { get; protected set; }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, string reportLevel, string message);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            return sb.Append($"Appender type: {this.GetType().Name}, ")
                .Append($"Layout type: {this.Layout.GetType().Name}, ")
                .Append($"Report level: {this.ReportLevel.ToString().ToUpper()}, ")
                .Append($"Message appender: {this.Count}")
                .ToString();    
        }
    }
}
