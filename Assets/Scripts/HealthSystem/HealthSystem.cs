using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100.0f;

    [Header("Invincibility Settings")]
    [SerializeField] private float invincibilityDuration = 0f; // seconds (0 = disabled)

    [Header("Events")]
    [SerializeField] private UnityEvent<float> healthChanged;
    [SerializeField] private UnityEvent<float> healthIncrease;
    [SerializeField] private UnityEvent<float> healthDecrease;
    [SerializeField] private UnityEvent<bool> healthEmpty;

    public float CurrentHealth { get; private set; }

    private float invincibilityTimer = 0f;

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        // Count down invincibility timer if active
        if (invincibilityTimer > 0f)
        {
            invincibilityTimer -= Time.deltaTime;
        }
    }

    public void ApplyHealthModifier(float healthModifier)
    {
        // If taking damage but still invincible, ignore
        if (healthModifier < 0 && invincibilityTimer > 0f)
        {
            return;
        }

        float oldHealth = CurrentHealth;
        CurrentHealth += healthModifier;
        CurrentHealth = Mathf.Max(0, CurrentHealth);

        if (CurrentHealth != oldHealth)
        {
            healthChanged.Invoke(CurrentHealth);

            if (healthModifier > 0)
            {
                healthIncrease.Invoke(CurrentHealth);
            }
            else if (healthModifier < 0)
            {
                healthDecrease.Invoke(CurrentHealth);

                // Start i-frames if enabled
                if (invincibilityDuration > 0f)
                {
                    invincibilityTimer = invincibilityDuration;
                }
            }

            if (CurrentHealth <= 0)
            {
                healthEmpty.Invoke(true);
            }
        }
    }
}
