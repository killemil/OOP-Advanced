using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private string name;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            this.name = value;
        }
    }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            Type type = this.inventory.GetType();
            FieldInfo field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute),true).Length != 0);
            IDictionary<string, IItem> items = (Dictionary<string, IItem>)field.GetValue(this.inventory);

            return items.Select(x => x.Value).ToList();
        }
    }

    public IInventory Inventory
    {
        get
        {
            return this.inventory;
        }
        private set
        {
            this.inventory = value;
        }
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public void AddCommonItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name}: {this.Name}");
        sb.AppendLine($"###HitPoints: {this.HitPoints}");
        sb.AppendLine($"###Damage: {this.Damage}");
        sb.AppendLine($"###Strength: {this.Strength}");
        sb.AppendLine($"###Agility: {this.Agility}");
        sb.AppendLine($"###Intelligence: {this.Intelligence}");
        sb.AppendLine($"###Items: {(this.Items.Count == 0 ? "None" : string.Join(", ", this.Items.Select(i => i.Name)))}");

        return sb.ToString().Trim();
    }
}