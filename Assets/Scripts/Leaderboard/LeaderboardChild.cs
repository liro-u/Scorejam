using TMPro;
using UnityEngine;

public class LeaderboardChild : MonoBehaviour
{
    private TMP_Text[] textChildren;

    public void Awake()
    {
        textChildren = GetComponentsInChildren<TMP_Text>();
    }

    public void Setup(ScoreClass player)
    {
        textChildren[0].text = player.player;
        textChildren[1].text = player.score.ToString();
    }
}
