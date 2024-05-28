using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopUISO", menuName = "ScriptableObject/ShopUISO")]
public class ShopUISO : ScriptableObject
{
    public Transform ItemOptionPrefab;

    public ShopData ActiveShopData;

    public void SetShopData(ShopData data) { ActiveShopData = data; }

    public delegate void HighlightedItemUpdatedDelegate(Item item);
    public event HighlightedItemUpdatedDelegate EventOnHighlightedItemUpdated;

    public void SetHighlightedItem(Item item) {  this.EventOnHighlightedItemUpdated?.Invoke(item); }

    public delegate void ShowShopModalDelegate(Item item);
    public event ShowShopModalDelegate EventOnShowShopModal;
    
    public void ShowShopModal(Item item) {  this.EventOnShowShopModal?.Invoke(item); }

    //
    public delegate void ShowDelegate();
    public event ShowDelegate EventOnShow;

    public void Show() { this.EventOnShow?.Invoke(); }

    public delegate void HideDelegate();
    public event HideDelegate EventOnHide;

    public void Hide() { this.EventOnHide?.Invoke(); }
}
