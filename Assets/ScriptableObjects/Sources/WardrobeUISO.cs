using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WardrobeUISO", menuName = "ScriptableObject/WardrobeUISO")]
public class WardrobeUISO : ScriptableObject
{
    //
    public delegate void ShowDelegate();
    public event ShowDelegate EventOnShow;

    public void Show() { this.EventOnShow?.Invoke(); }

    public delegate void HideDelegate();
    public event HideDelegate EventOnHide;

    public void Hide() { this.EventOnHide?.Invoke(); }

    //
    public delegate void ForceListRefreshDelegate();
    public event ForceListRefreshDelegate EventOnForceListRefresh;

    public void ForceListRefresh() { this.EventOnForceListRefresh?.Invoke(); }
}
