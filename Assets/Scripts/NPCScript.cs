using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour, IInteractable
{
    [SerializeField] DialogUISO DialogUISO;

    [SerializeField] string _npcDisplayName;
    [SerializeField] DialogData _dialogData;

    public void Interact()
    {
        DialogUISO.SetNPCName(_npcDisplayName);
        DialogUISO.ActiveDialogData = _dialogData;
        DialogUISO.Show();
        DialogUISO.LoadData();
    }
}
