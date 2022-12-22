using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private SkeletonAnimation _skeletonAnimation;

    private void OnEnable()
    {
        MovementPlayer.OnStartMoveEvent += SetWalkAnimation;
        MovementPlayer.OnStopMoveEvent += SetIdleAnimation;
        MovementPlayer.OnStartRollEvent += SetHoverBoardAnimation;
        MovementPlayer.OnStopRollEvent += SetIdleAnimation;
    }

    private void OnDisable()
    {
        MovementPlayer.OnStartMoveEvent -= SetWalkAnimation;
        MovementPlayer.OnStopMoveEvent -= SetIdleAnimation;
        MovementPlayer.OnStartRollEvent -= SetHoverBoardAnimation;
        MovementPlayer.OnStopRollEvent -= SetIdleAnimation;
    }

    private void SetWalkAnimation()
    {
        _skeletonAnimation.AnimationName = "run"; 
    }

    private void SetIdleAnimation()
    {
        _skeletonAnimation.AnimationName = "idle";
    }

    private void SetHoverBoardAnimation()
    {
        _skeletonAnimation.AnimationName = "hoverboard";
    }

    public void CheckSide(float x)
    {
        _skeletonAnimation.Skeleton.ScaleX = x;
    }
}
