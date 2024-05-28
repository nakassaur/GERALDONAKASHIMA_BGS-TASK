using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopUISO", menuName = "ScriptableObject/ShopUISO")]
public class ShopUISO : ScriptableObject
{
    public ShopData ActiveShopData;

    public void SetShopData(ShopData data) { ActiveShopData = data; }

    //
    public delegate void ShowDelegate();
    public event ShowDelegate EventOnShow;

    public void Show() { this.EventOnShow?.Invoke(); }

    public delegate void HideDelegate();
    public event HideDelegate EventOnHide;

    public void Hide() { this.EventOnHide?.Invoke(); }
}
