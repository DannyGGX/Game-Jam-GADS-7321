using UnityEngine;

public class ImpactActivation : ObjectBehaviour
{
    [SerializeField, Tooltip("Has to be nested in the GameObject with this script.")] 
    private GameObject objectToActivate;

    private void OnEnable()
    {
        objectToActivate.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        objectToActivate.SetActive(true);
        enabled = false;
    }
}