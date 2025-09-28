using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damage = 20;
    [SerializeField] private float damageBase = 20;
    [SerializeField] private float damageBonus = 40;
    public void MakeDamage(GameObject go)
    {
        go.GetComponent<Damagable>().healthSystem.ApplyHealthModifier(-damage);
    }

    public void AplyDamageBonus(int bonusType)
    {
        if(bonusType == (int)BonusType.AttackBoost)
        {
            damage = damageBonus;
        }
        else
        {
            damage = damageBase;
        }
    }
}
