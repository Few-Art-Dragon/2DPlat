using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(SkeletonMecanim))]
public class AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private SkeletonMecanim _skeletonMecanim;

    private Animator _animator;

    private void Awake()
    {
        _skeletonMecanim = GetComponent<SkeletonMecanim>();
        _animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        CheckMoveSide(value.Get<float>());
        SetMoveAnimation(value.Get<float>());
    }

    private void SetMoveAnimation(float value)
    {
        _animator.SetFloat("Horizontal", value);
    }

    public void SetRollingAnimation(bool state)
    {
        _animator.SetBool("Rolling",state);
    }

    public void CheckMoveSide(float x)
    {
        var value = transform.localScale.x;
        value = x == 0 ? transform.localScale.x : x;
        transform.localScale = new Vector3(value, 1f, 1f);
    }
}
