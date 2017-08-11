namespace _06.Logger.Entities.Layouts
{
    using System.Text;
    using _06.Logger.Interfaces;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();

            return sb.AppendLine($"<log>")
                .AppendLine($"   <date>{dateTime}</date>")
                .AppendLine($"   <level>{reportLevel}</level>")
                .AppendLine($"   <message>{message}</message>")
                .AppendLine($"</log>")
                .ToString();
        }
    }
}
