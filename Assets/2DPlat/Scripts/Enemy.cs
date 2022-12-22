using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Color _baseColor;
    [SerializeField]
    private Color _rollColor;
    private Renderer _renderer;

    private void OnEnable()
    {
        MovementPlayer.OnStartRollEvent += ChangeColor;
        MovementPlayer.OnStopRollEvent += ResetColor;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnDisable()
    {
        MovementPlayer.OnStartRollEvent -= ChangeColor;
        MovementPlayer.OnStopRollEvent -= ResetColor;
    } 

    private void ResetColor()
    {
        _renderer.material.color =  _baseColor;
    }

    private void ChangeColor()
    {
        _renderer.material.color = _rollColor;
    }
}
