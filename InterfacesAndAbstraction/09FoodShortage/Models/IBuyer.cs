namespace _09FoodShortage.Models
{
    public interface IBuyer : IName
    {
        int Food { get; }

        void BuyFood();
    }
}
