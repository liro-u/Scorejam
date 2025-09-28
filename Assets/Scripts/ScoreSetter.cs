using UnityEngine;

public class ScoreSetter : SetUILabel
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetLabel(GameManager.Instance.score);
    }
}
