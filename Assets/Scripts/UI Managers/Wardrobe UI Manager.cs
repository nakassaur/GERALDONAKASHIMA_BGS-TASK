using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeUIManager : MonoBehaviour
{
    #region Singleton Setup
    public static WardrobeUIManager singleton;
    void Awake()
    {
        singleton = this;
    }
    #endregion

    [SerializeField] LoadingScreenSO LoadingScreenSO;
    [SerializeField] WardrobeUISO WardrobeUISO;

    [SerializeField] GameObject _mainContainer;
    [SerializeField] TabManager _tabManager;

    public bool isVisible => _mainContainer.activeSelf;

    // Built-in Functions
    void Start()
    {
        LoadingScreenSO.EventOnLoadComplete += LoadingScreenSO_EventOnLoadComplete;

        WardrobeUISO.EventOnShow += WardrobeUISO_EventOnShow;
        WardrobeUISO.EventOnHide += WardrobeUISO_EventOnHide;

        // -- Force Open because some scripts need to be initialized
        _mainContainer.SetActive(true);
    }
        
    void OnDestroy()
    {
        LoadingScreenSO.EventOnLoadComplete -= LoadingScreenSO_EventOnLoadComplete;

        WardrobeUISO.EventOnShow -= WardrobeUISO_EventOnShow;
        WardrobeUISO.EventOnHide -= WardrobeUISO_EventOnHide;
    }

    // Event Signature
    void LoadingScreenSO_EventOnLoadComplete()
    {
        // Disabled only after the load is complete so Scripts have time to init
        _mainContainer.SetActive(false);
    }

    void WardrobeUISO_EventOnShow()
    {
        _mainContainer.SetActive(true);
        _tabManager.SetIndex(0);
    }

    void WardrobeUISO_EventOnHide()
    {
        _tabManager.Reset();
        _mainContainer.SetActive(false);
    }
    
}
