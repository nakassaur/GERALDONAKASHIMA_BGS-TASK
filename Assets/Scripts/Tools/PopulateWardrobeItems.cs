using System.Collections.Generic;
using UnityEngine;

public class PopulateWardrobeItems : MonoBehaviour
{
    [SerializeField] Database DB;
    [SerializeField] WardrobeUISO WardrobeUISO;

    [SerializeField] ItemCategory _category;

    void Start()
    {
        WardrobeUISO.EventOnForceListRefresh += WardrobeUISO_EventOnForceListRefresh;
    }

    private void OnEnable()
    {
        PopulateList();
    }

    private void OnDisable()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
                DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    // Private Methods
    void PopulateList()
    {
        // Destroy children in root        
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
                DestroyImmediate(transform.GetChild(0).gameObject);
        }

        // Aliasing for shorter lines of code
        PlayerInventory pi = PlayerInventory.singleton;

        if (pi == null) return;

        List<Item> result = new List<Item>();
        result = pi.apparel.FindAll(x => x.Category == _category);
                
        if (_category == ItemCategory.Hat)
        {
            Transform elementZero = Instantiate(DB.itemOptionPrefab);

            ItemOption io = elementZero.GetComponent<ItemOption>();
            
            io.SetType(ItemOptionType.Wardrobe);
            io.SetItem(DB.NoHatOption);
            elementZero.SetParent(this.transform);
            elementZero.localScale = Vector3.one;

        }

        foreach (Item item in result)
        {
            Transform instance = Instantiate(DB.itemOptionPrefab);

            ItemOption io = instance.GetComponent<ItemOption>();

            io.SetType(ItemOptionType.Wardrobe);
            io.SetItem(item);
            instance.SetParent(this.transform);
            instance.localScale = Vector3.one;
        }
    }

    // Event Signature
    void WardrobeUISO_EventOnForceListRefresh()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
                DestroyImmediate(transform.GetChild(0).gameObject);
        }

        PopulateList();
    }
}
