using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using System.Linq.Expressions;
using System;

public class APIHandler : MonoBehaviour
{

    private const string requestUrl = "https://studio--studio-4263473062-6e130.us-central1.hosted.app/api/scores";
    public PlayerListClass returnPlayers = new PlayerListClass();

    private Action<PlayerListClass> onPlayersReceived;
    IEnumerator getScores(Action<PlayerListClass> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(requestUrl))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error on the Get request: " + request.error);
            }
            else
            {
                string jsonText = request.downloadHandler.text;
                string wrapperJson = "{\"players\":" + jsonText + "}";

                try
                {
                    PlayerListClass allPlayers = JsonUtility.FromJson<PlayerListClass>(wrapperJson);
                    returnPlayers = allPlayers;
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Error trying to parse JSON. " + e.ToString());
                    callback?.Invoke(null);
                }
                callback?.Invoke(returnPlayers);
            }
        }
    }

    IEnumerator uploadScore(ScoreClass player)
    {
        Debug.Log("Sending player data");
        string jsonData = "{\"player\": \"" + player.player + "\","
                           + " \n \"score\": " + player.score + ","
                           + " \n \"password\" : \"ScoreJam2025lmao\" }";
        UnityWebRequest postScore = new UnityWebRequest(requestUrl, UnityWebRequest.kHttpVerbPOST);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        postScore.uploadHandler = new UploadHandlerRaw(bodyRaw);
        postScore.downloadHandler = new DownloadHandlerBuffer();
        postScore.SetRequestHeader("Content-Type", "application/json");
        yield return postScore.SendWebRequest();
        Debug.Log(postScore.ToString());
        if (postScore.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Something went wrong uploading the score. " +  postScore.result);
            yield return 0;
        }
        else
        {
            Debug.Log("Upload successful.");
            yield return 1;
        }
    }
    public void GetrequestScore(Action<PlayerListClass> onPlayersLoaded)
    {
        StartCoroutine(getScores(onPlayersLoaded));
    }

    public Coroutine PostScore(ScoreClass player)
    {
        return StartCoroutine(uploadScore(player));
    }
}
