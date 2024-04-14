using System;
using UnityEngine;

public class IndicatorUI : MonoBehaviour
{
    [SerializeField, Tooltip("Empty game object that will be used as the indicator")] 
    private Transform indicatorTransform;
    private BaseSummonObject currentObject;
    
    private Color normalColor = new Color(1, 1, 1, 1);
    private Color normalOpaqueColor = new Color(1, 1, 1, 0.5f);
    private Color redOpaqueColor = new Color(1, 0.5f, 0.5f, 0.5f);


    private void OnEnable()
    {
        EventManager.onCardSelected.Subscribe(ReceiveCardSelected);
        EventManager.onCardDeselected.Subscribe(ReceiveCardDeselected);
        EventManager.onIndicatorObjectChangeTriggerCollision.Subscribe(SetIndicatorCollision);
    }

    private void OnDisable()
    {
        EventManager.onCardSelected.Unsubscribe(ReceiveCardSelected);
        EventManager.onCardDeselected.Unsubscribe(ReceiveCardDeselected);
        EventManager.onIndicatorObjectChangeTriggerCollision.Unsubscribe(SetIndicatorCollision);
    }
    
    private void ReceiveCardSelected(CardInfo cardInfo)
    {
        enabled = true;
    }
    private void ReceiveCardDeselected()
    {
        enabled = false;
    }

    public void SetIndicatorObject(BaseSummonObject prefab)
    {
        currentObject = GameObject.Instantiate(prefab, Input.mousePosition, RotationHelper.RotationToQuaternion(), indicatorTransform);
        
    }
    
    
    private void Update()
    {
        indicatorTransform.position = Input.mousePosition;
    }

    private void SetIndicatorCollision(bool isTriggerColliding)
    {
        currentObject.SetColor(isTriggerColliding ? redOpaqueColor : normalOpaqueColor);
    }
    
    
}