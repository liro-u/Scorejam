using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] protected float damage = 20;
    
    public void MakeDamage(GameObject go)
    {
        go.GetComponent<Damagable>().healthSystem.ApplyHealthModifier(-damage);
    }

   
}
