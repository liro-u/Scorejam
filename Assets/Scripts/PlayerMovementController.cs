using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private MovementSystem pm;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Move(InputAction.CallbackContext context)
    {
        pm.moveInput = context.ReadValue<Vector2>();
    }
}
