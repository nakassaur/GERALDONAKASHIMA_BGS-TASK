using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Database", menuName = "ScriptableObject/Database")]
public class Database : ScriptableObject
{
    [Header("General")]
    public int startingCurrency;

    [Header("Movement")]
    public float PlayerBaseSpeed;

    [Header("Interaction")]
    public float InteractionRadius;
    public LayerMask InteractionMask;

    [Header("General Dialog Data")]
    public DialogData OnPurchaseSuccessful;
    public DialogData OnPurchaseFailedNotEnoughMoney;
    public DialogData OnPurchaseFailedUniqueCheck;

    [Header("Item Options")]
    public Transform itemOptionPrefab;

    [Header("Default Wardrobe Options")]
    public Item NoHatOption;
    
}
