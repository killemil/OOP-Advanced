namespace _06.Logger.Interfaces
{
    using _06.Logger.Enums;

    public interface IAppender
    {
        int Count { get; }

        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, string reportLevel, string message);
    }
}
