using UnityEngine;
using UnityEngine.Events;

public enum BonusType
{
    None = 0,
    SpeedBoost = 1,
    AttackSpeedBoost = 2,
    Points = 3,
    AttackBoost = 4,
    Shotgun = 5,
    Heal = 6
}


public class BonusManager : MonoBehaviour
{
    public static BonusManager Instance { get; private set; }

    private int bonusNumber = 0;

    [SerializeField] private UnityEvent<int> onBonusChange;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ChoseRandomBonus()
    {
        bonusNumber = Random.Range(1, 7);

        switch(bonusNumber)
        {
            case (int)BonusType.Points:
                ScoreManager.Instance.AddScore(1000);
                break;

            case (int)BonusType.Heal:
                Player.Instance.GetComponent<HealthSystem>().ApplyHealthModifier(1);
                break;
        }

        onBonusChange.Invoke(bonusNumber);
    }


}
