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
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool IsIndicatorMode;

    private void SetColliderTriggerStatus(bool isTrigger)
    {
        foreach (var collider in colliders)
        {
            collider.isTrigger = isTrigger;
        }
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
    
    public void SetToIndicatorMode()
    {
        IsIndicatorMode = true;
        SetColliderTriggerStatus(true);
    }

    // only runs if colliders are in trigger state
    private void OnTriggerEnter2D(Collider2D other)
    {
        EventManager.onIndicatorObjectChangeTriggerCollision.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EventManager.onIndicatorObjectChangeTriggerCollision.Invoke(false);
    }
}