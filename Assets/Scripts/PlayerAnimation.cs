using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    [SerializeField] List<SpriteRenderer> _layers;

    [SerializeField] Item _equippedShoes;
    public Item equippedShoes
    {
        get => _equippedShoes;
        set
        {
            if (value == null)
                _layers[0].sprite = null;

            _equippedShoes = value;
        }
    }

    [SerializeField] Item _equippedLower;
    public Item equippedLower
    {
        get => _equippedLower;
        set
        {
            if (value == null)
                _layers[1].sprite = null;

            _equippedLower = value;
        }
    }

    [SerializeField] Item _equippedTop;
    public Item equippedTop
    {
        get => _equippedTop;
        set
        {
            if (value == null)
                _layers[2].sprite = null;

            _equippedTop = value;
        }
    }

    [SerializeField] Item _equippedHair;
    public Item equippedHair
    {
        get => _equippedHair;
        set
        {
            if (value == null)
                _layers[3].sprite = null;

            _equippedHair = value;
        }
    }

    [SerializeField] Item _equippedHat;
    public Item equippedHat
    {
        get => _equippedHat;
        set
        {
            if (value == null || value.Sprites.Count == 0)
                _layers[4].sprite = null;

            _equippedHat = value;
        }
    }

    // Built-in Functions
    private void OnValidate()
    {
        if (equippedShoes != null)
        {
            if (equippedHat.Sprites.Count == 0)
                _layers[0].sprite = null;
            else
                _layers[0].sprite = equippedShoes.Sprites[0];
        }
        else
            _layers[0].sprite = null;

        if (equippedLower != null)
        {
            if (equippedHat.Sprites.Count == 0)
                _layers[1].sprite = null;
            else
                _layers[1].sprite = equippedLower.Sprites[0];
        }
        else
            _layers[1].sprite = null;

        if (equippedTop != null)
        {
            if (equippedHat.Sprites.Count == 0)
                _layers[2].sprite = null;
            else
                _layers[2].sprite = equippedTop.Sprites[0];
        }
        else
            _layers[2].sprite = null;

        if (equippedHair != null)
        {
            if (equippedHat.Sprites.Count == 0)
                _layers[3].sprite = null;
            else
                _layers[3].sprite = equippedHair.Sprites[0];
        }
        else
            _layers[3].sprite = null;

        if (equippedHat != null)
        {
            if (equippedHat.Sprites.Count == 0)
                _layers[4].sprite = null;
            else
                _layers[4].sprite = equippedHat.Sprites[0];
        }
        else
            _layers[4].sprite = null;

    }

    void Update()
    {
        string target = _spriteRenderer.sprite.name;
        int lastIndex = target.LastIndexOf('_') + 1;
        int id = int.Parse(target.Substring(lastIndex, target.Length - lastIndex));
        bool flipped = _spriteRenderer.flipX;

        if (equippedShoes != null)
        {
            if (equippedShoes.Sprites.Count > 0)
            {
                _layers[0].sprite = equippedShoes.Sprites[id];
                _layers[0].flipX = flipped;
            }
        }

        if (equippedLower != null)
        {
            if (equippedLower.Sprites.Count > 0)
            {
                _layers[1].sprite = equippedLower.Sprites[id];
                _layers[1].flipX = flipped;
            }
        }

        if (equippedTop != null)
        {
            if (equippedTop.Sprites.Count > 0)
            {
                _layers[2].sprite = equippedTop.Sprites[id];
                _layers[2].flipX = flipped;
            }
        }

        if (equippedHair != null)
        {
            if (equippedHair.Sprites.Count > 0)
            {
                _layers[3].sprite = equippedHair.Sprites[id];
                _layers[3].flipX = flipped;
            }            
        }

        if (equippedHat != null)
        {
            if (equippedHat.Sprites.Count > 0)
            {
                _layers[4].sprite = equippedHat.Sprites[id];
                _layers[4].flipX = flipped;
            }
        }
    }

    // Public Functions
    public bool CheckIfItemIsEquipped(Item item)
    {
        if (equippedHat == item)
            return true;

        if (equippedHair == item)
            return true;

        if (equippedTop == item)
            return true;

        if (equippedLower == item)
            return true;

        if (equippedShoes == item)
            return true;

        return false;
    }

    public void EquipItem(Item item)
    {
        bool isCosmetic =   item.Category == ItemCategory.Shoe || item.Category == ItemCategory.Lower ||
                            item.Category == ItemCategory.Top || item.Category == ItemCategory.Hairstyle ||
                            item.Category == ItemCategory.Hat;

        if (isCosmetic == false) return;

        if (item.Category == ItemCategory.Hat)
        {            
            equippedHat = item;
            return;
        }

        if (item.Category == ItemCategory.Hairstyle)
        {
            equippedHair = item;
            return;
        }

        if (item.Category == ItemCategory.Top)
        {
            equippedTop = item;
            return;
        }

        if (item.Category == ItemCategory.Lower)
        {
            equippedLower = item;
            return;
        }
        
        // Last check can be Supressed. It can't be anything but a Shoe if it reaches this point.
        equippedShoes = item;            
        
    }
}
