using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;

    [SerializeField] private int _speed;

    [SerializeField] private CharacterController _characterController;

    [SerializeField] private InputManager _inputManager;
    
    [SerializeField] private float _gravityScale = -9.81f;

    [SerializeField] private float _gravityMultiplier= 1f; 
    [SerializeField] private float _jumpForce;
    
    [SerializeField] private float _rayRadius;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private LayerMask _layercoin;
    [SerializeField] private Animator _animation;

    private float _velocityY;
    private Vector3 newDirection;
    public bool _isDead;
    private GameController _gc;
    
    

    private void Update()
    {
        Vector3 direction = Vector3.forward * _speed;

        _characterController.Move(direction * Time.deltaTime);

        Walk();
        ApplyGravity();
        OnCollision();
        
    }
    private void Start() 
    {
        _inputManager.GameControls.Player.Jump.performed += Jump;
        _isDead = false;
    }

    private void Walk()
    {
        Vector2 walkDirection = _inputManager.GameControls.Player.Locomotion.ReadValue<Vector2>();

        newDirection = new Vector3(walkDirection.x, 0, walkDirection.y);

        newDirection.y = _velocityY;

        _characterController.Move(newDirection *(_walkSpeed * Time.deltaTime));
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded && _velocityY < 0f)
        {
            _velocityY = 0f;
        }
        else
        {
            _velocityY += _gravityScale * _gravityMultiplier * Time.deltaTime; 
        }
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        if(_characterController.isGrounded)
        {
            _velocityY += _jumpForce;
        }
    }

    //metodo para verificar se o player colidio com algo
    private void OnCollision()
    {
        RaycastHit hit;
        //if passando como parametro como uma posição de origem e destido(e no destino ele passa o numero 1) e no final ele passa o tamanho
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _rayRadius, _layer) && !_isDead)
        {
             //Game over
            _animation.SetTrigger("Die");
            _walkSpeed = 0;
            _speed = 0;
            _jumpForce = 0;
            _isDead = true;
            Debug.Log("Morreu ! :))");


        }

        RaycastHit hitcoin;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(0,1,0)), out hitcoin, _rayRadius, _layercoin))
        {
             //moeda
             _gc.AddCoin();
            Destroy(hitcoin.transform.gameObject); 
        }
    }
    
}
