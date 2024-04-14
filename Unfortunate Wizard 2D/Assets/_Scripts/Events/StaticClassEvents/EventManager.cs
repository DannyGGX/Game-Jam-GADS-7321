using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for storing events in one place.
/// This event system is less resource intensive than a scriptable object event system that uses UnityEvents.
/// Con: not as good for team collaboration, because of potential conflicts from working in this class.
/// </summary>
public static class EventManager
{
    public static Event<CardInfo> onCardSelected = new Event<CardInfo>();
    public static Event onCardDeselected = new Event();
    
    public static Event onHandEmpty = new Event();
    public static Event<CardInfo[]> onDrawCards = new Event<CardInfo[]>();
    
    public static Event onIndicatorRotate = new Event();
    public static Event<CardInfo> onSpawnObject = new Event<CardInfo>();
    
    public static Event onFinishLevel = new Event();
    public static Event onKillPlayer = new Event();
    public static Event onRestartLevel = new Event();
    
    public static Event<bool> onIndicatorObjectChangeTriggerCollision = new Event<bool>(); // bool isTriggerColliding
    
}
