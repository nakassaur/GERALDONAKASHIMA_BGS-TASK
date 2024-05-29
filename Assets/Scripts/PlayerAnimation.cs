using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    [SerializeField] List<SpriteRenderer> _layers;

    [SerializeField] Item _equippedShoes;
    Item equippedShoes
    {
        get => _equippedShoes;
        set
        {
            if (value == null)
                _layers[0].sprite = null;
        }
    }

    [SerializeField] Item _equippedPants;
    Item equippedPants
    {
        get => _equippedPants;
        set
        {
            if (value == null)
                _layers[1].sprite = null;
        }
    }

    [SerializeField] Item _equippedShirt;
    Item equippedShirt
    {
        get => _equippedShirt;
        set
        {
            if (value == null)
                _layers[2].sprite = null;
        }
    }

    [SerializeField] Item _equippedHair;
    Item equippedHair
    {
        get => _equippedHair;
        set
        {
            if (value == null)
                _layers[3].sprite = null;
        }
    }

    [SerializeField] Item _equippedHat;
    Item equippedHat
    {
        get => _equippedHat;
        set
        {
            if (value == null)
                _layers[4].sprite = null;
        }
    }

    private void OnValidate()
    {
        if (equippedShoes != null)
            _layers[0].sprite = equippedShoes.Sprites[0];
        else
            _layers[0].sprite = null;

        if (equippedPants != null)
            _layers[1].sprite = equippedPants.Sprites[0];
        else
            _layers[1].sprite = null;

        if (equippedShirt != null)
            _layers[2].sprite = equippedShirt.Sprites[0];
        else
            _layers[2].sprite = null;

        if (equippedHair != null)
            _layers[3].sprite = equippedHair.Sprites[0];
        else
            _layers[3].sprite = null;

        if (equippedHat != null)
            _layers[4].sprite = equippedHat.Sprites[0];
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
            _layers[0].sprite = equippedShoes.Sprites[id];
            _layers[0].flipX = flipped;
        }

        if (equippedPants != null)
        {
            _layers[1].sprite = equippedPants.Sprites[id];
            _layers[1].flipX = flipped;
        }

        if (equippedShirt != null)
        {
            _layers[2].sprite = equippedShirt.Sprites[id];
            _layers[2].flipX = flipped;
        }

        if (equippedHair != null)
        {
            _layers[3].sprite = equippedHair.Sprites[id];
            _layers[3].flipX = flipped;
        }

        if (equippedHat != null)
        {
            _layers[4].sprite = equippedHat.Sprites[id];
            _layers[4].flipX = flipped;
        }
    }
}
