using UnityEngine;
using UnityEngine.InputSystem; // needed for Mouse.current

public class LookAtMouse2D : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current == null) return; // no mouse detected

        // Get mouse position in screen space
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        // Convert to world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f; // stay in 2D plane

        // Direction from object to mouse
        Vector3 direction = mouseWorldPos - transform.position;

        // Calculate angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
