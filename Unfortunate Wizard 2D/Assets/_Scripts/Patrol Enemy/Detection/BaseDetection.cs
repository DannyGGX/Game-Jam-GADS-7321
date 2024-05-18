using System;
using UnityEngine;

public class BaseDetection : MonoBehaviour
{
    private Action _detectionCallback;

    public void SetDetectionCallback(Action callback)
    {
        _detectionCallback = callback;
    }
    
    protected void InvokeDetectionCallback()
    {
        _detectionCallback?.Invoke();
    }

    protected static bool DetectionCheck(Collider2D other)
    {
        return other.CompareTag("Ground") || other.CompareTag("Object");
    }
}