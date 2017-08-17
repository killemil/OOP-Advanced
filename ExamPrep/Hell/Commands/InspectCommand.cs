using System;
using System.Collections.Generic;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> data, IManager manager) 
        : base(data, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.InspectHero(this.Data);
    }
}

