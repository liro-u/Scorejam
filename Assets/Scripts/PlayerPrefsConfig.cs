using UnityEngine;

public class PlayerPrefsConfig : MonoBehaviour
{
    public void SetPlayerName(string text)
    {
        PlayerPrefs.SetString("playerName", text);
    }

    public void SetRunScore(int score)
    {
        PlayerPrefs.SetInt("runScore", score);
    }

    public void ResetRunScore()
    {
        PlayerPrefs.SetInt("runScore", 0);
    }

}
