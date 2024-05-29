using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] ShopUISO ShopUISO;

    [SerializeField] GameObject _mainContainer;

    [SerializeField] TMP_Text _npcNameLabel;
    [SerializeField] TMP_Text _dialogText;
    [SerializeField] List<Button> _optionButtons;

    public bool isVisible => _mainContainer.activeSelf;

    void Start()
    {
        DialogUISO.EventOnShow += DialogUISO_EventOnShow;
        DialogUISO.EventOnHide += DialogUISO_EventOnHide;
        DialogUISO.EventOnLoadData += DialogUISO_EventOnLoadData;

        DialogUISO.EventOnSetNPCName += DialogUISO_EventOnSetNPCName;
    }

    void OnDestroy()
    {
        DialogUISO.EventOnShow -= DialogUISO_EventOnShow;
        DialogUISO.EventOnHide -= DialogUISO_EventOnHide;
        DialogUISO.EventOnLoadData -= DialogUISO_EventOnLoadData;

        DialogUISO.EventOnSetNPCName -= DialogUISO_EventOnSetNPCName;
    }

    // Private Methods
    private TMP_Text GetTextFromOption(Transform option)
    {
        return option.GetChild(0).GetComponent<TMP_Text>();
    }

    // Public Methods
    public void ExecuteDialogOption(int index)
    {
        DialogOption targetOption = DialogUISO.ActiveDialogData.Options[index];

        if (targetOption.DialogAction == DialogAction.Talk)
        {
            DialogUISO.ActiveDialogData = (DialogData)targetOption.ContextObj;
            DialogUISO.LoadData();
            return;
        }

        if (targetOption.DialogAction == DialogAction.Shop)
        {
            DialogUISO.Hide();
            ShopUISO.SetShopData((ShopData) targetOption.ContextObj);            
            ShopUISO.Show();
            return;
        }

        if (targetOption.DialogAction == DialogAction.Leave)
            DialogUISO.Hide();
    }

    // Event Signature
    void DialogUISO_EventOnShow() { _mainContainer.SetActive(true); }
    void DialogUISO_EventOnHide() { _mainContainer.SetActive(false); }

    void DialogUISO_EventOnLoadData()
    {
        if (DialogUISO.ActiveDialogData == null)
        {
            Debug.LogError("Dialog initiated with NULL DialogData");
            _mainContainer.SetActive(false);
            return;
        }

        _dialogText.text = DialogUISO.ActiveDialogData.DialogString;

        // Aliasing to shorten the ActiveDialogData path
        DialogData dData = DialogUISO.ActiveDialogData;

        // Options Processing
        foreach (Button btn in _optionButtons)
            btn.gameObject.SetActive(false);

        for (int i = 0; i < dData.Options.Count; i++)
        {
            _optionButtons[i].gameObject.SetActive(true);
            GetTextFromOption(_optionButtons[i].transform).text = dData.Options[i].OptionText;
        }
    }

    void DialogUISO_EventOnSetNPCName(string name)
    {
        _npcNameLabel.text = name;
    }
}
