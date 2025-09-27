using UnityEngine;
using UnityEngine.Events;

public class OnTriggerManager2D : MonoBehaviour
{
    [Header("Trigger Settings")]
    [SerializeField] private string requiredTag = "";          // Optional tag filter
    [SerializeField] private LayerMask requiredLayers;         // Layer filter

    [Header("Events")]
    [SerializeField] private UnityEvent<GameObject> onTriggerEnter; // Passes the other object

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Tag filter (skip if not matching, unless empty)
        if (!string.IsNullOrEmpty(requiredTag) && !other.CompareTag(requiredTag))
            return;

        // Only filter if the mask is not empty
        if (requiredLayers.value != 0 && (requiredLayers.value & (1 << other.gameObject.layer)) == 0)
            return;


        // Invoke event, passing the other object
        onTriggerEnter?.Invoke(other.gameObject);
    }
}
