namespace _06.Logger.Core
{
    using System;
    using _06.Logger.Entities;
    using _06.Logger.Entities.Appenders.Factory;
    using _06.Logger.Entities.Layouts.Factory;
    using _06.Logger.Interfaces;
    using System.Globalization;
    using _06.Logger.Enums;
    using System.Reflection;

    public class Controller
    {
        private LayoutFactory layoutFactory;
        private AppenderFactory appenderFactory;
        private ILogger logger;

        public Controller(LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            this.layoutFactory = layoutFactory;
            this.appenderFactory = appenderFactory;
        }

        private IAppender[] ReadAllAppenders(IReader reader)
        {
            int appendersCount = int.Parse(reader.ReadLine());
            IAppender[] appenders = new IAppender[appendersCount];

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderTokens = reader.ReadLine().Split();
                string appenderType = appenderTokens[0];
                string layoutType = appenderTokens[1];

                ILayout layout = this.layoutFactory.CreateLayout(layoutType);
                IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);

                if (appenderTokens.Length > 2)
                {
                    string reportLevelName = ConvertToTitleCase(appenderTokens[2]);
                    ReportLevel reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelName);
                    appender.ReportLevel = reportLevel;
                }

                appenders[i] = appender;
            }

            return appenders;
        }

        private string ConvertToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        public void InitializeLogger(IReader reader)
        {
            IAppender[] appenders = this.ReadAllAppenders(reader);
            this.logger = new Logger(appenders);
        }

        public void SendMessageToLogger(string message)
        {
            string[] tokens = message.Split('|');
            string methodName = this.ConvertToTitleCase(tokens[0]);
            MethodInfo currentMethod = typeof(Logger).GetMethod(methodName);
            currentMethod.Invoke(this.logger, new object[] { tokens[1], tokens[2] });
        }

        public string GetLoggerInfo()
        {
            return this.logger.ToString();
        }
    }
}
