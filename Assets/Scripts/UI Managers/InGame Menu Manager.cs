using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuManager : MonoBehaviour
{
    #region Singleton Setup
    public static InGameMenuManager singleton;
    void Awake()
    {
        singleton = this;
    }
    #endregion

    [SerializeField] LoadingScreenSO loadingScreenSO;
    [SerializeField] InGameMenuSO inGameMenuSO;

    [SerializeField] GameObject _mainContainer;

    public bool isVisible => _mainContainer.activeSelf;

    // Built-in Functions
    void Start()
    {
        inGameMenuSO.EventOnShow += InGameMenuSO_EventOnShow;
        inGameMenuSO.EventOnHide += InGameMenuSO_EventOnHide;
    }

    void OnDestroy()
    {
        inGameMenuSO.EventOnShow -= InGameMenuSO_EventOnShow;
        inGameMenuSO.EventOnHide -= InGameMenuSO_EventOnHide;
    }

    // Public Methods
    public void ExitToMainMenu()
    {
        loadingScreenSO.Show();
        loadingScreenSO.LoadScene((int) SceneIndex.MENU);        
    }

    // Event Signature
    void InGameMenuSO_EventOnShow()
    {
        _mainContainer.SetActive(true);
    }

    void InGameMenuSO_EventOnHide()
    {
        _mainContainer.SetActive(false);
    }
        
}
