using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.TMP_Dropdown;

public class SettingsManager : MonoBehaviour
{
    #region Singleton Setup
    public static SettingsManager singleton;
    void Awake()
    {
        singleton = this;
    }
    #endregion

    [SerializeField] SettingsSO SettingsSO;

    [SerializeField] GameObject _mainContainer;
    [SerializeField] TabManager _tabManager;

    [SerializeField] TMP_Dropdown _resolutionDropdown;
    [SerializeField] TMP_Dropdown _displayModeDropdown;
    [SerializeField] Toggle _vsyncToggle;

    List<Resolution> _resolutions = new List<Resolution>();

    CultureInfo _invariantCulture = CultureInfo.InvariantCulture;

    public bool isVisible => _mainContainer.activeSelf;

    void Start()
    {
        //
        Application.targetFrameRate = 300;

        //
        SettingsSO.EventOnShow += SettingsSO_EventOnShow;
        SettingsSO.EventOnHide += SettingsSO_EventOnHide;

        // Player Prefs Reading
        if (PlayerPrefs.HasKey(PrefsList._DISPLAYMODE) == false)
            PlayerPrefs.SetInt(PrefsList._DISPLAYMODE, 0);

        _displayModeDropdown.value = PlayerPrefs.GetInt(PrefsList._DISPLAYMODE);

        if (PlayerPrefs.HasKey(PrefsList._VSYNC) == false)
            PlayerPrefs.SetInt(PrefsList._VSYNC, 0);

        _vsyncToggle.isOn = PlayerPrefs.GetInt(PrefsList._VSYNC) == 1;

        //
        ResolutionProcessing();

        //
        _tabManager.Reset();
        _mainContainer.SetActive(false);
    }

    // Private Methods
    void ResolutionProcessing()
    {
        // RESOLUTION MANAGEMENT
        //
        _resolutions.Clear();

        // -- Get all the supported monitor's resolutions and store them
        _resolutions = Screen.resolutions.Reverse().ToList();

        //
        Resolution current = Screen.currentResolution;

        if (_resolutionDropdown == null) return;

        List<OptionData> options = new List<OptionData>();

        foreach (Resolution r in _resolutions)
            options.Add(new OptionData(ProperResolutionToString(r)));

        _resolutionDropdown.options = options;
        _resolutionDropdown.value = _resolutions.FindIndex(x => x.ToString() == current.ToString());
    }

    string ProperResolutionToString(Resolution r)
    {
        return r.width + "x" + r.height + " @ " + Mathf.RoundToInt((float)r.refreshRateRatio.value) + "Hz";
    }

    // Public Methods
    public void SetDisplayMode(int value)
    {
        PlayerPrefs.SetInt(PrefsList._DISPLAYMODE, value);
    }
    
    public void SetResolution()
    {
        int index = _resolutionDropdown.value;

        FullScreenMode fm = FullScreenMode.ExclusiveFullScreen;

        if (_displayModeDropdown.value == 1)
            fm = FullScreenMode.FullScreenWindow;
        else if (_displayModeDropdown.value == 2)
            fm = FullScreenMode.Windowed;

        Screen.SetResolution(_resolutions[index].width, _resolutions[index].height, fm, _resolutions[index].refreshRateRatio);

        //
        Application.targetFrameRate = 300;
    }

    public void SetVSync()
    {
        int result = 0;

        if (_vsyncToggle.isOn == true) result = 1;

        PlayerPrefs.SetInt(PrefsList._VSYNC, result);
        QualitySettings.vSyncCount = result;
    }

    // Events Signature
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
