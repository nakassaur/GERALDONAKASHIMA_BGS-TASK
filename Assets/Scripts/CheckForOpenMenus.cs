using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckForOpenMenus : MonoBehaviour
{
    #region Singleton Setup
    public static CheckForOpenMenus singleton;
    void Awake()
    {
        singleton = this;
    }
    #endregion

    [SerializeField] SettingsSO SettingsSO;
    [SerializeField] InGameMenuSO InGameMenuSO;
    [SerializeField] ShopUISO ShopUISO;
    [SerializeField] DialogUISO DialogUISO;
    [SerializeField] WardrobeUISO WardrobeUISO;

    public bool IsOpen => CheckIfMenusAreOpen();

    private bool CheckIfMenusAreOpen()
    {
        if (SettingsManager.singleton != null)
        {
            if (SettingsManager.singleton.isVisible == true)
                return true;
        }

        if (InGameMenuManager.singleton != null)
        {
            if (InGameMenuManager.singleton.isVisible == true)
                return true;
        }

        if (ShopUIManager.singleton != null)
        {
            if (ShopUIManager.singleton.isVisible == true)
                return true;
        }

        if (DialogUIManager.singleton != null)
        {
            if (DialogUIManager.singleton.isVisible == true)
                return true;
        }

        if (WardrobeUIManager.singleton != null)
        {
            if (WardrobeUIManager.singleton.isVisible == true)
                return true;
        }

        return false;
    }

    public void CloseAllMenus()
    {
        SettingsSO.Hide();
        InGameMenuSO.Hide();
        ShopUISO.Hide();
        DialogUISO.Hide();
        WardrobeUISO.Hide();
    }
}
