using UnityEngine;

public class WallDetection : BaseDetection
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DetectionCheck(other))
        {
            InvokeDetectionCallback();
        }
    }
}