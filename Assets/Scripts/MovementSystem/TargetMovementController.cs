using UnityEngine;
using UnityEngine.AI;

public class TargetMovementController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private MovementSystem movementSystem;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);

        Vector2 moveInput = new Vector2(agent.velocity.x, agent.velocity.y);

        if (moveInput.magnitude > 1f)
            moveInput.Normalize();

        movementSystem.MoveInput = moveInput;
    }
}
