
using System;
using System.Collections;
using UnityEngine;

public class SummonObjectInput : MonoBehaviour
{
    
    private CardInfo currentCard;

    private void Awake()
    {
        enabled = false;
        EventManager.onCardSelected.Subscribe(SetCurrentCardInfo);
        EventManager.onCardDeselected.Subscribe(DeselectCard);
        EventManager.onIndicatorObjectChangeTriggerCollision.Subscribe(SetEnableSate);
    }

    private void OnDestroy()
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
            Debug.Log("On Spawn Object invoked");
            enabled = false;
        }
    }
    
    private void SetCurrentCardInfo(CardInfo cardInfo)
    {
        Debug.Log("Summon object input received card selected event");
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