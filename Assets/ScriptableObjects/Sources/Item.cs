using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory
{ 
    General,
    Equipment,    
    Outfit,
    Hat
}

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item")]
public class Item : ScriptableObject
{
    [Tooltip("The NAME of the Item that will be shown in the ITEM LIST")]
    public string DisplayName;

    [Tooltip("Determines whether the Item is usable as a Tool or wearable as a Hat/Outfit")]
    public ItemCategory Category;

    [Tooltip("The SPRITE that represents this Item in UI ELEMENTS")]
    public Sprite MenuSprite;

    [Tooltip("The amount of coins needed for the Player to PURCHASE this item")]
    public int Price;
    
    [Tooltip("The DESCRIPTION to be showed when it's HIGHLIGHTED")]
    public string Description;
}
