using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private Vector3 _offset;
    private Vector2[] _targetPosition = new Vector2[5];
    private bool _isFullPoolPosition;
    
    private void Update()
    {
        AddPositionInPool();
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (_isFullPoolPosition)
        {
            for (int i = 0; i < _targetPosition.Length-1; i++)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(_targetPosition[i].x, _targetPosition[i].y + _offset.y) , _speedMove);
            }
            _isFullPoolPosition = false;
        }
    }

    private void AddPositionInPool()
    {
        if (!_isFullPoolPosition)
        {
            int index = 0;
            while (index < 5)
            {
                _targetPosition[index] = _target.transform.position;
                index++;
            }
            _isFullPoolPosition = true;
        }        
    }
}
