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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

}
