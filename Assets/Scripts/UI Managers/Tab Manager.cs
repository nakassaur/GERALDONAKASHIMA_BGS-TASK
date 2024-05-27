using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabManager : MonoBehaviour
{
    [SerializeField] List<TabButton> _tabButtons;
    [SerializeField] List<GameObject> _tabs;

    // Built-in Functions
    void Start()
    {
        SetIndex(0);
    }

    // Public Functions
    public void SetIndex(int index)
    {
        for (int i = 0; i < _tabButtons.Count; i++)
        {
            _tabButtons[i].Active = i == index;
            _tabs[i].SetActive(i == index);
        }
    }

    public void Reset()
    {
        SetIndex(0); 
    }    
}
