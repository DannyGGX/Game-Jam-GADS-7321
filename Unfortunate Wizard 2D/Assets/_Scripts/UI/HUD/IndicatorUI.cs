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
        EventManager.onCardSelected.Subscribe(EnableIndicator);
        EventManager.onCardDeselected.Subscribe(DisableIndicator);
        EventManager.onIndicatorObjectChangeTriggerCollision.Subscribe(SetIndicatorCollision);
        EventManager.onIndicatorRotate.Subscribe(ChangeIndicatorRotation);
        EventManager.onSpawnObject.Subscribe(ReceiveObjectSpawned);
    }

    private void OnDisable()
    {
        EventManager.onCardSelected.Unsubscribe(EnableIndicator);
        EventManager.onCardDeselected.Unsubscribe(DisableIndicator);
        EventManager.onIndicatorObjectChangeTriggerCollision.Unsubscribe(SetIndicatorCollision);
        EventManager.onIndicatorRotate.Unsubscribe(ChangeIndicatorRotation);
        EventManager.onSpawnObject.Unsubscribe(ReceiveObjectSpawned);
    }
    
    private void EnableIndicator(CardInfo cardInfo)
    {
        enabled = true;
        indicatorTransform.gameObject.SetActive(true);
    }
    private void DisableIndicator()
    {
        enabled = false;
        indicatorTransform.gameObject.SetActive(false);
    }

    private void ReceiveObjectSpawned(CardInfo cardInfo)
    {
        DisableIndicator();
    }

    public void SetIndicatorObject(BaseSummonObject prefab)
    {
        currentObject = GameObject.Instantiate(prefab, Input.mousePosition, RotationHelper.RotationToQuaternion(), indicatorTransform);
        currentObject.SetToIndicatorMode();
    }
    
    
    private void Update()
    {
        indicatorTransform.position = Input.mousePosition;
    }

    private void SetIndicatorCollision(bool isTriggerColliding)
    {
        currentObject.SetColor(isTriggerColliding ? redOpaqueColor : normalOpaqueColor);
    }
    
    private void ChangeIndicatorRotation()
    {
        indicatorTransform.rotation = RotationHelper.RotationToQuaternion();
    }
    
    
}