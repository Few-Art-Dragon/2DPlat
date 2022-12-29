using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput)), RequireComponent(typeof(MovementPlayer)), RequireComponent(typeof(AnimationPlayer))]
public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private MovementPlayer _movement;
    private AnimationPlayer _animation;

    private void OnEnable()
    {
        RollingAnimation.OnRollPlayerEvent += SetEnableInput;
        StartGameAnimation.OnExitPortalEvent += SetEnableInput;
    }

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _movement = GetComponent<MovementPlayer>();
        _animation = GetComponent<AnimationPlayer>();
    }

    private void FixedUpdate()
    {
        if (_movement.CheckAngleGround() == true)
        {
            _animation.SetRollingAnimation(true);
        }
        else
        {
            _animation.SetRollingAnimation(false);
        }
  
        _movement.Move(_input.actions["Move"].ReadValue<float>());
    }

    private void OnDisable()
    {
        RollingAnimation.OnRollPlayerEvent -= SetEnableInput;
        StartGameAnimation.OnExitPortalEvent -= SetEnableInput;
    }

    private void SetEnableInput(bool state)
    {
        _input.enabled = state == true ? false: true;
    }
}
