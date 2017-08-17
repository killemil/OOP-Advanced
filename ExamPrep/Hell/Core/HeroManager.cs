using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    public IDictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<string> arguments)
    {
        string result = string.Empty;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type currentHeroType = Type.GetType(heroType);
            ConstructorInfo constructor = currentHeroType.GetConstructors().First();
            IHero hero = (IHero)constructor.Invoke(new object[] { heroName });
            this.heroes.Add(heroName, hero);

            result = string.Format(Constants.HeroCreateMessage, heroType, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddCommonItemToHero(IList<string> arguments)
    {
        string result = string.Empty;

        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        this.heroes[heroName].Inventory.AddCommonItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecipeItemToHero(IList<string> arguments)
    {
        string result = string.Empty;

        string itemName = arguments[0];
        string heroName = arguments[1];
        long strengthBonus = long.Parse(arguments[2]);
        long agilityBonus = long.Parse(arguments[3]);
        long intelligenceBonus = long.Parse(arguments[4]);
        long hitPointsBonus = long.Parse(arguments[5]);
        long damageBonus = long.Parse(arguments[6]);
        string[] requiredItems = arguments.Skip(7).ToArray();

        IRecipe recipeItem = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);
        this.heroes[heroName].Inventory.AddRecipeItem(recipeItem);

        result = string.Format(Constants.RecipeCreatedMessage, itemName, heroName);

        return result;
    }

    public string InspectHero(IList<string> arguments)
    {
        string heroName = arguments[0];
        StringBuilder sb = new StringBuilder();
        IHero hero = this.heroes[heroName];

        sb.AppendLine($"Hero: {heroName}, Class: {hero.GetType().Name}");
        sb.AppendLine($"HitPoints: {hero.HitPoints}, Damage: {hero.Damage}");
        sb.AppendLine($"Strength: {hero.Strength}");
        sb.AppendLine($"Agility: {hero.Agility}");
        sb.AppendLine($"Intelligence: {hero.Intelligence}");
        sb.AppendLine($"Items:{(hero.Items.Count <= 0 ? " None" : Environment.NewLine + string.Join(Environment.NewLine, hero.Items))}");


        return sb.ToString().Trim();
    }

    public string Quit()
    {
        StringBuilder sb = new StringBuilder();
        int counter = 1;
        foreach (var hero in this.heroes.Values
            .OrderByDescending(h => (h.Strength + h.Agility + h.Intelligence))
            .ThenByDescending(h => h.HitPoints + h.Damage))
        {
            sb.AppendLine($"{counter}. {hero.ToString()}");
            counter++;
        }

        return sb.ToString().Trim();
    }
}