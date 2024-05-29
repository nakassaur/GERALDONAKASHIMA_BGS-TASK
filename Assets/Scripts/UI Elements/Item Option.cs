using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ItemOptionType
{ 
    Shop,
    Wardrobe
}

public class ItemOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] ShopUISO ShopUISO;
    [SerializeField] WardrobeUISO WardrobeUISO;

    [SerializeField] ItemOptionType _type;

    [SerializeField] Color _normalColor;
    [SerializeField] Color _highlightColor;

    [SerializeField] Image _background;
    [SerializeField] Image _icon;
    [SerializeField] TMP_Text _text;

    [SerializeField] GameObject _soldOutContainer;
    [SerializeField] GameObject _equippedIndicator;
    
    bool isCosmetic(Item item) => item.Category == ItemCategory.Shoe || item.Category == ItemCategory.Lower ||
                                  item.Category == ItemCategory.Top || item.Category == ItemCategory.Hairstyle || 
                                  item.Category == ItemCategory.Hat;

    public Item _item { get; private set; }

    public void SetType(ItemOptionType type)
    {
        _type = type;
    }

    public void SetItem(Item item)
    {
        _item = item;

        _icon.sprite = _item.MenuSprite;
        _text.text = _item.DisplayName;
                
        if (_type == ItemOptionType.Wardrobe)
        {
            _soldOutContainer.SetActive(false);

            bool equipped = WorldManager.singleton.player.transform.GetComponent<PlayerAnimation>().CheckIfItemIsEquipped(item);
            _equippedIndicator.SetActive(equipped);
            return;
        }

        bool logic = PlayerInventory.singleton.CheckIfIHaveThis(item);
        _soldOutContainer.SetActive(logic);

        _equippedIndicator.SetActive(false);

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
        // Shop Behaviour
        if (_type == ItemOptionType.Shop)
        {
            if (_soldOutContainer.activeSelf == true) return;

            ShopUISO.ShowShopModal(_item);
            return;
        }

        // Wardrobe Behaviour        
        WorldManager.singleton.player.transform.GetComponent<PlayerAnimation>().EquipItem(_item);
        WardrobeUISO.ForceListRefresh();
        
    }
    
}
