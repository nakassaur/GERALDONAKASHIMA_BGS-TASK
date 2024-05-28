using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DialogUISO", menuName = "ScriptableObject/DialogUISO")]
public class DialogUISO : ScriptableObject
{
    public DialogData ActiveDialogData;

    //
    public delegate void SetNPCNameDelegate(string name);
    public event SetNPCNameDelegate EventOnSetNPCName;

    public void SetNPCName(string name) { this.EventOnSetNPCName?.Invoke(name); }

    //
    public delegate void ShowDelegate();
    public event ShowDelegate EventOnShow;

    public void Show() { this.EventOnShow?.Invoke(); }

    public delegate void HideDelegate();
    public event HideDelegate EventOnHide;

    public void Hide() { this.EventOnHide?.Invoke(); }

    //
    public delegate void LoadDataDelegate();
    public event LoadDataDelegate EventOnLoadData;

    public void LoadData() {  this.EventOnLoadData?.Invoke(); }
}
