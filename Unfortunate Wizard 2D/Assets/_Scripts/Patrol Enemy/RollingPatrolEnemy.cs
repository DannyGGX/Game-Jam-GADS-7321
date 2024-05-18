using System;
using UnityEngine;

public class RollingPatrolEnemy : MonoBehaviour, IMediator
{
    [SerializeField] private RollingMovement rollingMovement;
    [SerializeField] private DirectionController directionController;
    
    
    private void Awake()
    {
        IMediator mediator = this;
        mediator.Register(rollingMovement);
        mediator.Register(directionController);
    }

    public void Notify(object sender, object data)
    {
        if (data is Messages message)
        {
            switch (message)
            {
                case Messages.ChangeDirection:
                    rollingMovement.SwitchDirection();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(message), message, null);
            }
        }
    }

    public enum Messages
    {
        ChangeDirection,
        PlayerDetected
    }
}