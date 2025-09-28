using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayerShooter : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform shootPoint2;
    [SerializeField] private Transform shootPoint3;
    [SerializeField] private Transform projectileParent;

    [Header("Projectile Parameters")]
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float shootInterval = 0.5f;


    [SerializeField] private UnityEvent onShoot;
    
    private bool isShooting = false;
    private float lastShootTime = 0f;

    private bool useBonus = false;


    public void CheckForBonus(int bonusType)
    {
        useBonus = (bonusType == (int)BonusType.Shotgun);
    }

    private void Update()
    {
        if (isShooting)
        {
            TryShoot();
        }
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    public void TryShoot()
    {
        if (Time.time - lastShootTime >= shootInterval)
        {
            Shoot();
            lastShootTime = Time.time;
        }
    }

    private void Shoot()
    {
        if (projectilePrefab == null || shootPoint == null) return;

        onShoot.Invoke();

        shootFromPoint(shootPoint);

        if (useBonus)
        {
            shootFromPoint(shootPoint2);
            shootFromPoint(shootPoint3);
        }
    }

    private void shootFromPoint(Transform point)
    {
        GameObject projectile = Instantiate(projectilePrefab, point.position, shootPoint.rotation, projectileParent);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = shootPoint.right * projectileSpeed;
        }
    }
}
