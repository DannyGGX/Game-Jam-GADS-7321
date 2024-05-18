
public interface IMediator
{
    /// <summary>
    /// Used by mediator components to notify mediator of events.
    /// The mediator may react to the event and pass execution on to other mediator components
    /// </summary>
    /// <param name="sender">Mediator component</param>
    /// <param name="data">Data sent by sender </param>
    void Notify(object sender, object data);

    void Register(BaseMediatorComponent component)
    {
        component.RegisterMediator(this);
    }
}