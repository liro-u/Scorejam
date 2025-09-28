using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float bonusSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform playerTransform;
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


    public void EnableMovement()
    {
        disable = false;
    }

    public void DisableMovement()
    {
        disable = true;
    }

    public void aplySpeedBoost(int bonusType)
    {
        if (bonusType == (int)BonusType.SpeedBoost)
        {
            moveSpeed = bonusSpeed;
        }
        else
        {
            moveSpeed = baseSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveInput.x <= -0.1f)
        {
            playerTransform.localScale = new Vector3(-1f,playerTransform.localScale.y, playerTransform.localScale.z);
        }
        else if (moveInput.x >= 0.1f)
        {
            playerTransform.localScale = new Vector3(1f, playerTransform.localScale.y, playerTransform.localScale.z);
        }

        if (disable) return;
        rb.linearVelocity = moveInput * moveSpeed;
    }

}
