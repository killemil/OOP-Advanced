namespace _06.Logger.Entities
{
    using System;
    using _06.Logger.Interfaces;
    using _06.Logger.Enums;
    using System.Text;

    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        private void Log(string dateTime, string reportLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                ReportLevel currentReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);

                if (appender.ReportLevel <= currentReportLevel)
                {
                    appender.Append(dateTime, reportLevel.ToUpper(), message);
                }
            }
        }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, "Critical", message);
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, "Error", message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, "Fatal", message);
        }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, "Info", message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Log(dateTime, "Warning", message);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");
            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString();
        }
    }
}
