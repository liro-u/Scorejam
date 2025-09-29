using UnityEngine;

public class ProjectileDamager : Damager
{
    [SerializeField] private float damageBonus = 40;
    [SerializeField] private GameObject go;
    [SerializeField] private GameObject defaultVisual;
    [SerializeField] private GameObject bonusVisual;
    public void Start()
    {
        defaultVisual.SetActive(true);
        bonusVisual.SetActive(false);
        AplyDamageBonus();
    }

    public void AplyDamageBonus()
    {
            if (BonusManager.Instance.BonusNumber == (int)BonusType.AttackBoost)
            {
                damage = damageBonus;
                go.transform.localScale = new Vector3(go.transform.localScale.x*2, go.transform.localScale.y*2, go.transform.localScale.z*2);
                defaultVisual.SetActive(false);
                bonusVisual.SetActive(true);
            }
    }
}
