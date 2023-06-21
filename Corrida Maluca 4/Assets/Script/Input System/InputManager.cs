using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public delegate void PlayerAction();
    public PlayerAction OnJumpActive;

    [SerializeField] private GameControls _gameControls;

    
    private void Awake() {
        _gameControls = new GameControls();
        _gameControls.Player.Jump.performed += GetJumpInput;

    }
    

    private void OnEnable() {
        _gameControls.Enable();
    }

    private void OnDisable() {
        _gameControls.Disable();
    }

    public GameControls GameControls
    {
        get{return _gameControls; }
    }

    private void GetJumpInput(InputAction.CallbackContext ctx)
    {
        //Invocar o evento OnJumpActive
        if(ctx.performed){
            OnJumpActive?.Invoke();
        }
    }


    
}
