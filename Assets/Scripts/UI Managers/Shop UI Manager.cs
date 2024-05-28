using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : MonoBehaviour
{
    #region Singleton Setup
    public static ShopUIManager singleton;
    void Awake()
    {
        singleton = this;    
    }
    #endregion

    [SerializeField] ShopUISO ShopUISO;

    [SerializeField] GameObject _mainContainer;

    public bool isVisible => _mainContainer.activeSelf;

    // Built-in Functions
    void Start()
    {
        ShopUISO.EventOnShow += ShopUISO_EventOnShow;
        ShopUISO.EventOnHide += ShopUISO_EventOnHide;
    }

    void OnDestroy()
    {
        ShopUISO.EventOnShow -= ShopUISO_EventOnShow;
        ShopUISO.EventOnHide -= ShopUISO_EventOnHide;
    }

    // Event Signature
    void ShopUISO_EventOnShow()
    {
        _mainContainer.SetActive(true);
    }

    void ShopUISO_EventOnHide()
    {
        _mainContainer.SetActive(false);
    }
    
}
