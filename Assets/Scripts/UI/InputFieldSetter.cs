
using TMPro;
using UnityEngine;

public class InputFieldSetter : MonoBehaviour
{
    public void Awake()
    {
        GetComponent<TMP_InputField>().text = PlayerPrefs.HasKey("playerName") ? PlayerPrefs.GetString("playerName") : "";
    }
}
