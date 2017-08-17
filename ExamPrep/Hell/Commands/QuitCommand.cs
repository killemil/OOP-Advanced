using System;
using System.Collections.Generic;

public class QuitCommand : Command
{
    public QuitCommand(IList<string> data, IManager manger)
        : base(data, manger)
    {
    }

    public override string Execute()
    {
       return this.Manager.Quit();
    }
}