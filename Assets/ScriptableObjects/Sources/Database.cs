using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Database", menuName = "ScriptableObject/Database")]
public class Database : ScriptableObject
{
    [Header("Movement")]
    public float PlayerBaseSpeed;

    [Header("Interaction")]
    public float InteractionRadius;
    public LayerMask InteractionMask;
}
