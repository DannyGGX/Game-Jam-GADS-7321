using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMovement : BaseMediatorComponent
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _rollSpeed = 5f;
    private const float DownwardForce = -2f;
    
    private Directions currentDirection;

    private void Awake()
    {
        PickRandomDirection();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_rollSpeed, DownwardForce);
    }

    

    private void PickRandomDirection()
    {
        currentDirection = (Directions) UnityEngine.Random.Range(0, 2);
    }

    public void SwitchDirection()
    {
        currentDirection = currentDirection == Directions.Left ? Directions.Right : Directions.Left;
        _rollSpeed *= -1;
    }

    public enum Directions
    {
        Left = 0,
        Right = 1,
    }
}


