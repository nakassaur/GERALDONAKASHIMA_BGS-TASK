using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    #region Singleton Setup
    public static ShopUIManager singleton;
    void Awake()
    {
        singleton = this;    
    }
    #endregion

    [SerializeField] Database DB;
    [SerializeField] ShopUISO ShopUISO;

    [SerializeField] GameObject _mainContainer;
    [SerializeField] TMP_Text _shopName;
    [SerializeField] Image _shopSprite;

    [SerializeField] TMP_Text _descriptionText;
    [SerializeField] TMP_Text _priceText;
    
    [SerializeField] GameObject _modalContainer;
    [SerializeField] TMP_Text _modalItemTarget;

    [SerializeField] Transform _itemListRoot;

    public bool isVisible => _mainContainer.activeSelf;

    // Built-in Functions
    void Start()
    {
        ShopUISO.EventOnShow += ShopUISO_EventOnShow;
        ShopUISO.EventOnHide += ShopUISO_EventOnHide;

        ShopUISO.EventOnHighlightedItemUpdated += ShopUISO_EventOnHighlightedItemUpdated;
        ShopUISO.EventOnShowShopModal += ShopUISO_EventOnShowShopModal; 
    }

    void OnDestroy()
    {
        ShopUISO.EventOnShow -= ShopUISO_EventOnShow;
        ShopUISO.EventOnHide -= ShopUISO_EventOnHide;

        ShopUISO.EventOnHighlightedItemUpdated -= ShopUISO_EventOnHighlightedItemUpdated;
        ShopUISO.EventOnShowShopModal -= ShopUISO_EventOnShowShopModal;
    }

    // Private Methods
    void PopulateItemList()
    {
        if (_itemListRoot.childCount > 0)
        {
            for (int i = 0; i < _itemListRoot.childCount; i++)
                DestroyImmediate(_itemListRoot.GetChild(0).gameObject);            
        }

        // Aliasing for shortening the line size
        List<Item> activeList = ShopUISO.ActiveShopData.items;

        for (int i=0;i<activeList.Count;i++)
        {
            Transform instance = Instantiate(DB.itemOptionPrefab);
            ItemOption io = instance.GetComponent<ItemOption>();

            io.SetItem(activeList[i]);
            instance.SetParent(_itemListRoot);
            instance.localScale = Vector3.one;
        }        
    }

    // Event Signature
    void ShopUISO_EventOnShow()
    {
        _mainContainer.SetActive(true);

        _shopName.text = ShopUISO.ActiveShopData.shopName;
        _shopSprite.sprite = ShopUISO.ActiveShopData.shopSprite;

        PopulateItemList();
    }

    void ShopUISO_EventOnHide()
    {
        // Forced a Second Clean-up because of some leftover elements not beeing deleted
        if (_itemListRoot.childCount > 0)
        {
            for (int i = 0; i < _itemListRoot.childCount; i++)
                DestroyImmediate(_itemListRoot.GetChild(0).gameObject);            
        }

        _mainContainer.SetActive(false);
        _modalContainer.SetActive(false);
    }
    void ShopUISO_EventOnHighlightedItemUpdated(Item item)
    {
        if (item == null)
        { 
            _descriptionText.text = "---";
            _priceText.text = "---";
            return;
        }

        _descriptionText.text = item.Description;
        _priceText.text = item.Price.ToString() + "g";
    }
    void ShopUISO_EventOnShowShopModal(Item item)
    {
        _modalContainer.SetActive(true);
        _modalItemTarget.text = item.DisplayName.ToUpper() + "?";
        ShopUISO.ActiveItem = item;
    }

}
