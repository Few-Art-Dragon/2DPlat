using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathFollower)), RequireComponent(typeof(MovementFollower))]
public class Follower : MonoBehaviour
{
    [SerializeField]
    private GameObject _moveTarget;
    [SerializeField]
    private Color _baseColor;
    [SerializeField]
    private Color _rollColor;

    private PathFollower _path;
    private Renderer _renderer;
    private MovementFollower _movement;

    private void OnEnable()
    {
        RollingAnimation.OnRollPlayerEvent += SetColorRender;
    }

    private void Awake()
    {
        _path = GetComponent<PathFollower>();
        _renderer = GetComponent<Renderer>();
        _movement = GetComponent<MovementFollower>();
    }

    private void Update()
    {
       _path.AddPointPool(_moveTarget.transform.position);
    }

    private void LateUpdate()
    {
        var targetPosition = _path.GetPathPool().Peek();

        if (transform.position.x == targetPosition.x)
        {
            _path.DeletePointPool();
        }
        else
        {
            _movement.MoveToTarget(targetPosition);
        }
    }

    private void OnDisable()
    {
        RollingAnimation.OnRollPlayerEvent -= SetColorRender;
    }

    public void SetColorRender(bool state)
    {
        _renderer.material.color = state ? _rollColor : _baseColor;
    }
}
