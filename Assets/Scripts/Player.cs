using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerInput pi;

    public void DisablePhysics()
    {
        rb.bodyType = RigidbodyType2D.Kinematic; // plus de physique
        rb.linearVelocity = Vector2.zero;        // stoppe le mouvement
        rb.angularVelocity = 0f;
        rb.simulated = false;
        pi.enabled = false;
    }

    public void EnablePhysics()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.simulated = true;
        pi.enabled = true;
    }

    
}
