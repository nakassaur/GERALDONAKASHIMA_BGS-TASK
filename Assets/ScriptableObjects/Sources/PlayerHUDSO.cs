using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHUDSO", menuName = "ScriptableObject/PlayerHUDSO")]

public class PlayerHUDSO : ScriptableObject
{
    public delegate void SetCurrencyAmountDelegate(int amount);
    public event SetCurrencyAmountDelegate EventOnSetCurrencyAmount;

    public void SetCurrencyAmount(int amount) { this.EventOnSetCurrencyAmount?.Invoke(amount); }

    public delegate void SetInteractionPromptVisibilityDelegate(bool logic);
    public event SetInteractionPromptVisibilityDelegate EventOnSetInteractionPromptVisibility;

    public void SetInteractionPromptVisibility(bool logic) { this.EventOnSetInteractionPromptVisibility?.Invoke(logic);  }
}
