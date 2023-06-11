using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatonManager : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private InputManager _inputManager;

    private float inputY;
    private float inputX;

    private void UpdateInputValue()
    {
        inputY = _inputManager.GameControls.Player.Locomotion.ReadValue<Vector2>().y;
        inputX = _inputManager.GameControls.Player.Locomotion.ReadValue<Vector2>().x;
    }

    private void UpdateAnimations()
    {
        _animator.SetFloat("InputY", inputY);
        _animator.SetFloat("InputX", inputX);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputValue();
        UpdateAnimations();
    }
}
