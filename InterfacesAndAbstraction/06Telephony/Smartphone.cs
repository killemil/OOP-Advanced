namespace _06Telephony
{
    using System.Linq;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (number.Any(c => char.IsLetter(c)))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }
    }
}
