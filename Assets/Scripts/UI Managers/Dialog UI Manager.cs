using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUIManager : MonoBehaviour
{
    #region Singleton Setup
    public static DialogUIManager singleton;
    void Awake()
    {
        singleton = this;
    }
    #endregion

    [SerializeField] DialogUISO DialogUISO;

    [SerializeField] GameObject _mainContainer;

    public bool isVisible => _mainContainer.activeSelf;

    void Start()
    {
        DialogUISO.EventOnShow += DialogUISO_EventOnShow;
        DialogUISO.EventOnHide += DialogUISO_EventOnHide;
    }
   
    void OnDestroy()
    {
        DialogUISO.EventOnShow -= DialogUISO_EventOnShow;
        DialogUISO.EventOnHide -= DialogUISO_EventOnHide;
    }
    // Event Signature
    void DialogUISO_EventOnShow()
    {
        _mainContainer.SetActive(true);
    }
    void DialogUISO_EventOnHide()
    {
        _mainContainer.SetActive(false);
    }
}
