using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUDManager : MonoBehaviour
{
    [SerializeField] PlayerHUDSO PlayerHUDSO;

    [SerializeField] TMP_Text _currencyText;
    [SerializeField] GameObject _interactionMainContainer;

    void Start()
    {
        PlayerHUDSO.EventOnSetInteractionPromptVisibility += PlayerHUDSO_EventOnSetInteractionPromptVisibility;
        PlayerHUDSO.EventOnSetCurrencyAmount += PlayerHUDSO_EventOnSetCurrencyAmount;
    }

    void OnDestroy()
    {
        PlayerHUDSO.EventOnSetInteractionPromptVisibility -= PlayerHUDSO_EventOnSetInteractionPromptVisibility;
        PlayerHUDSO.EventOnSetCurrencyAmount -= PlayerHUDSO_EventOnSetCurrencyAmount;
    }

    void PlayerHUDSO_EventOnSetInteractionPromptVisibility(bool logic)
    {
        _interactionMainContainer.SetActive(logic);
    }

    void PlayerHUDSO_EventOnSetCurrencyAmount(int amount)
    {
        _currencyText.text = amount.ToString();
    }
}
