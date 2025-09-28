using UnityEngine;

public class ScoreModifier : MonoBehaviour
{
    [SerializeField] private int pointsToAdd = 1;

    public void AddPoints()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(pointsToAdd);
        }
    }
}
