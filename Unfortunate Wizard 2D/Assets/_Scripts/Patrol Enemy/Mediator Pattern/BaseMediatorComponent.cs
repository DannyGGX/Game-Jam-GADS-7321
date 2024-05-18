using UnityEngine;

/// <summary>
/// A component of a mediator
/// </summary>
public class BaseMediatorComponent : MonoBehaviour
{
    protected IMediator Mediator;
    
    /// <summary>
    /// Called by the mediator to register itself
    /// </summary>
    /// <param name="mediator"></param>
    public void RegisterMediator(IMediator mediator)
    {
        Mediator = mediator;
    }
}