
using System;
using UnityEngine;

public class SummonObjectInput : MonoBehaviour
{
    
    private CardInfo currentCard;
    private void OnEnable()
    {
        EventManager.onCardSelected.Subscribe(SetCurrentCardInfo);
        EventManager.onCardDeselected.Subscribe(DeselectCard);
        EventManager.onIndicatorObjectChangeTriggerCollision.Subscribe(SetEnableSate);
    }

    private void OnDisable()
    {
        EventManager.onCardSelected.Unsubscribe(SetCurrentCardInfo);
        EventManager.onCardDeselected.Unsubscribe(DeselectCard);
        EventManager.onIndicatorObjectChangeTriggerCollision.Unsubscribe(SetEnableSate);
    }
    
    private void Update()
    {
        // check for mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            EventManager.onSpawnObject.Invoke(currentCard);
        }
    }
    
    private void SetCurrentCardInfo(CardInfo cardInfo)
    {
        currentCard = cardInfo;
        enabled = true;
    }

    private void DeselectCard()
    {
        enabled = false;
    }
    
    private void SetEnableSate(bool isEnabled)
    {
        enabled = isEnabled;
    }
}