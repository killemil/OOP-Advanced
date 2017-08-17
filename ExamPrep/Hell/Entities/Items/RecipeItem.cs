using System;
using System.Collections.Generic;

public class RecipeItem : Item, IRecipe
{
    private IList<string> requiredItems;

    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, params string[] requiredItems)
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = requiredItems;
    }

    public IList<string> RequiredItems
    {
        get
        {
            return this.requiredItems;
        }
        private set
        {
            this.requiredItems = value;
        }
    }
}
