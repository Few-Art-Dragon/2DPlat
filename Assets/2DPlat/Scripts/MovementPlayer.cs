using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public delegate void StartMoveHandler();
    public static event StartMoveHandler OnStartMoveEvent;

    public delegate void StopMoveHandler();
    public static event StopMoveHandler OnStopMoveEvent;

    public delegate void StartRollHandler();
    public static event StartRollHandler OnStartRollEvent;

    public delegate void StopRollHandler();
    public static event StopRollHandler OnStopRollEvent;

    public delegate void DisableInputHandler();
    public static event DisableInputHandler OnDisableInputEvent;

    public delegate void EnableInputHandler();
    public static event EnableInputHandler OnEnableInputEvent;

    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private float _speedMove;
    private bool _isRolling;
    private bool _isMoving;
    private float angle;

    private void Update()
    {
        CheckAngleGround();
    }

    public void StartMove(float x)
    {
        _isMoving = true;
        StartCoroutine("IMove", x);
    }

    public void StopMove()
    {
        _isMoving = false;
        OnStopMoveEvent?.Invoke();
        StopCoroutine("IMove");
    }

    private void Move(float x)
    {        
        transform.position += new Vector3(x * _speedMove * Time.deltaTime, 0,0);
    }

    private void CheckAngleGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 5f, _layerMask);
        angle = 180f -  Vector2.Angle(Vector2.down ,hit.normal);
        
        if (angle > 25f)
        {
            _isRolling = true;
            OnStartRollEvent?.Invoke();
            OnDisableInputEvent?.Invoke();
        }
        else if(angle <1 & !_isMoving)
        {
            _isRolling = false;
            OnEnableInputEvent?.Invoke();
            OnStopRollEvent?.Invoke();
        }
    }

    IEnumerator IMove(float x)
    {
        while (true)
        {
            if (!_isRolling)
            {
                OnStartMoveEvent?.Invoke();
                Move(x);
            }
            yield return null;
        }
    }
}
