using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;

    [SerializeField] private CharacterController _characterController;

    [SerializeField] private InputManager _inputManager;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravity;

    private void Update()
    {
        Walk();
        Jump();
    }

    private void Walk()
    {
        Vector2 walkDirection = _inputManager.GameControls.Player.Locomotion.ReadValue<Vector2>();

        Vector3 newDirection = new Vector3(walkDirection.x, 0, walkDirection.y);

        _characterController.Move(newDirection *(_walkSpeed * Time.deltaTime));
    }

    private void Jump()
    {
        if(_characterController.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _jumpVelocity = _jumpHeight;
            }
        }
        else
        {
            _jumpVelocity -= _gravity;
        }
    }
}
