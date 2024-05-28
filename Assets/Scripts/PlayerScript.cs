using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Scriptable Object References
    [SerializeField] Database DB;
    [SerializeField] PlayerHUDSO PlayerHUDSO;

    // Component References
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] Rigidbody2D _rb2d;

    // Variables
    InputAction _moveAction;
    InputAction _interactAction;
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
        _escapeAction = _playerInput.actions["Escape"];

        _interactAction.performed += InteractAction_performed;
        _escapeAction.performed += EscapeAction_performed;
    }
        
    void Update()
    {
        if (CheckForOpenMenus.singleton == null) return;
        if (CheckForOpenMenus.singleton.IsOpen == true) return;

        InteractionTarget = Physics2D.OverlapCircle(transform.position, DB.InteractionRadius, DB.InteractionMask);

        _move = _moveAction.ReadValue<Vector2>();
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

    void EscapeAction_performed(InputAction.CallbackContext obj)
    {
        
    }
}
