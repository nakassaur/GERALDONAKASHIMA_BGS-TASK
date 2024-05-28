using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForOpenMenus
{
    #region Singleton Setup
    public static CheckForOpenMenus singleton;
    void Awake()
    {
        singleton = this;
    }
    #endregion

    public bool IsOpen => InGameMenuManager.singleton.isVisible ||
                          DialogUIManager.singleton.isVisible ||
                          ShopUIManager.singleton.isVisible;
}
