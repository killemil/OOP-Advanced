
using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private IList<CoffeeType> coffeesSold;
    private int coins;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold { get { return this.coffeesSold; } }

    public void BuyCoffee(string size, string type)
    {
        CoffeePrice coffeSize = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        CoffeeType coffeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

        if (this.coins >= (int)coffeSize)
        {
            this.coffeesSold.Add(coffeType);
            this.coins -= (int)coffeSize;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin coinValue = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)coinValue;
    }

}

