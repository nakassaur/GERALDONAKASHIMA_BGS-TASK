using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] ShopUISO ShopUISO;

    [SerializeField] Color _normalColor;
    [SerializeField] Color _highlightColor;

    [SerializeField] Image _background;
    [SerializeField] Image _icon;
    [SerializeField] TMP_Text _text;

    [SerializeField] GameObject _soldOutContainer;
    
    bool isCosmetic(Item item) => item.Category != ItemCategory.Outfit && item.Category != ItemCategory.Hat;

    public Item _item { get; private set; }
        
    public void SetItem(Item item)
    {
        _item = item;

        _icon.sprite = _item.MenuSprite;
        _text.text = _item.DisplayName;

        if (isCosmetic(item) == true)
        {
            _soldOutContainer.SetActive(false);
            return;
        }

        bool logic = PlayerInventory.singleton.CheckIfIHaveThis(item);
        _soldOutContainer.SetActive(logic);

    }

    // Interfaces
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShopUISO.SetHighlightedItem(_item);

        LeanTween.color(_background.rectTransform, _highlightColor, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShopUISO.SetHighlightedItem(null);
                
        LeanTween.color(_background.rectTransform, _normalColor, 0.1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_soldOutContainer.activeSelf == true) return;

        ShopUISO.ShowShopModal(_item);
    }
    
}
