using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    #region Singleton Setup
    public static WorldManager singleton;
    void Awake()
    {
        singleton = this;
    }
    #endregion

    [SerializeField] Database DB;
    [SerializeField] PlayerHUDSO PlayerHUDSO;
    [SerializeField] DialogUISO DialogUISO;
    [SerializeField] ShopUISO ShopUISO;
    [SerializeField] LoadingScreenSO LoadingScreenSO;

    int _currency;

    public PlayerScript player;

    // Properties
    public int Currency
    {
        get => _currency;
        private set 
        {
            if (value < 0) 
                _currency = 0;
            else
                _currency = value;

            PlayerHUDSO.SetCurrencyAmount(_currency);
        }
    }

    // Built-in Functions
    void Start()
    {
        //
        LoadingScreenSO.EventOnLoadComplete += LoadingScreenSO_EventOnLoadComplete;
        ShopUISO.EventOnTryPurchase += ShopUISO_EventOnTryPurchase;        
    }

    // Private Functions
    void TryPurchase(Item item)
    {
        bool isCosmetic = item.Category == ItemCategory.Shoe || item.Category == ItemCategory.Lower ||
                                  item.Category == ItemCategory.Top || item.Category == ItemCategory.Hairstyle ||
                                  item.Category == ItemCategory.Hat;

        if (isCosmetic && PlayerInventory.singleton.CheckIfIHaveThis(item) == true)
        {
            DialogUISO.ActiveDialogData = DB.OnPurchaseFailedUniqueCheck;
            DialogUISO.Show();
            DialogUISO.LoadData();
            return;
        }

        if (Currency < item.Price)
        {
            DialogUISO.ActiveDialogData = DB.OnPurchaseFailedNotEnoughMoney;
            DialogUISO.Show();
            DialogUISO.LoadData();
            return;
        }

        Currency -= item.Price;

        DialogUISO.ActiveDialogData = DB.OnPurchaseSuccessful;
        DialogUISO.Show();
        DialogUISO.LoadData();

        if (isCosmetic == true)
            PlayerInventory.singleton.apparel.Add(item);

        //
        // Add to PlayerInventory (General, not Apparel)
    }

    // Event Signatures
    void LoadingScreenSO_EventOnLoadComplete()
    {
        Currency = DB.startingCurrency;
    }

    void ShopUISO_EventOnTryPurchase(Item item)
    {
        TryPurchase(item);
    }
}
