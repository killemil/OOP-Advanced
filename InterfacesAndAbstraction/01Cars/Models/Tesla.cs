using System;

public class Tesla : ICar, IElectricCar
{
    private int battery;
    private string model;
    private string color;

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }


    public int Battery
    {
        get { return battery; }
        set { battery = value; }
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {

        return $"{this.Color} {this.GetType().Name} {this.Model} with {this.battery} Batteries";
    }
}

