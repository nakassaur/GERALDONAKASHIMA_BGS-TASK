using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] Rigidbody2D _rb2d;

    InputAction _moveAction;
    [SerializeField] Vector2 _move;

    // Start is called before the first frame update
    void Start()
    {
        _moveAction = _playerInput.actions["Move"];        
    }

    // Update is called once per frame
    void Update()
    {
        _move = _moveAction.ReadValue<Vector2>();
        _rb2d.velocity = _move * 5;
    }
}
