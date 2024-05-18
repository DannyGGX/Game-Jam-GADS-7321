using System;
using UnityEngine;
using UnityUtils;

public class DirectionController : BaseMediatorComponent
{
    [SerializeField] private BaseDetection[] detectionObjects = new BaseDetection[2];

    private void Awake()
    {
        SetDetectionCallbacks();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0); // to stop detection objects from rotating with the rest of the enemy
    }

    private void ChangeDirection()
    {
        ReflectInXDirection();
        Mediator.Notify(this, RollingPatrolEnemy.Messages.ChangeDirection);
    }

    private void ReflectInXDirection()
    {
        var localScale = transform.localScale;
        localScale = localScale.With(x: localScale.x * -1);
        transform.localScale = localScale;
    }
    
    private void SetDetectionCallbacks()
    {
        foreach (var detectionObject in detectionObjects)
        {
            detectionObject.SetDetectionCallback(ChangeDirection);
        }
    }
}