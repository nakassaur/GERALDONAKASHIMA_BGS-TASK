using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogAction
{
    Talk,
    Shop,
    Leave
}

[System.Serializable]
public struct DialogOption
{
    public string OptionText;
    public DialogAction DialogAction;

    [Tooltip("Used to append DialogData or ShopData for the Actions of Talk/Shop respectively")]
    public ScriptableObject ContextObj;
}

[CreateAssetMenu(fileName = "New DialogData", menuName = "ScriptableObject/DialogData")]
public class DialogData : ScriptableObject
{
    [Header ("Text Message")]
    public string DialogString;

    [Header("Dialog Options. Hard Limit = 3")]
    public List<DialogOption> Options;
}
