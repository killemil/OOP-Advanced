﻿using System.Collections.Generic;

public interface IHero
{
    string Name { get; }

    long Strength { get; set; }

    long Agility { get; set; }

    long Intelligence { get; set; }

    long HitPoints { get; set; }

    long Damage { get; set; }

    IInventory Inventory { get; }

    ICollection<IItem> Items { get; }
}
