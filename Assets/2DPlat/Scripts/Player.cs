using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private MovementPlayer _movementPlayer;
    private AnimationPlayer _animationPlayer;

    private void OnEnable()
    {
        _input = new PlayerInput();
        _input.Enable();
        _input.Game.Move.started += axis => _movementPlayer.StartMove(axis.ReadValue<float>());
        _input.Game.Move.canceled += _ => _movementPlayer.StopMove();
        _input.Game.Move.started += axis => _animationPlayer.CheckSide(axis.ReadValue<float>());

        MovementPlayer.OnEnableInputEvent += EnableInput;
        MovementPlayer.OnDisableInputEvent += DisableInput;
    }

    private void Awake()
    {
        _movementPlayer = GetComponent<MovementPlayer>();
        _animationPlayer = GetComponent<AnimationPlayer>();
    }

    private void OnDisable()
    {
        _input.Game.Move.started -= axis => _movementPlayer.StartMove(axis.ReadValue<float>());
        _input.Game.Move.canceled -= _ => _movementPlayer.StopMove();
        _input.Game.Move.started -= axis => _animationPlayer.CheckSide(axis.ReadValue<float>());

        MovementPlayer.OnEnableInputEvent -= EnableInput;
        MovementPlayer.OnDisableInputEvent -= DisableInput;
    }

    private void EnableInput()
    {
        _input.Enable();
    }

    private void DisableInput()
    {
        _input.Disable();
    }
}
