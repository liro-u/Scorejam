using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Transform playerTransform;
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
    void Awake()
    {
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveInput.x <= -0.1f)
        {
            playerTransform.localScale = new Vector3(-.7f,playerTransform.localScale.y, playerTransform.localScale.z);
        }
        else if (moveInput.x >= 0.1f)
        {
            playerTransform.localScale = new Vector3(.7f, playerTransform.localScale.y, playerTransform.localScale.z);
        }
            rb.linearVelocity = moveInput * moveSpeed;
    }

}
