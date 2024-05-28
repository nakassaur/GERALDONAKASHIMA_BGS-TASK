using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Data", menuName = "ScriptableObject/Shop Data")]
public class ShopData : ScriptableObject
{
    [Tooltip("The name to be displayed at the top of the Shop UI")]
    public string shopName;

    [Tooltip("The Sprite to be used as a Logo in the Shop UI Banner")]
    public Sprite shopSprite;

    [Tooltip("The Items that should populate the shop item list")]
    public List<Item> items;
}
