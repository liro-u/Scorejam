using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerInput pi;

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // évite les doublons
            return;
        }
        Instance = this;

        // Optionnel : garder le player entre les scènes
        // DontDestroyOnLoad(gameObject);
    }

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
