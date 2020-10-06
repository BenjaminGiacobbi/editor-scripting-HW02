using System;
using UnityEngine;

[Serializable]
public class Equipment
{
    public string itemName;
    public int statValue;
    public Rarity itemRarity;
    public Slot itemSlot; 
}

public enum Rarity { Common, Uncommon, Rare, UltraRare, Legendary }

public enum Slot { Helmet, Chest, Gauntlet, Greaves, Boots }