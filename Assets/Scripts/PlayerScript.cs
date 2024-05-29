using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Scriptable Object References
    [SerializeField] Database DB;
    [SerializeField] PlayerHUDSO PlayerHUDSO;
    [SerializeField] InGameMenuSO InGameMenuSO;
    [SerializeField] WardrobeUISO WardrobeUISO;

    // Component References
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] Rigidbody2D _rb2d;
    [SerializeField] Animator _animator;

    readonly int _X = Animator.StringToHash("x");
    readonly int _Y = Animator.StringToHash("y");

    // Variables
    InputAction _moveAction;
    InputAction _interactAction;
    InputAction _wardrobeAction;
    InputAction _escapeAction;

    [SerializeField] Vector2 _move;

    // Properties
    Collider2D _interactionTarget;
    Collider2D InteractionTarget
    {
        get => _interactionTarget;
        set
        {
            //Collider2D cache = _interactionTarget;

            if (value == _interactionTarget) return;

            _interactionTarget = value;
            PlayerHUDSO.SetInteractionPromptVisibility(value != null);
        }
    }

    // Built-In Functions
    void Start()
    {
        _moveAction = _playerInput.actions["Move"];
        _interactAction = _playerInput.actions["Interact"];
        _wardrobeAction = _playerInput.actions["Wardrobe"];
        _escapeAction = _playerInput.actions["Escape"];

        _interactAction.performed += InteractAction_performed;
        _wardrobeAction.performed += WardrobeAction_performed;
        _escapeAction.performed += EscapeAction_performed;

        //
        WorldManager.singleton.player = this;
    }
        
    void Update()
    {
        if (CheckForOpenMenus.singleton == null) return;
        if (CheckForOpenMenus.singleton.IsOpen == true)
        {
            _animator.SetFloat(_X, 0);
            _animator.SetFloat(_Y, 0);
            _rb2d.velocity = Vector2.zero;
            return;
        }
        

        InteractionTarget = Physics2D.OverlapCircle(transform.position, DB.InteractionRadius, DB.InteractionMask);

        _move = _moveAction.ReadValue<Vector2>();

        _animator.SetFloat(_X, _move.x);
        _animator.SetFloat(_Y, _move.y);

        _rb2d.velocity = _move * DB.PlayerBaseSpeed;
    }

    // Event Signature
    void InteractAction_performed(InputAction.CallbackContext obj)
    {
        if (CheckForOpenMenus.singleton == null) return;
        if (CheckForOpenMenus.singleton.IsOpen == true) return;

        if (InteractionTarget == null) return;

        InteractionTarget.GetComponent<IInteractable>().Interact();
    }

    void WardrobeAction_performed(InputAction.CallbackContext obj)
    {
        if (CheckForOpenMenus.singleton == null) return;
        if (CheckForOpenMenus.singleton.IsOpen == true) return;

        WardrobeUISO.Show();
    }

    void EscapeAction_performed(InputAction.CallbackContext obj)
    {


        _move = Vector2.zero;
    }
}
