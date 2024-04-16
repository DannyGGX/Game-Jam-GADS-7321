using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BaseSummonObject : MonoBehaviour
{
    [SerializeField, Tooltip("The object can have multiple colliders")] private Collider2D[] colliders;
    private SpriteRenderer spriteRenderer;

    private void SetColliderTriggerStatus(bool isTrigger)
    {
        foreach (var collider in colliders)
        {
            collider.isTrigger = isTrigger;
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
    
    public void SetToIndicatorMode()
    {
        SetColliderTriggerStatus(true);
    }

    // only runs if colliders are in trigger state
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.onIndicatorObjectChangeTriggerCollision.Invoke(true);
        Debug.Log("on Indicator Object Change Trigger Collision invoked with true");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.onIndicatorObjectChangeTriggerCollision.Invoke(false);
        Debug.Log("on Indicator Object Change Trigger Collision invoked with false");
    }
}