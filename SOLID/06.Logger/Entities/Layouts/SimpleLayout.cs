namespace _06.Logger.Entities.Layouts
{
    using System;
    using _06.Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}
