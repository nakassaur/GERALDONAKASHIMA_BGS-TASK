using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region Singleton Setup
    public static PlayerInventory singleton;
    void Awake()
    {
        singleton = this;
    }
    #endregion

    // For simplicity sake I will use a unique item list which means only one entry of each ID will be allowed.
    // In a more broad project I'd restrict only outfits (Hats and Clothing) to this approach because it's more
    // comfortable to the player.

    // For general purpose Inventory, which would have consumables, tools and materials, I'd make use of an
    // extension of the Item ScriptableObject to keep track of Quality and Quantity of those items

    public List<Item> apparel = new List<Item>();

    // Public Methods
    public bool CheckIfIHaveThis(Item item)
    {
        return apparel.Contains(item);
    }

    
}
