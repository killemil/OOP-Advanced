using System;
using System.Collections.Generic;

public class HeroCommand : Command
{
    public HeroCommand(IList<string> data, IManager manger)
        : base(data, manger)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddHero(this.Data);
    }
}
