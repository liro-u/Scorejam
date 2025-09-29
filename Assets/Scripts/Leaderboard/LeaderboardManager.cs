using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{

    public GameObject playerScorePrefab;
    public Transform rankingTransform;
    private APIHandler api;
    private void Awake()
    {
        api = GetComponent<APIHandler>();
        api.GetrequestScore(PopulateLeaderboards);
    }

    public void PopulateLeaderboards(PlayerListClass playerLists)
    {
        foreach (var player in playerLists.players)
        {
            GameObject temp = Instantiate(playerScorePrefab, rankingTransform);
            temp.GetComponent<LeaderboardChild>().Setup(player);
        }
    }
}
