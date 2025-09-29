using TMPro;
using UnityEngine;

public class FInalScoreDisplay : MonoBehaviour
{
    public void Awake()
    {
        GetComponent<TMP_Text>().text = "Score :  " + PlayerPrefs.GetInt("runScore");
    }
}
