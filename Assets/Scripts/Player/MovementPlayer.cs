using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementPlayer : MonoBehaviour
{
    [SerializeField]
    private float _maxAngleForRolling;
    [SerializeField]
    private LayerMask _groundLayerMask;
    [SerializeField]
    private float _speedMove;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float value)
    {
        if (value != 0)
        {
            _rigidbody.MovePosition(new Vector2(transform.position.x, transform.position.y) + Vector2.right * value * Time.fixedDeltaTime * _speedMove);
        }
    }

    public bool CheckAngleGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 5f, _groundLayerMask);
        var angle = 180f - Vector2.Angle(Vector2.down ,hit.normal);

        if (angle > _maxAngleForRolling)
        {           
            return true;     
        }

        return false;
    }
}
