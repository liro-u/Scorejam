using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;     // Where the projectile spawns
    [SerializeField] private Transform projectileParent; // Where the projectile is parented

    [Header("Projectile Parameters")]
    [SerializeField] private float projectileSpeed = 10f;

    public void Shoot()
    {
        if (projectilePrefab == null || shootPoint == null) return;

        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation, projectileParent);

        // Give it forward velocity if it has a Rigidbody
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = shootPoint.right * projectileSpeed;
        }
    }
}
