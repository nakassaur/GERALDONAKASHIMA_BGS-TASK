using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogAction
{
    Talk,
    Shop,
    Leave
}

[CreateAssetMenu(fileName = "New DialogData", menuName = "ScriptableObject/DialogData")]
public class DialogData : ScriptableObject
{
    public string DialogString;
    public DialogAction DialogAction;
}
