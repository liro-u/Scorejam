using UnityEngine;
using UnityEngine.AI;

public class TargetMovementController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private MovementSystem movementSystem;
    private bool isDead = false;

    private NavMeshAgent agent;
    [SerializeField] private Transform enemyTransform;

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
        if (moveInput.x < -0.01f)
            enemyTransform.localScale = new Vector3(-1f, enemyTransform.localScale.y, enemyTransform.localScale.z);
        else if (moveInput.x > 0.01f)
            enemyTransform.localScale = new Vector3(1f, enemyTransform.localScale.y, enemyTransform.localScale.z);
    
}
}
