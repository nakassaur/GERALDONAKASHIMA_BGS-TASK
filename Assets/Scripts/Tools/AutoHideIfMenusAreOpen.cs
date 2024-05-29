using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideIfMenusAreOpen : MonoBehaviour
{
    [SerializeField] List<GameObject> targets = new List<GameObject>();

    bool _lastCheck;
    public bool lastCheck
    { 
        get => _lastCheck; 
        set 
        {
            if (_lastCheck == value) return;

            _lastCheck = value;

            if (targets.Count == 0) return;

            foreach (GameObject go in targets)
                go.SetActive(value);
        }
    }
    void Start()
    {
        lastCheck = true;
    }

    void FixedUpdate()
    {
        lastCheck = !CheckForOpenMenus.singleton.IsOpen;
    }
}
