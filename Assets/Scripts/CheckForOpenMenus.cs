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

    public bool IsOpen => CheckIfMenusAreOpen();

    private bool CheckIfMenusAreOpen()
    {
        /*if (SettingsManager.singleton != null)
        {
            if (SettingsManager.singleton.isVisible == true)
                return true;
        }*/

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

        return false;
    }
}
