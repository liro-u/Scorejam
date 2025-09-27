using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100.0f;
    [SerializeField] private UnityEvent<float> healthChanged;
    [SerializeField] private UnityEvent<float> healthIncrease;
    [SerializeField] private UnityEvent<float> healthDecrease;
    [SerializeField] private UnityEvent<float> healthEmpty;

    public float CurrentHealth { get; private set; }

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    public void ApplyHealthModifier(float healthModifier)
    {
        CurrentHealth += healthModifier;
        healthChanged.Invoke(CurrentHealth);
        Debug.Log("Health : " + CurrentHealth);

        if (healthModifier > 0)
        {
            healthIncrease.Invoke(CurrentHealth);
        }
        else if (healthModifier < 0) 
        {
            healthDecrease.Invoke(CurrentHealth);
        }

        if (CurrentHealth <= 0)
        {
            healthEmpty.Invoke(CurrentHealth);
        }
    }
}
