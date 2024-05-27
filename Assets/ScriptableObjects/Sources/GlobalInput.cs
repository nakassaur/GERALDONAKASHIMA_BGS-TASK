using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalInput", menuName = "ScriptableObject/GlobalInput")]
public class GlobalInput : ScriptableObject
{
    public delegate void OnSubmitDelegate();
    public event OnSubmitDelegate EventOnSubmit;

    public void OnSubmit() { this.EventOnSubmit?.Invoke(); }
}
