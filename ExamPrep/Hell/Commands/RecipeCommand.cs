using System;
using System.Collections.Generic;

public class RecipeCommand : Command
{
    public RecipeCommand(IList<string> data, IManager manager) 
        : base(data, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddRecipeItemToHero(this.Data);
    }
}
