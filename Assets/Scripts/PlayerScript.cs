using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Database db;
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] Rigidbody2D _rb2d;

    InputAction _moveAction;
    InputAction _interactAction;
    InputAction _escapeAction;

    [SerializeField] Vector2 _move;

    Collider2D _interactionTarget;

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
        //if (CheckForOpenMenus.singleton == null) return;
        //if (CheckForOpenMenus.singleton.IsOpen == true) return;

        _interactionTarget = Physics2D.OverlapCircle(transform.position, db.InteractionRadius, db.InteractionMask);

        _move = _moveAction.ReadValue<Vector2>();
        _rb2d.velocity = _move * db.PlayerBaseSpeed;
    }

    // Event Signature
    void InteractAction_performed(InputAction.CallbackContext obj)
    {
        
    }

    void EscapeAction_performed(InputAction.CallbackContext obj)
    {
        
    }
}
