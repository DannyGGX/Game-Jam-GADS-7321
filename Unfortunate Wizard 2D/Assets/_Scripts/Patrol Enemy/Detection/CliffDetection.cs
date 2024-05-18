using UnityEngine;

public class CliffDetection : BaseDetection
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (DetectionCheck(other))
        {
            InvokeDetectionCallback();
        }
    }
}