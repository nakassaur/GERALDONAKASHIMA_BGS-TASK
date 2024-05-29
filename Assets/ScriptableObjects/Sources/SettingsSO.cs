using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsSO", menuName = "ScriptableObject/SettingsSO")]
public class SettingsSO : ScriptableObject
{
    //
    public delegate void ShowDelegate();
    public event ShowDelegate EventOnShow;

    public void Show() { this.EventOnShow?.Invoke(); }

    public delegate void HideDelegate();
    public event HideDelegate EventOnHide;

    public void Hide() { this.EventOnHide?.Invoke(); }
}