using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveInput = Vector2.zero;
    public Vector2 MoveInput
    {
        get => moveInput;
        set               
        {
            bool wasMoving = moveInput.magnitude == 0;
            moveInput = value;
            bool isMoving = moveInput.magnitude == 0;
            if (wasMoving != isMoving)
            { 
                if (isMoving)
                {
                    onMove.Invoke(false);
                }
                else
                {
                    onMove.Invoke(true);
                } 
            }
        }
    }
    [SerializeField] private UnityEvent<bool> onMove;
    [SerializeField] private bool disable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void EnableMovement()
    {
        disable = false;
    }

    public void DisableMovement()
    {
        disable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (disable) return;
        rb.linearVelocity = moveInput * moveSpeed;
    }

}
