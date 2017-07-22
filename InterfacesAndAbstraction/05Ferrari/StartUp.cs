namespace _05Ferrari
{
    using System;
    using _05Ferrari.Models;

    public class StartUp
    {
        public static void Main()
        {
            string driverName = Console.ReadLine();
            ICar car = new Ferrari(driverName);

            Console.WriteLine($"{car.Model}/{car.Brake()}/{car.Accelerate()}/{car.Driver}");

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

        }
    }
}
