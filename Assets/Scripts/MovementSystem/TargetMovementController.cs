using UnityEngine;
using UnityEngine.AI;

public class TargetMovementController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private MovementSystem movementSystem;
    private bool isDead = false;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void Die()
    {
        isDead = true;
        agent.ResetPath();
    }

    void Update()
    {
        if (isDead) return;
        agent.SetDestination(target.position);

        Vector2 moveInput = new Vector2(agent.velocity.x, agent.velocity.y);

        if (moveInput.magnitude > 1f)
            moveInput.Normalize();

        movementSystem.MoveInput = moveInput;
    }
}
