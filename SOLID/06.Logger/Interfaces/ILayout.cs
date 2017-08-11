namespace _06.Logger.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string dateTime, string reportLevel, string message);
    }
}
