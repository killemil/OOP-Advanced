using System.Text;

public abstract class Item : IItem
{
    private string name;
    private long strengthBonus;
    private long agilityBonus;
    private long intelligenceBonus;
    private long hitPointsBonus;
    private long damageBonus;

    protected Item(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name { get => name; set => name = value; }

    public long StrengthBonus { get => strengthBonus; set => strengthBonus = value; }

    public long AgilityBonus { get => agilityBonus; set => agilityBonus = value; }

    public long IntelligenceBonus { get => intelligenceBonus; set => intelligenceBonus = value; }

    public long HitPointsBonus { get => hitPointsBonus; set => hitPointsBonus = value; }

    public long DamageBonus { get => damageBonus; set => damageBonus = value; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"###Item: {this.Name}");
        sb.AppendLine($"###+{this.StrengthBonus} Strength");
        sb.AppendLine($"###+{this.agilityBonus} Agility");
        sb.AppendLine($"###+{this.intelligenceBonus} Intelligence");
        sb.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        sb.AppendLine($"###+{this.damageBonus} Damage");

        return sb.ToString().Trim();
    }
}
