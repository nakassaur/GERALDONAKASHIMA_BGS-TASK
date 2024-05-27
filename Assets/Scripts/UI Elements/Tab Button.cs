using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class TabButton : MonoBehaviour, IPointerDownHandler
{
    // Hard References
    [SerializeField] Animator _animator;

    readonly string _NORMAL = "Normal";
    readonly string _ACTIVE = "Active";
    readonly string _DISABLED = "Disabled";

    // Properties
    [SerializeField] private bool _active;
    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            SetGraphics();
        }
    }

    [SerializeField] private bool _disabled;
    public bool Disabled
    {
        get => _disabled;
        set
        {
            _disabled = value;
            SetGraphics();
        }
    }

    // Unity Events
    [SerializeField] UnityEvent OnClick;

    // Built-in Functions
    void Start()
    {
        SetGraphics();
    }

    void OnValidate()
    {
        SetGraphics();
    }

    // Private Functions
    void ResetTriggers()
    {
        _animator.ResetTrigger(_NORMAL);
        _animator.ResetTrigger(_ACTIVE);
        _animator.ResetTrigger(_DISABLED);
    }
    void SetGraphics()
    {
        if (Disabled == true)
        {
            ResetTriggers();
            _animator.SetTrigger(_DISABLED);
            return;
        }

        if (Active == true)
        {
            ResetTriggers();
            _animator.SetTrigger(_ACTIVE);
            return;
        }

        ResetTriggers();
        _animator.SetTrigger(_NORMAL);
    }

    // Interfaces
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Disabled == true) return;
        if (Active == true) return;

        ResetTriggers();
        _animator.SetTrigger(_ACTIVE);
                
        this.OnClick?.Invoke();
    }

}
