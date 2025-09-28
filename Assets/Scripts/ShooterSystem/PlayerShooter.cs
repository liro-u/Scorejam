using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform projectileParent;

    [Header("Projectile Parameters")]
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float shootInterval = 0.5f;

    private Coroutine shootingCoroutine;

    public void StartShooting()
    {
        if (shootingCoroutine == null)
            shootingCoroutine = StartCoroutine(ShootRoutine());
    }

    public void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    private void Shoot()
    {
        if (projectilePrefab == null || shootPoint == null) return;

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation, projectileParent);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = shootPoint.right * projectileSpeed;
        }
    }
}
