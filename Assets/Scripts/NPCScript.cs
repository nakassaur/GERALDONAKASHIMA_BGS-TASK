using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour, IInteractable
{
    [SerializeField] DialogUIManager DialogUIManager;
    [SerializeField] ShopUIManager ShopUIManager;

    [SerializeField] ShopData shopData;

    public void Interact()
    {

    }
}
