using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MovementFollower : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;

    public void MoveToTarget(Vector3 position)
    {
        transform.position = Vector2.MoveTowards(transform.position, position, _speedMove * Time.deltaTime);
    } 
}
