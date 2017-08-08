namespace _01Database
{
    public class StartUp
    {
        public static void Main()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4 });
            int[] result = database.Fetch();

            System.Console.WriteLine(string.Join(" ",result));
        }
    }
}
