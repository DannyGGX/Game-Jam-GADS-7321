
using System;
using System.Collections;
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
        StartCoroutine(WaitForMouseUp());
    }
    
    IEnumerator WaitForMouseUp()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
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