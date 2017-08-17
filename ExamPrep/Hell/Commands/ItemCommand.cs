using System;
using System.Collections.Generic;

public class ItemCommand : Command
{
    public ItemCommand(IList<string> data, IManager manager) 
        : base(data, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddCommonItemToHero(this.Data);
    }
}

