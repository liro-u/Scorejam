using System.Collections;
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
    public AudioClip[] audioSpdBst, audioAtkSpdBst, audioPts, audioAtkBst, audioShtg, audioHeal;
    public AudioClip bonusEffect;
    private AudioSource thisAS;
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
        thisAS = GetComponent<AudioSource>();
        Instance = this;
    }

    public void ChoseRandomBonus()
    {
        bonusNumber = Random.Range(1, 7);
        StartCoroutine(PlayAudio(bonusNumber));

        switch (bonusNumber)
        {
            case (int)BonusType.Points:
                ScoreManager.Instance.AddScore(10000);
                break;

            case (int)BonusType.Heal:
                Player.Instance.GetComponent<HealthSystem>().ApplyHealthModifier(1);
                break;
        }

        
        onBonusChange.Invoke(bonusNumber);
    }

    IEnumerator PlayAudio(int number)
    {
        yield return new WaitForSecondsRealtime(2);
        thisAS.PlayOneShot(bonusEffect, .5f);
        switch (number)
        {
            case (int)BonusType.Points:
                thisAS.PlayOneShot(audioPts[Random.Range(0, audioPts.Length)], .8f);
                break;

            case (int)BonusType.Heal:
                thisAS.PlayOneShot(audioHeal[Random.Range(0, audioHeal.Length)], .8f);
                break;

            case (int)BonusType.Shotgun:
                thisAS.PlayOneShot(audioShtg[Random.Range(0, audioShtg.Length)], .8f);
                break;

            case (int)BonusType.AttackBoost:
                thisAS.PlayOneShot(audioAtkBst[Random.Range(0, audioAtkBst.Length)], .8f);
                break;

            case (int)BonusType.AttackSpeedBoost:
                thisAS.PlayOneShot(audioAtkSpdBst[Random.Range(0, audioAtkSpdBst.Length)], .8f);
                break;

            case (int)BonusType.SpeedBoost:
                thisAS.PlayOneShot(audioSpdBst[Random.Range(0, audioSpdBst.Length)], .8f);
                break;
        }
    }

}
