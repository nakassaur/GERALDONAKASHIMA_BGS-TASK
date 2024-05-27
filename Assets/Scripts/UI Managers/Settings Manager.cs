using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] SettingsSO SettingsSO;

    [SerializeField] GameObject _mainContainer;
    [SerializeField] TabManager _tabManager;

    void Start()
    {
        SettingsSO.EventOnShow += SettingsSO_EventOnShow;
        SettingsSO.EventOnHide += SettingsSO_EventOnHide;

        _tabManager.Reset();
        _mainContainer.SetActive(false);
    }
        
    //
    void SettingsSO_EventOnShow()
    {        
        _mainContainer.SetActive(true);
        _tabManager.Reset();
    }
    void SettingsSO_EventOnHide()
    {
        _mainContainer.SetActive(false);
    }
}
